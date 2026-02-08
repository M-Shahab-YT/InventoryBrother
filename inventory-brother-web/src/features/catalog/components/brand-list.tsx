'use client'

import { useTranslations } from "next-intl"

import { Brand } from "@/db/schema"
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
import { deleteBrand } from "@/actions/catalog"
import { BrandDialog } from "./brand-dialog"
import { useState } from "react"

interface BrandListProps {
    initialBrands: Brand[]
}

export function BrandList({ initialBrands }: BrandListProps) {
    const t = useTranslations("Catalog")
    const [brands, setBrands] = useState(initialBrands)

    // In a real app with server actions revalidating path, 
    // the props would update automatically if this component is re-rendered by parent.
    // For immediate optimistic UI or simple updates, we might use state or router.refresh().
    // Here we rely on the parent page passing fresh data after revalidation.

    const handleDelete = async (id: number) => {
        if (confirm(t("deleteBrandConfirm"))) {
            await deleteBrand(id)
        }
    }

    return (
        <div className="space-y-4">
            <div className="flex justify-between items-center">
                <h2 className="text-xl font-semibold">{t("brands")}</h2>
                <BrandDialog />
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
                        {initialBrands.map((brand) => (
                            <TableRow key={brand.id}>
                                <TableCell>{brand.id}</TableCell>
                                <TableCell>{brand.name}</TableCell>
                                <TableCell className="text-right space-x-2">
                                    <Button variant="ghost" size="icon">
                                        <Edit className="h-4 w-4" />
                                    </Button>
                                    <Button
                                        variant="ghost"
                                        size="icon"
                                        className="text-destructive"
                                        onClick={() => handleDelete(brand.id)}
                                    >
                                        <Trash2 className="h-4 w-4" />
                                    </Button>
                                </TableCell>
                            </TableRow>
                        ))}
                        {initialBrands.length === 0 && (
                            <TableRow>
                                <TableCell colSpan={3} className="text-center py-4">
                                    {t("noBrands")}
                                </TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </div>
        </div>
    )
}
