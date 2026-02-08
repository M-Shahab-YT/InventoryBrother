import { getProducts } from "@/actions/products"
import { getSuppliers } from "@/actions/supplier"
import { PurchaseOrderForm } from "@/features/purchasing/components/purchase-order-form"

export default async function NewPurchaseOrderPage() {
    const [products, suppliers] = await Promise.all([
        getProducts(),
        getSuppliers()
    ])

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6">Create Purchase Order</h1>
            <PurchaseOrderForm products={products} suppliers={suppliers} />
        </div>
    )
}
