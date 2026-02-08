'use client'

import { useTranslations } from "next-intl"

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
import { UnitDialog } from "./unit-dialog"
import { useState } from "react"

interface UnitListProps {
    initialUnits: Unit[]
}

export function UnitList({ initialUnits }: UnitListProps) {
    const t = useTranslations("Catalog")
    const [units] = useState(initialUnits)

    const handleDelete = async (id: number) => {
        if (confirm(t("deleteUnitConfirm"))) {
            await deleteUnit(id)
        }
    }

    return (
        <div className="space-y-4">
            <div className="flex justify-between items-center">
                <h2 className="text-xl font-semibold">{t("units")}</h2>
                <UnitDialog />
            </div>

            <div className="border rounded-md">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead>{t("code")}</TableHead>
                            <TableHead>{t("name")}</TableHead>
                            <TableHead className="text-right">{t("actions")}</TableHead>
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
                                    {t("noUnits")}
                                </TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </div>
        </div>
    )
}
