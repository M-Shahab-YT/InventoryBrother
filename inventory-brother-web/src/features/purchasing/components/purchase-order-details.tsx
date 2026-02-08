'use client'

import { PurchaseOrder, PurchaseOrderItem, Warehouse } from "@/db/schema"
import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow,
} from "@/components/ui/table"
import { Button } from "@/components/ui/button"
import { Badge } from "@/components/ui/badge"
import { receiveOrder } from "@/actions/purchasing"
import { useState } from "react"
import {
    Dialog,
    DialogContent,
    DialogHeader,
    DialogTitle,
    DialogTrigger,
} from "@/components/ui/dialog"
import { Label } from "@/components/ui/label"
import {
    Select,
    SelectContent,
    SelectItem,
    SelectTrigger,
    SelectValue,
} from "@/components/ui/select"

interface PurchaseOrderDetailsProps {
    order: PurchaseOrder
    items: PurchaseOrderItem[]
    warehouses: Warehouse[]
}

export function PurchaseOrderDetails({ order, items, warehouses }: PurchaseOrderDetailsProps) {
    const [receiving, setReceiving] = useState(false)
    const [selectedWarehouse, setSelectedWarehouse] = useState<string>("")
    const [dialogOpen, setDialogOpen] = useState(false)

    const handleReceive = async () => {
        if (!selectedWarehouse) return
        setReceiving(true)
        try {
            await receiveOrder(order.id, parseInt(selectedWarehouse))
            setDialogOpen(false)
            alert("Order received and stock updated!")
        } catch (e) {
            alert("Error receiving order: " + e)
        } finally {
            setReceiving(false)
        }
    }

    return (
        <div className="space-y-6">
            <div className="flex justify-between items-start">
                <div>
                    <h2 className="text-2xl font-bold">{order.purchaseOrderNo}</h2>
                    <div className="text-muted-foreground">
                        Date: {order.orderDate ? new Date(order.orderDate).toLocaleDateString() : "-"}
                    </div>
                </div>
                <div className="flex gap-2">
                    <Badge variant={order.status === 'Received' ? 'default' : 'secondary'} className="text-lg">
                        {order.status}
                    </Badge>
                    {order.status === 'Ordered' && (
                        <Dialog open={dialogOpen} onOpenChange={setDialogOpen}>
                            <DialogTrigger asChild>
                                <Button>Receive Goods</Button>
                            </DialogTrigger>
                            <DialogContent>
                                <DialogHeader>
                                    <DialogTitle>Receive Order</DialogTitle>
                                </DialogHeader>
                                <div className="space-y-4 py-4">
                                    <div className="space-y-2">
                                        <Label>Select Destination Warehouse</Label>
                                        <Select onValueChange={setSelectedWarehouse}>
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
                                    <Button onClick={handleReceive} disabled={receiving || !selectedWarehouse} className="w-full">
                                        {receiving ? "Processing..." : "Confirm Receipt"}
                                    </Button>
                                </div>
                            </DialogContent>
                        </Dialog>
                    )}
                </div>
            </div>

            <div className="border rounded-md p-4 bg-muted/20">
                <div className="grid grid-cols-2 gap-4">
                    <div>
                        <span className="font-semibold">Supplier ID:</span> {order.supplierId}
                    </div>
                    <div>
                        <span className="font-semibold">Total Amount:</span> {order.totalAmount}
                    </div>
                    <div className="col-span-2">
                        <span className="font-semibold">Remarks:</span> {order.remarks || "-"}
                    </div>
                </div>
            </div>

            <div className="border rounded-md">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead>Product ID</TableHead>
                            <TableHead className="text-right">Quantity</TableHead>
                            <TableHead className="text-right">Unit Cost</TableHead>
                            <TableHead className="text-right">Total Cost</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {items.map((item) => (
                            <TableRow key={item.id}>
                                <TableCell>{item.productId}</TableCell>
                                <TableCell className="text-right">{item.quantity}</TableCell>
                                <TableCell className="text-right">{item.unitCost}</TableCell>
                                <TableCell className="text-right">{item.totalCost}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </div>
        </div>
    )
}
