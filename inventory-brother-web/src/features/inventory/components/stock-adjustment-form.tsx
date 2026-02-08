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
import { adjustStock } from "@/actions/warehouse"
import { Product, Warehouse } from "@/db/schema"
import { useState } from "react"
// import { toast } from "sonner" // If we had toast

interface StockAdjustmentFormProps {
    products: Product[]
    warehouses: Warehouse[]
}

export function StockAdjustmentForm({ products, warehouses }: StockAdjustmentFormProps) {
    const [loading, setLoading] = useState(false)

    const handleSubmit = async (formData: FormData) => {
        setLoading(true)
        try {
            await adjustStock(formData)
            alert("Stock adjusted successfully!")
            // Reset form?
        } catch (e) {
            alert("Failed to adjust stock: " + e)
        } finally {
            setLoading(false)
        }
    }

    return (
        <form action={handleSubmit} className="space-y-6 max-w-lg border p-6 rounded-md shadow-sm">
            <div className="space-y-2">
                <Label htmlFor="type">Adjustment Type</Label>
                <Select name="type" defaultValue="in">
                    <SelectTrigger>
                        <SelectValue />
                    </SelectTrigger>
                    <SelectContent>
                        <SelectItem value="in">Stock IN (Receive)</SelectItem>
                        <SelectItem value="out">Stock OUT (Issue)</SelectItem>
                    </SelectContent>
                </Select>
            </div>

            <div className="space-y-2">
                <Label htmlFor="warehouseId">Warehouse</Label>
                <Select name="warehouseId" required>
                    <SelectTrigger>
                        <SelectValue placeholder="Select Warehouse" />
                    </SelectTrigger>
                    <SelectContent>
                        {warehouses.map(w => (
                            <SelectItem key={w.id} value={w.id.toString()}>{w.name}</SelectItem>
                        ))}
                    </SelectContent>
                </Select>
            </div>

            <div className="space-y-2">
                <Label htmlFor="productId">Product</Label>
                <Select name="productId" required>
                    <SelectTrigger>
                        <SelectValue placeholder="Select Product" />
                    </SelectTrigger>
                    <SelectContent>
                        {products.map(p => (
                            <SelectItem key={p.id} value={p.id}>{p.name} ({p.id})</SelectItem>
                        ))}
                    </SelectContent>
                </Select>
            </div>

            <div className="grid grid-cols-2 gap-4">
                <div className="space-y-2">
                    <Label htmlFor="quantity">Quantity</Label>
                    <Input type="number" id="quantity" name="quantity" defaultValue="1" required min="0.01" step="0.01" />
                </div>
                <div className="space-y-2">
                    <Label htmlFor="batchNo">Batch No (Optional)</Label>
                    <Input id="batchNo" name="batchNo" placeholder="BATCH-..." />
                </div>
            </div>

            <Button type="submit" disabled={loading} className="w-full">
                {loading ? "Processing..." : "Submit Adjustment"}
            </Button>
        </form>
    )
}
