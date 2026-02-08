import { db } from "@/lib/db"
import { financeAccounts, journalEntries, ledgerEntries, NewFinanceAccount } from "@/db/schema"
import { eq, asc, desc, sql, lte } from "drizzle-orm"
import { 
    AccountBalance, 
    BalanceSheetData, 
    ProfitLossData, 
    JournalEntryRequest,
    AccountType 
} from "@/types/finance"

export class FinanceService {
    static async getAccounts() {
        return await db.select().from(financeAccounts).orderBy(asc(financeAccounts.code))
    }

    static async createAccount(data: NewFinanceAccount) {
        const [account] = await db.insert(financeAccounts).values(data).returning()
        return account
    }

    static async updateAccount(id: string, data: Partial<NewFinanceAccount>) {
        return await db.update(financeAccounts)
            .set({ ...data, updatedAt: new Date() })
            .where(eq(financeAccounts.id, id))
    }

    static async deleteAccount(id: string) {
        return await db.delete(financeAccounts).where(eq(financeAccounts.id, id))
    }

    static async createJournalEntry(data: JournalEntryRequest) {
        const totalDebit = data.items.reduce((sum, item) => sum + item.debit, 0)
        const totalCredit = data.items.reduce((sum, item) => sum + item.credit, 0)
        
        if (Math.abs(totalDebit - totalCredit) > 0.01) {
            throw new Error("Journal entry must be balanced (Debits = Credits)")
        }

        return await db.transaction(async (tx) => {
            const [header] = await tx.insert(journalEntries).values({
                description: data.description,
                referenceNo: data.referenceNo,
                date: data.date || new Date(),
                status: "Posted"
            }).returning()

            for (const item of data.items) {
                await tx.insert(ledgerEntries).values({
                    journalEntryId: header.id,
                    accountId: item.accountId,
                    debit: item.debit,
                    credit: item.credit,
                    description: item.description || data.description
                })
            }
            return header
        })
    }

    static async getAccountBalances(asOfDate?: Date) {
        const dateLimit = asOfDate || new Date()
        const balances = await db.select({
            id: financeAccounts.id,
            name: financeAccounts.name,
            code: financeAccounts.code,
            type: financeAccounts.type,
            parentId: financeAccounts.parentId,
            description: financeAccounts.description,
            createdAt: financeAccounts.createdAt,
            updatedAt: financeAccounts.updatedAt,
            createdBy: financeAccounts.createdBy,
            updatedBy: financeAccounts.updatedBy,
            storeId: financeAccounts.storeId,
            totalDebit: sql<number>`SUM(${ledgerEntries.debit})`.mapWith(Number),
            totalCredit: sql<number>`SUM(${ledgerEntries.credit})`.mapWith(Number),
        })
        .from(financeAccounts)
        .leftJoin(ledgerEntries, eq(financeAccounts.id, ledgerEntries.accountId))
        .leftJoin(journalEntries, eq(ledgerEntries.journalEntryId, journalEntries.id))
        .where(lte(journalEntries.date, dateLimit))
        .groupBy(financeAccounts.id)

        return balances.map(b => {
            const type = b.type as AccountType
            const net = (b.totalDebit || 0) - (b.totalCredit || 0)
            const balance = ["Asset", "Expense"].includes(type) ? net : -net
            return { ...b, type, balance } as AccountBalance
        })
    }

    static async getBalanceSheetData(): Promise<BalanceSheetData> {
        const balances = await this.getAccountBalances()
        const plData = await this.getProfitLossData()
        
        const assets = balances.filter(b => b.type === "Asset")
        const liabilities = balances.filter(b => b.type === "Liability")
        const equity = balances.filter(b => b.type === "Equity")

        return {
            assets,
            liabilities,
            equity: [
                ...equity,
                { id: "net-profit", name: "Current Period Profit/Loss", balance: plData.netProfit, type: "Equity" } as any
            ],
            totalAssets: assets.reduce((s, i) => s + i.balance, 0),
            totalLiabilities: liabilities.reduce((s, i) => s + i.balance, 0),
            totalEquity: equity.reduce((s, i) => s + i.balance, 0) + plData.netProfit
        }
    }

    static async getProfitLossData(startDate?: Date, endDate?: Date): Promise<ProfitLossData> {
        const balances = await this.getAccountBalances(endDate)
        const revenue = balances.filter(b => b.type === "Revenue")
        const expenses = balances.filter(b => b.type === "Expense")

        const totalRevenue = revenue.reduce((s, i) => s + i.balance, 0)
        const totalExpenses = expenses.reduce((s, i) => s + i.balance, 0)

        return {
            revenue,
            expenses,
            totalRevenue,
            totalExpenses,
            netProfit: totalRevenue - totalExpenses
        }
    }
    static async getJournalEntries() {
        return await db.select().from(journalEntries).orderBy(desc(journalEntries.date))
    }

    static async getLedger(accountId?: string) {
        let query = db.select({
            id: ledgerEntries.id,
            date: journalEntries.date,
            description: ledgerEntries.description,
            debit: ledgerEntries.debit,
            credit: ledgerEntries.credit,
            accountName: financeAccounts.name,
            referenceNo: journalEntries.referenceNo,
        })
        .from(ledgerEntries)
        .innerJoin(journalEntries, eq(ledgerEntries.journalEntryId, journalEntries.id))
        .innerJoin(financeAccounts, eq(ledgerEntries.accountId, financeAccounts.id))
        
        if (accountId) {
            query = query.where(eq(ledgerEntries.accountId, accountId)) as any
        }

        return await query.orderBy(desc(journalEntries.date))
    }

    static async recordAutoJournalEntry(tx: any, data: {
        description: string,
        referenceNo: string,
        items: { code: string, debit: number, credit: number }[]
    }) {
        const [header] = await tx.insert(journalEntries).values({
            description: data.description,
            referenceNo: data.referenceNo,
            date: new Date(),
            status: "Posted"
        }).returning()

        for (const item of data.items) {
            if (item.debit === 0 && item.credit === 0) continue

            const [acc] = await tx.select().from(financeAccounts).where(eq(financeAccounts.code, item.code)).limit(1)
            if (!acc) throw new Error(`System Account with code ${item.code} not found.`)

            await tx.insert(ledgerEntries).values({
                journalEntryId: header.id,
                accountId: acc.id,
                debit: item.debit,
                credit: item.credit,
                description: data.description
            })
        }
    }

    static async ensureSystemAccounts(systemAccounts: any) {
        for (const [key, details] of Object.entries(systemAccounts)) {
            const d = details as any
            const existing = await db.select().from(financeAccounts).where(eq(financeAccounts.code, d.code)).limit(1)
            if (existing.length === 0) {
                await db.insert(financeAccounts).values({
                    name: d.name,
                    code: d.code,
                    type: d.type,
                    storeId: 1
                })
            }
        }
    }
}
