'use server'

import { revalidatePath } from "next/cache"
import { FinanceService } from "@/services/finance-service"
import { NewFinanceAccount } from "@/db/schema"
import { JournalEntryRequest } from "@/types/finance"

// --- Account Management ---

export async function getAccounts() {
    return await FinanceService.getAccounts()
}

export async function createAccount(data: NewFinanceAccount) {
    const account = await FinanceService.createAccount(data)
    revalidatePath("/finance/accounts")
    return account
}

export async function updateAccount(id: string, data: Partial<NewFinanceAccount>) {
    await FinanceService.updateAccount(id, data)
    revalidatePath("/finance/accounts")
}

export async function deleteAccount(id: string) {
    await FinanceService.deleteAccount(id)
    revalidatePath("/finance/accounts")
}

// --- Journal & Ledger ---

export async function createJournalEntry(data: JournalEntryRequest) {
    const entry = await FinanceService.createJournalEntry(data)
    revalidatePath("/finance/ledger")
    revalidatePath("/finance/journal")
    return entry
}

export async function getJournalEntries() {
    // Basic wrapper, might move more complex logic to service if needed
    return await FinanceService.getJournalEntries() 
}

export async function getLedger(accountId?: string) {
    return await FinanceService.getLedger(accountId)
}

import { SYSTEM_ACCOUNTS } from "@/constants/finance"

export async function ensureSystemAccounts() {
    // This logic is fine as a setup action for now
    // But could also move to FinanceService for consistency
    return await FinanceService.ensureSystemAccounts(SYSTEM_ACCOUNTS)
}
