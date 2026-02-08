'use client'

import { Supplier } from "@/db/schema"
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
import { deleteSupplier } from "@/actions/supplier"
import { SupplierDialog } from "./supplier-dialog"
import { useState } from "react"

interface SupplierListProps {
    initialSuppliers: Supplier[]
}

export function SupplierList({ initialSuppliers }: SupplierListProps) {
    const [suppliers] = useState(initialSuppliers)

    const handleDelete = async (id: string) => {
        if (confirm("Are you sure you want to delete this supplier?")) {
            await deleteSupplier(id)
        }
    }

    return (
        <div className="space-y-4">
            <div className="flex justify-between items-center">
                <h2 className="text-xl font-semibold">Suppliers</h2>
                <SupplierDialog />
            </div>

            <div className="border rounded-md">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead>Name</TableHead>
                            <TableHead>Contact Person</TableHead>
                            <TableHead>Mobile</TableHead>
                            <TableHead>Email</TableHead>
                            <TableHead>Status</TableHead>
                            <TableHead className="text-right">Actions</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {initialSuppliers.map((supplier) => (
                            <TableRow key={supplier.id}>
                                <TableCell className="font-medium">{supplier.name}</TableCell>
                                <TableCell>{supplier.contactPerson}</TableCell>
                                <TableCell>{supplier.mobile}</TableCell>
                                <TableCell>{supplier.email}</TableCell>
                                <TableCell>{supplier.status}</TableCell>
                                <TableCell className="text-right space-x-2">
                                    <Button variant="ghost" size="icon">
                                        <Edit className="h-4 w-4" />
                                    </Button>
                                    <Button
                                        variant="ghost"
                                        size="icon"
                                        className="text-destructive"
                                        onClick={() => handleDelete(supplier.id)}
                                    >
                                        <Trash2 className="h-4 w-4" />
                                    </Button>
                                </TableCell>
                            </TableRow>
                        ))}
                        {initialSuppliers.length === 0 && (
                            <TableRow>
                                <TableCell colSpan={6} className="text-center py-4">
                                    No suppliers found.
                                </TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </div>
        </div>
    )
}
