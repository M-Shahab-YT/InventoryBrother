import { useState, useMemo } from "react"
import { useCart } from "./use-cart"
import { createSale } from "@/actions/pos"
import { CartItem } from "@/types/pos"

export function usePOS(warehouseId: number) {
    const { cart, addToCart, removeFromCart, updateQuantity, clearCart, subtotal } = useCart()
    const [selectedCustomerId, setSelectedCustomerId] = useState<string>("walk-in")
    const [discount, setDiscount] = useState<number>(0)
    const [taxRate, setTaxRate] = useState<number>(0)
    const [processing, setProcessing] = useState(false)
    const [lastSale, setLastSale] = useState<{ sale: any, items: CartItem[] } | null>(null)
    const [receiptOpen, setReceiptOpen] = useState(false)

    const taxAmount = subtotal * (taxRate / 100)
    const netAmount = subtotal + taxAmount - discount

    const handleCheckout = async () => {
        if (cart.length === 0) return
        setProcessing(true)
        try {
            const result = await createSale({
                customerId: selectedCustomerId === "walk-in" ? null : selectedCustomerId,
                warehouseId,
                items: cart.map(item => ({
                    productId: item.product.id,
                    quantity: item.quantity,
                    unitPrice: item.product.price || 0,
                    costPrice: item.product.cost || 0
                })),
                discount,
                tax: taxAmount,
                paymentMethod: "Cash"
            })

            setLastSale({
                sale: result.sale,
                items: [...cart]
            })
            setReceiptOpen(true)

            clearCart()
            setDiscount(0)
            setTaxRate(0)
            setSelectedCustomerId("walk-in")
        } catch (e) {
            alert("Checkout Failed: " + e)
        } finally {
            setProcessing(false)
        }
    }

    return {
        cart,
        addToCart,
        removeFromCart,
        updateQuantity,
        clearCart,
        subtotal,
        discount,
        setDiscount,
        taxRate,
        setTaxRate,
        taxAmount,
        netAmount,
        selectedCustomerId,
        setSelectedCustomerId,
        processing,
        handleCheckout,
        lastSale,
        receiptOpen,
        setReceiptOpen
    }
}
