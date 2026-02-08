'use server'

import { FinanceService } from "@/services/finance-service"

export async function getAccountBalances(asOfDate?: Date) {
    return await FinanceService.getAccountBalances(asOfDate)
}

export async function getBalanceSheetData() {
    return await FinanceService.getBalanceSheetData()
}

export async function getProfitLossData(startDate?: Date, endDate?: Date) {
    return await FinanceService.getProfitLossData(startDate, endDate)
}
