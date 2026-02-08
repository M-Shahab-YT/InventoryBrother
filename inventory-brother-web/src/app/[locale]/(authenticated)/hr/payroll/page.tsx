import { getPayrollHistory } from "@/actions/hr"
import { PayrollControlPanel } from "@/features/hr/components/payroll-control-panel"
import { PayrollHistoryTable } from "@/features/hr/components/payroll-history-table"
import { PayrollProcessor } from "@/features/hr/components/payroll-processor"

export default async function PayrollPage() {
    const history = await getPayrollHistory()

    return (
        <div className="space-y-6">
            <h1 className="text-3xl font-bold italic tracking-tight">Payroll Management</h1>
            <PayrollProcessor history={history} />
        </div>
    )
}
