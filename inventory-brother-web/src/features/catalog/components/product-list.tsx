'use client'

import { useTranslations } from "next-intl"

import { Product } from "@/db/schema"
import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow,
} from "@/components/ui/table"
import { Button } from "@/components/ui/button"
import { Edit, Trash2, Image as ImageIcon } from "lucide-react"
import { deleteProduct } from "@/actions/products"
import { ProductDialog } from "./product-dialog"
import { useState } from "react"
import { Brand, Unit, Category } from "@/db/schema"

interface ProductListProps {
    initialProducts: Product[]
    brands: Brand[]
    units: Unit[]
    categories: Category[]
}

export function ProductList({ initialProducts, brands, units, categories }: ProductListProps) {
    const t = useTranslations("Catalog")
    const [products] = useState(initialProducts)

    const handleDelete = async (id: string) => {
        if (confirm(t("deleteProductConfirm"))) {
            await deleteProduct(id)
        }
    }

    return (
        <div className="space-y-4">
            <div className="flex justify-between items-center">
                <h2 className="text-xl font-semibold">{t("productsTitle")}</h2>
                <ProductDialog brands={brands} units={units} categories={categories} />
            </div>

            <div className="border rounded-md">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead>{t("image")}</TableHead>
                            <TableHead>{t("code")}</TableHead>
                            <TableHead>{t("name")}</TableHead>
                            <TableHead>{t("price")}</TableHead>
                            <TableHead>{t("stock")}</TableHead>
                            <TableHead className="text-right">{t("actions")}</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {initialProducts.map((product) => (
                            <TableRow key={product.id}>
                                <TableCell>
                                    {product.image ? (
                                        // eslint-disable-next-line @next/next/no-img-element
                                        <img src={product.image} alt={product.name} className="h-10 w-10 object-cover rounded" />
                                    ) : (
                                        <div className="h-10 w-10 bg-muted flex items-center justify-center rounded">
                                            <ImageIcon className="h-4 w-4 text-muted-foreground" />
                                        </div>
                                    )}
                                </TableCell>
                                <TableCell className="font-medium">{product.id}</TableCell>
                                <TableCell>{product.name}</TableCell>
                                <TableCell>{product.salePrice}</TableCell>
                                <TableCell>{product.stockQuantity}</TableCell>
                                <TableCell className="text-right space-x-2">
                                    <Button variant="ghost" size="icon">
                                        <Edit className="h-4 w-4" />
                                    </Button>
                                    <Button
                                        variant="ghost"
                                        size="icon"
                                        className="text-destructive"
                                        onClick={() => handleDelete(product.id)}
                                    >
                                        <Trash2 className="h-4 w-4" />
                                    </Button>
                                </TableCell>
                            </TableRow>
                        ))}
                        {initialProducts.length === 0 && (
                            <TableRow>
                                <TableCell colSpan={6} className="text-center py-4">
                                    {t("noProducts")}
                                </TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </div>
        </div>
    )
}
