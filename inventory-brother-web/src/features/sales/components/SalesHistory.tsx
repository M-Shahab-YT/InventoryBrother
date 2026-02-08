'use client'

import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow
} from "@/components/ui/table"
import { Badge } from "@/components/ui/badge"
import { Button } from "@/components/ui/button"
import { Eye } from "lucide-react"
import { Link } from "@/i18n/navigation"

interface SalesHistoryProps {
    sales: any[]
}

export function SalesHistory({ sales }: SalesHistoryProps) {
    return (
        <div className="border rounded-md">
            <Table>
                <TableHeader>
                    <TableRow>
                        <TableHead>Invoice #</TableHead>
                        <TableHead>Customer</TableHead>
                        <TableHead>Date</TableHead>
                        <TableHead>Status</TableHead>
                        <TableHead className="text-right">Amount</TableHead>
                        <TableHead className="text-right">Actions</TableHead>
                    </TableRow>
                </TableHeader>
                <TableBody>
                    {sales.map((sale) => (
                        <TableRow key={sale.id}>
                            <TableCell className="font-mono font-bold">{sale.invoiceNo}</TableCell>
                            <TableCell>{sale.customerName || "Walk-in"}</TableCell>
                            <TableCell>{new Date(sale.saleDate).toLocaleDateString()}</TableCell>
                            <TableCell>
                                <Badge variant={sale.status === 'Completed' ? 'default' : 'destructive'}>
                                    {sale.status}
                                </Badge>
                            </TableCell>
                            <TableCell className="text-right font-bold">${sale.netAmount?.toFixed(2)}</TableCell>
                            <TableCell className="text-right">
                                <Link href={`/dashboard/sales/history/${sale.id}`}>
                                    <Button variant="ghost" size="icon">
                                        <Eye className="h-4 w-4" />
                                    </Button>
                                </Link>
                            </TableCell>
                        </TableRow>
                    ))}
                    {sales.length === 0 && (
                        <TableRow>
                            <TableCell colSpan={6} className="text-center py-10 text-muted-foreground">
                                No sales history found.
                            </TableCell>
                        </TableRow>
                    )}
                </TableBody>
            </Table>
        </div>
    )
}
