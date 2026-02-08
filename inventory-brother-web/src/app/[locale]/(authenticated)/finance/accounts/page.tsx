import { getAccounts } from "@/actions/finance"
import { ChartOfAccounts } from "@/features/finance/components/chart-of-accounts"
import { AccountDialog } from "@/features/finance/components/account-dialog"

export default async function AccountsPage() {
    const accounts = await getAccounts()

    return (
        <div className="space-y-6">
            <div className="flex justify-between items-center">
                <h1 className="text-3xl font-bold italic tracking-tight">Chart of Accounts</h1>
            </div>

            <ChartOfAccounts accounts={accounts} />
        </div>
    )
}
