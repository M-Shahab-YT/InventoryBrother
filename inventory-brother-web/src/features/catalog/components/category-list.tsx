'use client'

import { useTranslations } from "next-intl"

import { Category } from "@/db/schema"
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
import { deleteCategory } from "@/actions/catalog"
import { CategoryDialog } from "./category-dialog"
import { useState } from "react"

interface CategoryListProps {
    initialCategories: Category[]
}

export function CategoryList({ initialCategories }: CategoryListProps) {
    const t = useTranslations("Catalog")
    // eslint-disable-next-line @typescript-eslint/no-unused-vars
    const [categories, setCategories] = useState(initialCategories)

    const handleDelete = async (id: number) => {
        if (confirm(t("deleteCategoryConfirm"))) {
            await deleteCategory(id)
        }
    }

    const getParentName = (parentId: number | null) => {
        if (!parentId) return "-"
        return initialCategories.find(c => c.id === parentId)?.name || parentId
    }

    return (
        <div className="space-y-4">
            <div className="flex justify-between items-center">
                <h2 className="text-xl font-semibold">{t("categories")}</h2>
                <CategoryDialog categories={initialCategories} />
            </div>

            <div className="border rounded-md">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead>{t("code")}</TableHead>
                            <TableHead>{t("name")}</TableHead>
                            <TableHead>{t("parentCategory")}</TableHead>
                            <TableHead className="text-right">{t("actions")}</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {initialCategories.map((category) => (
                            <TableRow key={category.id}>
                                <TableCell>{category.id}</TableCell>
                                <TableCell>{category.name}</TableCell>
                                <TableCell className="text-muted-foreground">
                                    {getParentName(category.parentId)}
                                </TableCell>
                                <TableCell className="text-right space-x-2">
                                    <Button variant="ghost" size="icon">
                                        <Edit className="h-4 w-4" />
                                    </Button>
                                    <Button
                                        variant="ghost"
                                        size="icon"
                                        className="text-destructive"
                                        onClick={() => handleDelete(category.id)}
                                    >
                                        <Trash2 className="h-4 w-4" />
                                    </Button>
                                </TableCell>
                            </TableRow>
                        ))}
                        {initialCategories.length === 0 && (
                            <TableRow>
                                <TableCell colSpan={4} className="text-center py-4">
                                    {t("noCategories")}
                                </TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </div>
        </div>
    )
}
