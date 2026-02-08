import { getProducts } from "@/actions/products"
import { getWarehouses } from "@/actions/warehouse"
import { StockAdjustmentForm } from "@/features/inventory/components/stock-adjustment-form"

export default async function StockAdjustmentsPage() {
    const [products, warehouses] = await Promise.all([
        getProducts(),
        getWarehouses()
    ])

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6">Stock Adjustments</h1>
            <StockAdjustmentForm products={products} warehouses={warehouses} />
        </div>
    )
}
