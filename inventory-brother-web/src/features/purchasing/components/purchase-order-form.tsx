'use client'

import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import {
    Select,
    SelectContent,
    SelectItem,
    SelectTrigger,
    SelectValue,
} from "@/components/ui/select"
import { createPurchaseOrder } from "@/actions/purchasing"
import { Supplier, Product } from "@/db/schema"
import { useState } from "react"
import { Plus, Trash2 } from "lucide-react"
import { useRouter } from "next/navigation"

interface PurchaseOrderFormProps {
    suppliers: Supplier[]
    products: Product[]
}

type OrderItem = {
    productId: string
    quantity: number
    unitCost: number
}

export function PurchaseOrderForm({ suppliers, products }: PurchaseOrderFormProps) {
    const router = useRouter()
    const [loading, setLoading] = useState(false)
    const [items, setItems] = useState<OrderItem[]>([])

    const addItem = () => {
        setItems([...items, { productId: "", quantity: 1, unitCost: 0 }])
    }

    const removeItem = (index: number) => {
        setItems(items.filter((_, i) => i !== index))
    }

    const updateItem = (index: number, field: keyof OrderItem, value: any) => {
        const newItems = [...items]
        newItems[index] = { ...newItems[index], [field]: value }
        if (field === 'productId') {
            const prod = products.find(p => p.id === value)
            if (prod) {
                newItems[index].unitCost = prod.cost || 0 // Default to product cost
            }
        }
        setItems(newItems)
    }

    const handleSubmit = async (formData: FormData) => {
        setLoading(true)
        try {
            await createPurchaseOrder({
                supplierId: formData.get("supplierId") as string,
                remarks: formData.get("remarks") as string,
                items
            })
            router.push("/dashboard/purchasing/orders")
        } catch (e) {
            alert("Failed to create order: " + e)
        } finally {
            setLoading(false)
        }
    }

    const totalAmount = items.reduce((sum, item) => sum + (item.quantity * item.unitCost), 0)

    return (
        <form action={handleSubmit} className="space-y-6 max-w-4xl">
            <div className="grid grid-cols-2 gap-4">
                <div className="space-y-2">
                    <Label htmlFor="supplierId">Supplier</Label>
                    <Select name="supplierId" required>
                        <SelectTrigger>
                            <SelectValue placeholder="Select Supplier" />
                        </SelectTrigger>
                        <SelectContent>
                            {suppliers.map(s => (
                                <SelectItem key={s.id} value={s.id}>{s.name}</SelectItem>
                            ))}
                        </SelectContent>
                    </Select>
                </div>
                <div className="space-y-2">
                    <Label htmlFor="remarks">Remarks</Label>
                    <Input id="remarks" name="remarks" placeholder="Optional notes" />
                </div>
            </div>

            <div className="space-y-4 border rounded p-4">
                <div className="flex justify-between items-center">
                    <h3 className="font-medium">Order Items</h3>
                    <Button type="button" variant="outline" size="sm" onClick={addItem}>
                        <Plus className="mr-2 h-4 w-4" /> Add Item
                    </Button>
                </div>

                <div className="space-y-2">
                    {items.map((item, index) => (
                        <div key={index} className="flex gap-2 items-end">
                            <div className="flex-1">
                                <Label>Product</Label>
                                <Select value={item.productId} onValueChange={(val) => updateItem(index, 'productId', val)}>
                                    <SelectTrigger>
                                        <SelectValue placeholder="Select Product" />
                                    </SelectTrigger>
                                    <SelectContent>
                                        {products.map(p => (
                                            <SelectItem key={p.id} value={p.id}>{p.name}</SelectItem>
                                        ))}
                                    </SelectContent>
                                </Select>
                            </div>
                            <div className="w-24">
                                <Label>Qty</Label>
                                <Input
                                    type="number"
                                    min="1"
                                    value={item.quantity}
                                    onChange={(e) => updateItem(index, 'quantity', parseFloat(e.target.value))}
                                />
                            </div>
                            <div className="w-32">
                                <Label>Cost</Label>
                                <Input
                                    type="number"
                                    min="0"
                                    step="0.01"
                                    value={item.unitCost}
                                    onChange={(e) => updateItem(index, 'unitCost', parseFloat(e.target.value))}
                                />
                            </div>
                            <div className="w-32">
                                <Label>Total</Label>
                                <div className="h-10 px-3 py-2 border rounded bg-muted text-right">
                                    {(item.quantity * item.unitCost).toFixed(2)}
                                </div>
                            </div>
                            <Button type="button" variant="ghost" size="icon" className="text-destructive mb-0.5" onClick={() => removeItem(index)}>
                                <Trash2 className="h-4 w-4" />
                            </Button>
                        </div>
                    ))}
                </div>
                {items.length === 0 && (
                    <div className="text-center text-muted-foreground py-4">No items added.</div>
                )}
            </div>

            <div className="flex justify-between items-center border-t pt-4">
                <div className="text-xl font-bold">
                    Total: {totalAmount.toFixed(2)}
                </div>
                <Button type="submit" disabled={loading || items.length === 0}>
                    {loading ? "Creating..." : "Create Order"}
                </Button>
            </div>
        </form>
    )
}
