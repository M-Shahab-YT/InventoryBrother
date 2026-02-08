import { getBalanceSheetData, getProfitLossData } from "@/actions/finance-reports"
import { FinancialReports } from "@/features/finance/components/financial-reports"

export default async function FinancialReportsPage() {
    const [balanceSheet, profitLoss] = await Promise.all([
        getBalanceSheetData(),
        getProfitLossData()
    ])

    return (
        <div className="space-y-6">
            <h1 className="text-3xl font-bold">Financial Reports</h1>
            <FinancialReports balanceSheet={balanceSheet} profitLoss={profitLoss} />
        </div>
    )
}
