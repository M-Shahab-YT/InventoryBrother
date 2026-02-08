import { getSuppliers } from "@/actions/supplier"
import { SupplierList } from "@/features/inventory/components/supplier-list"
import { SupplierDialog } from "@/features/inventory/components/supplier-dialog"

export default async function SuppliersPage() {
    const suppliers = await getSuppliers()

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6">Supplier Management</h1>
            <SupplierList initialSuppliers={suppliers} />
        </div>
    )
}
