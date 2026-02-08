import { getPurchaseOrders } from "@/actions/purchasing"
import { getSuppliers } from "@/actions/supplier"
import { PurchaseOrderList } from "@/features/purchasing/components/purchase-order-list"

export default async function PurchaseOrdersPage() {
    const [orders, suppliers] = await Promise.all([
        getPurchaseOrders(),
        getSuppliers()
    ])

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6">Purchasing</h1>
            <PurchaseOrderList initialOrders={orders} suppliers={suppliers} />
        </div>
    )
}
