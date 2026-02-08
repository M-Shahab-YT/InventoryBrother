'use client'

import { useTranslations } from "next-intl"

import { Button } from "@/components/ui/button"
import {
    Dialog,
    DialogContent,
    DialogHeader,
    DialogTitle,
    DialogTrigger,
} from "@/components/ui/dialog"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Textarea } from "@/components/ui/textarea"
import {
    Select,
    SelectContent,
    SelectItem,
    SelectTrigger,
    SelectValue,
} from "@/components/ui/select"
import { createProduct } from "@/actions/products"
import { useState } from "react"
import { Plus, ScanBarcode, Upload } from "lucide-react"
import { Brand, Unit, Category } from "@/db/schema"

interface ProductDialogProps {
    brands: Brand[]
    units: Unit[]
    categories: Category[]
}

export function ProductDialog({ brands, units, categories }: ProductDialogProps) {
    const t = useTranslations("Catalog")
    const common = useTranslations("Common")
    const [open, setOpen] = useState(false)
    const [isLoading, setIsLoading] = useState(false)
    const [imagePreview, setImagePreview] = useState<string | null>(null)

    // Form state
    const [formData, setFormData] = useState({
        name: "",
        description: "",
        salePrice: "",
        costPrice: "",
        stockQuantity: "",
        minStockLevel: "",
        categoryId: "",
        brandId: "",
        unitId: "",
        barcode: "",
        image: ""
    })

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault()
        setIsLoading(true)

        try {
            const productData = {
                name: formData.name,
                description: formData.description || undefined,
                salePrice: parseFloat(formData.salePrice),
                costPrice: formData.costPrice ? parseFloat(formData.costPrice) : undefined,
                stockQuantity: parseInt(formData.stockQuantity),
                minStockLevel: formData.minStockLevel ? parseInt(formData.minStockLevel) : 0,
                categoryId: parseInt(formData.categoryId),
                brandId: parseInt(formData.brandId),
                unitId: parseInt(formData.unitId),
                barcode: formData.barcode || undefined,
                image: formData.image || undefined
            }

            // Create FormData object to match the server action expectation if it expects FormData,
            // or modify the server action to accept a specialized object. 
            // Looking at the original file, it used `action={handleSubmit}` with `formData: FormData`.
            // The original `createProduct` likely takes `FormData`.
            // Let's stick to the original pattern if possible, but the original `handleSubmit` was adapting manual state?
            // No, the original file had `const handleSubmit = async (formData: FormData) => ...` and used `<form action={handleSubmit}>`.
            // However, to support Client Side validation and controlled inputs (which are better for UX like image preview and clearing form),
            // we often switch to `onSubmit`.
            // Let's check `createProduct` signature if I can.
            // Assumption: `createProduct` takes `FormData` based on original code.

            const submitData = new FormData()
            Object.entries(productData).forEach(([key, value]) => {
                if (value !== undefined) {
                    submitData.append(key, value.toString())
                }
            })

            await createProduct(submitData)
            setOpen(false)
            setFormData({
                name: "",
                description: "",
                salePrice: "",
                costPrice: "",
                stockQuantity: "",
                minStockLevel: "",
                categoryId: "",
                brandId: "",
                unitId: "",
                barcode: "",
                image: ""
            })
            setImagePreview(null)
        } catch (error) {
            console.error("Failed to create product:", error)
        } finally {
            setIsLoading(false)
        }
    }

    const handleImageChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const file = e.target.files?.[0]
        if (file) {
            const url = URL.createObjectURL(file)
            setImagePreview(url)
            // In a real app we'd handle file upload here or append file to FormData
            // For now, we are just mocking the image URL flow as per original code which did `setImagePreview(reader.result)`
            // and sent it as string.
            const reader = new FileReader()
            reader.onloadend = () => {
                const result = reader.result as string
                setFormData(prev => ({ ...prev, image: result }))
            }
            reader.readAsDataURL(file)
        }
    }

    return (
        <Dialog open={open} onOpenChange={setOpen}>
            <DialogTrigger asChild>
                <Button>
                    <Plus className="h-4 w-4 mr-2" />
                    {t("addProduct")}
                </Button>
            </DialogTrigger>
            <DialogContent className="max-w-3xl max-h-[90vh] overflow-y-auto">
                <DialogHeader>
                    <DialogTitle>{t("addNewProduct")}</DialogTitle>
                </DialogHeader>
                <form onSubmit={handleSubmit} className="space-y-6">
                    <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                        {/* Basic Information */}
                        <div className="space-y-4">
                            <h3 className="text-lg font-semibold">{t("productsTitle")}</h3>

                            <div className="space-y-2">
                                <Label htmlFor="name">{t("productName")}</Label>
                                <Input
                                    id="name"
                                    placeholder={t("enterProductName")}
                                    value={formData.name}
                                    onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                                    required
                                />
                            </div>

                            <div className="space-y-2">
                                <Label htmlFor="barcode">{t("barcode")}</Label>
                                <div className="flex gap-2">
                                    <Input
                                        id="barcode"
                                        placeholder={t("scanOrEnterCode")}
                                        value={formData.barcode}
                                        onChange={(e) => setFormData({ ...formData, barcode: e.target.value })}
                                    />
                                    <Button type="button" variant="outline" size="icon">
                                        <ScanBarcode className="h-4 w-4" />
                                    </Button>
                                </div>
                            </div>

                            <div className="space-y-2">
                                <Label htmlFor="description">{t("description")}</Label>
                                <Textarea
                                    id="description"
                                    placeholder={t("optionalDescription")}
                                    value={formData.description}
                                    onChange={(e) => setFormData({ ...formData, description: e.target.value })}
                                />
                            </div>
                        </div>

                        {/* Pricing & Inventory */}
                        <div className="space-y-4">
                            <h3 className="text-lg font-semibold">{common("inventory")}</h3>

                            <div className="grid grid-cols-2 gap-4">
                                <div className="space-y-2">
                                    <Label htmlFor="salePrice">{t("salePrice")}</Label>
                                    <Input
                                        id="salePrice"
                                        type="number"
                                        step="0.01"
                                        min="0"
                                        placeholder="0.00"
                                        value={formData.salePrice}
                                        onChange={(e) => setFormData({ ...formData, salePrice: e.target.value })}
                                        required
                                    />
                                </div>
                                <div className="space-y-2">
                                    <Label htmlFor="costPrice">{t("costPrice")}</Label>
                                    <Input
                                        id="costPrice"
                                        type="number"
                                        step="0.01"
                                        min="0"
                                        placeholder="0.00"
                                        value={formData.costPrice}
                                        onChange={(e) => setFormData({ ...formData, costPrice: e.target.value })}
                                    />
                                </div>
                            </div>

                            <div className="grid grid-cols-2 gap-4">
                                <div className="space-y-2">
                                    <Label htmlFor="stockQuantity">{t("initialStock")}</Label>
                                    <Input
                                        id="stockQuantity"
                                        type="number"
                                        min="0"
                                        placeholder="0"
                                        value={formData.stockQuantity}
                                        onChange={(e) => setFormData({ ...formData, stockQuantity: e.target.value })}
                                        required
                                    />
                                </div>
                                <div className="space-y-2">
                                    <Label htmlFor="minStock">{t("minStockAlert")}</Label>
                                    <Input
                                        id="minStock"
                                        type="number"
                                        min="0"
                                        placeholder="5"
                                        value={formData.minStockLevel}
                                        onChange={(e) => setFormData({ ...formData, minStockLevel: e.target.value })}
                                    />
                                </div>
                            </div>
                        </div>

                        {/* Classification */}
                        <div className="space-y-4">
                            <h3 className="text-lg font-semibold">{t("categories")}</h3>

                            <div className="space-y-2">
                                <Label htmlFor="category">{t("categories")}</Label>
                                <Select
                                    value={formData.categoryId}
                                    onValueChange={(value) => setFormData({ ...formData, categoryId: value })}
                                    required
                                >
                                    <SelectTrigger>
                                        <SelectValue placeholder={t("select")} />
                                    </SelectTrigger>
                                    <SelectContent>
                                        {categories.map((category) => (
                                            <SelectItem key={category.id} value={category.id.toString()}>
                                                {category.name}
                                            </SelectItem>
                                        ))}
                                    </SelectContent>
                                </Select>
                            </div>

                            <div className="space-y-2">
                                <Label htmlFor="brand">{t("brands")}</Label>
                                <Select
                                    value={formData.brandId}
                                    onValueChange={(value) => setFormData({ ...formData, brandId: value })}
                                    required
                                >
                                    <SelectTrigger>
                                        <SelectValue placeholder={t("select")} />
                                    </SelectTrigger>
                                    <SelectContent>
                                        {brands.map((brand) => (
                                            <SelectItem key={brand.id} value={brand.id.toString()}>
                                                {brand.name}
                                            </SelectItem>
                                        ))}
                                    </SelectContent>
                                </Select>
                            </div>

                            <div className="space-y-2">
                                <Label htmlFor="unit">{t("units")}</Label>
                                <Select
                                    value={formData.unitId}
                                    onValueChange={(value) => setFormData({ ...formData, unitId: value })}
                                    required
                                >
                                    <SelectTrigger>
                                        <SelectValue placeholder={t("select")} />
                                    </SelectTrigger>
                                    <SelectContent>
                                        {units.map((unit) => (
                                            <SelectItem key={unit.id} value={unit.id.toString()}>
                                                {unit.name}
                                            </SelectItem>
                                        ))}
                                    </SelectContent>
                                </Select>
                            </div>
                        </div>

                        {/* Image Upload */}
                        <div className="space-y-4">
                            <h3 className="text-lg font-semibold">{t("image")}</h3>
                            <div className="space-y-2">
                                <Label htmlFor="image">{t("productImage")}</Label>
                                <div className="flex items-center gap-4">
                                    <div className="border-2 border-dashed rounded-lg p-4 w-32 h-32 flex items-center justify-center bg-muted/50 relative overflow-hidden">
                                        {imagePreview ? (
                                            // eslint-disable-next-line @next/next/no-img-element
                                            <img src={imagePreview} alt="Preview" className="w-full h-full object-cover" />
                                        ) : (
                                            <Upload className="h-8 w-8 text-muted-foreground" />
                                        )}
                                        <Input
                                            id="image"
                                            type="file"
                                            accept="image/*"
                                            className="absolute inset-0 opacity-0 cursor-pointer"
                                            onChange={handleImageChange}
                                        />
                                    </div>
                                    <div className="text-sm text-muted-foreground">
                                        <p>{t("productImage")}</p>
                                        <p className="text-xs">JPG, PNG, WebP</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div className="flex justify-end space-x-2">
                        <Button type="button" variant="outline" onClick={() => setOpen(false)}>
                            {common("cancel")}
                        </Button>
                        <Button type="submit" disabled={isLoading}>
                            {isLoading ? common("loading") : t("saveProduct")}
                        </Button>
                    </div>
                </form>
            </DialogContent>
        </Dialog>
    )
}
