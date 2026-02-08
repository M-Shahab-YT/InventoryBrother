import { getPurchaseOrder } from "@/actions/purchasing"
import { getWarehouses } from "@/actions/warehouse"
import { PurchaseOrderDetails } from "@/features/purchasing/components/purchase-order-details"
import { notFound } from "next/navigation"

export default async function PurchaseOrderDetailPage({ params }: { params: { id: string } }) {
    const { id } = params
    const [orderData, warehouses] = await Promise.all([
        getPurchaseOrder(id),
        getWarehouses()
    ])

    if (!orderData) {
        notFound()
    }

    return (
        <div className="p-6">
            <PurchaseOrderDetails
                order={orderData}
                items={orderData.items}
                warehouses={warehouses}
            />
        </div>
    )
}
