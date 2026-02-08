import { getWarehouses } from "@/actions/warehouse"
import { WarehouseList } from "@/features/inventory/components/warehouse-list"
import { WarehouseDialog } from "@/features/inventory/components/warehouse-dialog"

export default async function WarehousesPage() {
    const warehouses = await getWarehouses()

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6">Inventory Management</h1>
            <WarehouseList initialWarehouses={warehouses} />
        </div>
    )
}
