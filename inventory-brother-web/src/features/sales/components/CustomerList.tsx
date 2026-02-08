'use client'

import { Customer } from "@/db/schema"
import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow,
} from "@/components/ui/table"
import { Button } from "@/components/ui/button"
import { Edit, Trash2 } from "lucide-react"
import { deleteCustomer } from "@/actions/customer"
import { CustomerDialog } from "./CustomerDialog"
import { useState } from "react"
import { Badge } from "@/components/ui/badge"

interface CustomerListProps {
    initialCustomers: Customer[]
}

export function CustomerList({ initialCustomers }: CustomerListProps) {
    const [customers] = useState(initialCustomers)

    const handleDelete = async (id: string) => {
        if (confirm("Are you sure you want to delete this customer?")) {
            await deleteCustomer(id)
        }
        // Optimistic update or refresh handled by server action revalidatePath
    }

    return (
        <div className="space-y-4">
            <div className="flex justify-between items-center">
                <h2 className="text-xl font-semibold">Customers</h2>
                <CustomerDialog />
            </div>

            <div className="border rounded-md">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead>Name</TableHead>
                            <TableHead>Type</TableHead>
                            <TableHead>Mobile</TableHead>
                            <TableHead>Contact Person</TableHead>
                            <TableHead>Status</TableHead>
                            <TableHead className="text-right">Actions</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {initialCustomers.map((customer) => (
                            <TableRow key={customer.id}>
                                <TableCell className="font-medium">{customer.name}</TableCell>
                                <TableCell>
                                    <Badge variant={customer.type === 'Wholesale' ? 'secondary' : 'outline'}>
                                        {customer.type}
                                    </Badge>
                                </TableCell>
                                <TableCell>{customer.mobile}</TableCell>
                                <TableCell>{customer.contactPerson}</TableCell>
                                <TableCell>
                                    <span className={`text-sm ${customer.status === 'Active' ? 'text-green-600' : 'text-red-600'}`}>
                                        {customer.status}
                                    </span>
                                </TableCell>
                                <TableCell className="text-right space-x-2">
                                    <CustomerDialog customer={customer} trigger={
                                        <Button variant="ghost" size="icon">
                                            <Edit className="h-4 w-4" />
                                        </Button>
                                    } />
                                    <Button
                                        variant="ghost"
                                        size="icon"
                                        className="text-destructive"
                                        onClick={() => handleDelete(customer.id)}
                                    >
                                        <Trash2 className="h-4 w-4" />
                                    </Button>
                                </TableCell>
                            </TableRow>
                        ))}
                        {initialCustomers.length === 0 && (
                            <TableRow>
                                <TableCell colSpan={6} className="text-center py-4">
                                    No customers found.
                                </TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </div>
        </div>
    )
}
