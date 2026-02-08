import { Product, Sale } from "@/db/schema"

export interface CartItem {
    product: Product
    quantity: number
}

export interface SaleRequest {
    customerId: string | null
    warehouseId: number
    items: {
        productId: string
        quantity: number
        unitPrice: number
        costPrice: number
    }[]
    discount: number
    tax: number
    paymentMethod: "Cash" | "Card" | "Credit"
}

export interface POSState {
    cart: CartItem[]
    discount: number
    taxRate: number
    selectedCustomerId: string
    processing: boolean
}
