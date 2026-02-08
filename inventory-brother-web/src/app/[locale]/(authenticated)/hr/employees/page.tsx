import { getEmployees } from "@/actions/hr"
import { EmployeeList } from "@/features/hr/components/employee-list"
import { EmployeeDialog } from "@/features/hr/components/employee-dialog"

export default async function EmployeesPage() {
    const employees = await getEmployees()

    return (
        <div className="space-y-6">
            <div className="flex justify-between items-center">
                <h1 className="text-3xl font-bold italic tracking-tight">Employee Directory</h1>
            </div>

            <EmployeeList employees={employees} />
        </div>
    )
}
