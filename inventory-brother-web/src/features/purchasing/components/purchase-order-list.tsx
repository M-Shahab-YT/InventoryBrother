'use client'

import { PurchaseOrder, Supplier } from "@/db/schema"
import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow,
} from "@/components/ui/table"
import { Button } from "@/components/ui/button"
import { Eye } from "lucide-react"
import { Link } from "@/i18n/navigation"

interface PurchaseOrderListProps {
    initialOrders: (PurchaseOrder & { supplier?: Supplier | null })[]
    // We might need to join supplier name in the server action or fetch separately.
    // For now assuming we pass data with supplier name attached or look it up.
    // Actually, let's keep it simple: just list IDs or fetch supplier map.
    suppliers: Supplier[]
}

export function PurchaseOrderList({ initialOrders, suppliers }: PurchaseOrderListProps) {

    const getSupplierName = (id: string | null) => {
        return suppliers.find(s => s.id === id)?.name || "Unknown"
    }

    return (
        <div className="space-y-4">
            <div className="flex justify-between items-center">
                <h2 className="text-xl font-semibold">Purchase Orders</h2>
                <Link href="/dashboard/purchasing/orders/new">
                    <Button>Create Order</Button>
                </Link>
            </div>

            <div className="border rounded-md">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead>PO Number</TableHead>
                            <TableHead>Supplier</TableHead>
                            <TableHead>Date</TableHead>
                            <TableHead>Status</TableHead>
                            <TableHead className="text-right">Total Amount</TableHead>
                            <TableHead className="text-right">Actions</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {initialOrders.map((po) => (
                            <TableRow key={po.id}>
                                <TableCell className="font-medium">{po.purchaseOrderNo}</TableCell>
                                <TableCell>{getSupplierName(po.supplierId)}</TableCell>
                                <TableCell>{po.orderDate ? new Date(po.orderDate).toLocaleDateString() : "-"}</TableCell>
                                <TableCell>
                                    <span className={`px-2 py-1 rounded text-xs ${po.status === 'Received' ? 'bg-green-100 text-green-800' :
                                            po.status === 'Ordered' ? 'bg-blue-100 text-blue-800' :
                                                'bg-gray-100'
                                        }`}>
                                        {po.status}
                                    </span>
                                </TableCell>
                                <TableCell className="text-right">{po.totalAmount}</TableCell>
                                <TableCell className="text-right space-x-2">
                                    <Link href={`/dashboard/purchasing/orders/${po.id}`}>
                                        <Button variant="ghost" size="icon">
                                            <Eye className="h-4 w-4" />
                                        </Button>
                                    </Link>
                                </TableCell>
                            </TableRow>
                        ))}
                        {initialOrders.length === 0 && (
                            <TableRow>
                                <TableCell colSpan={6} className="text-center py-4">
                                    No orders found.
                                </TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </div>
        </div>
    )
}
