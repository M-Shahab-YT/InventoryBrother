import { getProducts } from "@/actions/products"
import { getCustomers } from "@/actions/customer"
import { POSInterface } from "@/features/pos/components/pos-interface"

export default async function POSPage() {
    const [products, customers] = await Promise.all([
        getProducts(),
        getCustomers()
    ])

    // Hardcoded Warehouse ID 1 for now. 
    // In future, this could be selected via a setting or user context.
    return (
        <div className="p-4 h-full">
            <h1 className="sr-only">Point of Sale</h1>
            <POSInterface products={products} customers={customers} warehouseId={1} />
        </div>
    )
}
