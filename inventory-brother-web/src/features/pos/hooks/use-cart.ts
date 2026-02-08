import { useState, useMemo } from "react"
import { Product } from "@/db/schema"

export type CartItem = {
    product: Product
    quantity: number
}

export function useCart() {
    const [cart, setCart] = useState<CartItem[]>([])

    const addToCart = (product: Product) => {
        setCart(prev => {
            const existing = prev.find(item => item.product.id === product.id)
            if (existing) {
                return prev.map(item =>
                    item.product.id === product.id
                        ? { ...item, quantity: item.quantity + 1 }
                        : item
                )
            }
            return [...prev, { product, quantity: 1 }]
        })
    }

    const removeFromCart = (productId: string) => {
        setCart(prev => prev.filter(item => item.product.id !== productId))
    }

    const updateQuantity = (productId: string, delta: number) => {
        setCart(prev => prev.map(item => {
            if (item.product.id === productId) {
                const newQty = Math.max(1, item.quantity + delta)
                return { ...item, quantity: newQty }
            }
            return item
        }))
    }

    const clearCart = () => setCart([])

    const subtotal = useMemo(() => 
        cart.reduce((sum, item) => sum + (item.quantity * (item.product.price || 0)), 0),
    [cart])

    return {
        cart,
        addToCart,
        removeFromCart,
        updateQuantity,
        clearCart,
        subtotal
    }
}
