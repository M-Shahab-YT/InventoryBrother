import { getCustomers } from "@/actions/customer"
import { CustomerList } from "@/features/sales/components/CustomerList"

export default async function CustomersPage() {
    const customers = await getCustomers()

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6">Customer Management</h1>
            <CustomerList initialCustomers={customers} />
        </div>
    )
}
