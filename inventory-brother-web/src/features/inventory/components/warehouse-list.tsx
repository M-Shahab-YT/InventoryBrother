'use client'

import { Warehouse } from "@/db/schema"
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
import { deleteWarehouse } from "@/actions/warehouse"
import { WarehouseDialog } from "./warehouse-dialog"
import { useState } from "react"

interface WarehouseListProps {
    initialWarehouses: Warehouse[]
}

export function WarehouseList({ initialWarehouses }: WarehouseListProps) {
    const [warehouses] = useState(initialWarehouses)

    const handleDelete = async (id: number) => {
        if (confirm("Are you sure you want to delete this warehouse?")) {
            await deleteWarehouse(id)
        }
    }

    return (
        <div className="space-y-4">
            <div className="flex justify-between items-center">
                <h2 className="text-xl font-semibold">Warehouses</h2>
                <WarehouseDialog />
            </div>

            <div className="border rounded-md">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead>ID</TableHead>
                            <TableHead>Name</TableHead>
                            <TableHead>Address</TableHead>
                            <TableHead>Status</TableHead>
                            <TableHead className="text-right">Actions</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {initialWarehouses.map((warehouse) => (
                            <TableRow key={warehouse.id}>
                                <TableCell>{warehouse.id}</TableCell>
                                <TableCell>{warehouse.name}</TableCell>
                                <TableCell>{warehouse.address}</TableCell>
                                <TableCell>{warehouse.status}</TableCell>
                                <TableCell className="text-right space-x-2">
                                    <Button variant="ghost" size="icon">
                                        <Edit className="h-4 w-4" />
                                    </Button>
                                    <Button
                                        variant="ghost"
                                        size="icon"
                                        className="text-destructive"
                                        onClick={() => handleDelete(warehouse.id)}
                                    >
                                        <Trash2 className="h-4 w-4" />
                                    </Button>
                                </TableCell>
                            </TableRow>
                        ))}
                        {initialWarehouses.length === 0 && (
                            <TableRow>
                                <TableCell colSpan={5} className="text-center py-4">
                                    No warehouses found.
                                </TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </div>
        </div>
    )
}
