import { FinanceAccount } from "@/db/schema"

export type AccountType = "Asset" | "Liability" | "Equity" | "Revenue" | "Expense"

export interface AccountBalance extends Omit<FinanceAccount, 'type'> {
    type: AccountType
    totalDebit: number
    totalCredit: number
    balance: number
}

export interface BalanceSheetData {
    assets: AccountBalance[]
    liabilities: AccountBalance[]
    equity: AccountBalance[]
    totalAssets: number
    totalLiabilities: number
    totalEquity: number
}

export interface ProfitLossData {
    revenue: AccountBalance[]
    expenses: AccountBalance[]
    totalRevenue: number
    totalExpenses: number
    netProfit: number
}

export interface JournalEntryRequest {
    description: string
    referenceNo?: string
    date?: Date
    items: {
        accountId: string
        debit: number
        credit: number
        description?: string
    }[]
}
