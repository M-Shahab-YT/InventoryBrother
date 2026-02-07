'use client'

import { Unit } from "@/db/schema"
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
import { deleteUnit } from "@/actions/catalog"
import { UnitDialog } from "./UnitDialog"
import { useState } from "react"

interface UnitListProps {
    initialUnits: Unit[]
}

export function UnitList({ initialUnits }: UnitListProps) {
    const [units] = useState(initialUnits)

    const handleDelete = async (id: number) => {
        if (confirm("Are you sure you want to delete this unit?")) {
            await deleteUnit(id)
        }
    }

    return (
        <div className="space-y-4">
            <div className="flex justify-between items-center">
                <h2 className="text-xl font-semibold">Units of Measurement</h2>
                <UnitDialog />
            </div>

            <div className="border rounded-md">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead>ID</TableHead>
                            <TableHead>Name</TableHead>
                            <TableHead className="text-right">Actions</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {initialUnits.map((unit) => (
                            <TableRow key={unit.id}>
                                <TableCell>{unit.id}</TableCell>
                                <TableCell>{unit.name}</TableCell>
                                <TableCell className="text-right space-x-2">
                                    <Button variant="ghost" size="icon">
                                        <Edit className="h-4 w-4" />
                                    </Button>
                                    <Button
                                        variant="ghost"
                                        size="icon"
                                        className="text-destructive"
                                        onClick={() => handleDelete(unit.id)}
                                    >
                                        <Trash2 className="h-4 w-4" />
                                    </Button>
                                </TableCell>
                            </TableRow>
                        ))}
                        {initialUnits.length === 0 && (
                            <TableRow>
                                <TableCell colSpan={3} className="text-center py-4">
                                    No units found.
                                </TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </div>
        </div>
    )
}
