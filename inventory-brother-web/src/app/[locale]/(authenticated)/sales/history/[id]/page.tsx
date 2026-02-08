import { getSaleDetails } from "@/actions/sales"
import { notFound } from "next/navigation"
import { Badge } from "@/components/ui/badge"
import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow
} from "@/components/ui/table"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"

export default async function SaleDetailsPage({ params }: { params: { id: string } }) {
    const { id } = await params
    const { sale, items } = await getSaleDetails(id)

    if (!sale) return notFound()

    return (
        <div className="space-y-6">
            <div className="flex justify-between items-center">
                <h1 className="text-3xl font-bold">Sale Details: {sale.invoiceNo}</h1>
                <Badge variant={sale.status === 'Completed' ? 'default' : 'destructive'}>
                    {sale.status}
                </Badge>
            </div>

            <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                <Card>
                    <CardHeader>
                        <CardTitle>Sale Information</CardTitle>
                    </CardHeader>
                    <CardContent className="space-y-2">
                        <div className="flex justify-between text-sm">
                            <span className="text-muted-foreground">Invoice No:</span>
                            <span className="font-mono font-bold">{sale.invoiceNo}</span>
                        </div>
                        <div className="flex justify-between text-sm">
                            <span className="text-muted-foreground">Date:</span>
                            <span>{new Date(sale.saleDate || Date.now()).toLocaleString()}</span>
                        </div>
                        <div className="flex justify-between text-sm">
                            <span className="text-muted-foreground">Payment Method:</span>
                            <span>{sale.paymentMethod}</span>
                        </div>
                    </CardContent>
                </Card>

                <Card>
                    <CardHeader>
                        <CardTitle>Financial Summary</CardTitle>
                    </CardHeader>
                    <CardContent className="space-y-2">
                        <div className="flex justify-between text-sm">
                            <span className="text-muted-foreground">Subtotal:</span>
                            <span>${sale.totalAmount?.toFixed(2)}</span>
                        </div>
                        <div className="flex justify-between text-sm">
                            <span className="text-muted-foreground">Tax:</span>
                            <span>+${sale.tax?.toFixed(2)}</span>
                        </div>
                        <div className="flex justify-between text-sm">
                            <span className="text-muted-foreground">Discount:</span>
                            <span>-${sale.discount?.toFixed(2)}</span>
                        </div>
                        <div className="flex justify-between font-bold border-t pt-2">
                            <span>Net Total:</span>
                            <span>${sale.netAmount?.toFixed(2)}</span>
                        </div>
                    </CardContent>
                </Card>
            </div>

            <div className="border rounded-md">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead>Product</TableHead>
                            <TableHead className="text-right">Quantity</TableHead>
                            <TableHead className="text-right">Price</TableHead>
                            <TableHead className="text-right">Total</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {items.map((item) => (
                            <TableRow key={item.id}>
                                <TableCell>{item.productName}</TableCell>
                                <TableCell className="text-right">{item.quantity}</TableCell>
                                <TableCell className="text-right">${item.unitPrice?.toFixed(2)}</TableCell>
                                <TableCell className="text-right">${item.total?.toFixed(2)}</TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </div>
        </div>
    )
}
