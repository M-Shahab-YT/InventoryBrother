'use client'

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
import {
    Select,
    SelectContent,
    SelectItem,
    SelectTrigger,
    SelectValue,
} from "@/components/ui/select"
import { createCategory } from "@/actions/catalog"
import { useState } from "react"
import { Plus } from "lucide-react"
import { Category } from "@/db/schema"
import { useTranslations } from "next-intl"

interface CategoryDialogProps {
    categories: Category[]
}

export function CategoryDialog({ categories }: CategoryDialogProps) {
    const t = useTranslations("Catalog")
    const common = useTranslations("Common")
    const [open, setOpen] = useState(false)
    const [isLoading, setIsLoading] = useState(false)
    const [name, setName] = useState("")
    const [parentId, setParentId] = useState<string>("0")

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault()
        setIsLoading(true)

        try {
            const formData = new FormData()
            formData.append("name", name)
            formData.append("parentId", parentId)
            await createCategory(formData)
            setOpen(false)
            setName("")
            setParentId("0")
        } catch (error) {
            console.error("Failed to create category:", error)
        } finally {
            setIsLoading(false)
        }
    }

    return (
        <Dialog open={open} onOpenChange={setOpen}>
            <DialogTrigger asChild>
                <Button>
                    <Plus className="mr-2 h-4 w-4" />
                    {t("addCategory")}
                </Button>
            </DialogTrigger>
            <DialogContent>
                <DialogHeader>
                    <DialogTitle>{t("addNewCategory")}</DialogTitle>
                </DialogHeader>
                <form onSubmit={handleSubmit} className="space-y-4">
                    <div className="space-y-2">
                        <Label htmlFor="name">{t("categoryName")}</Label>
                        <Input
                            id="name"
                            placeholder={t("enterCategoryName")}
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                            required
                        />
                    </div>

                    <div className="space-y-2">
                        <Label htmlFor="parentId">{t("parentCategory")}</Label>
                        <Select value={parentId} onValueChange={setParentId}>
                            <SelectTrigger>
                                <SelectValue placeholder={t("selectParentOptional")} />
                            </SelectTrigger>
                            <SelectContent>
                                <SelectItem value="0">{t("none")}</SelectItem>
                                {categories.map(c => (
                                    <SelectItem key={c.id} value={c.id.toString()}>
                                        {c.name}
                                    </SelectItem>
                                ))}
                            </SelectContent>
                        </Select>
                    </div>

                    <div className="flex justify-end space-x-2">
                        <Button type="button" variant="outline" onClick={() => setOpen(false)}>
                            {common("cancel")}
                        </Button>
                        <Button type="submit" disabled={isLoading}>
                            {isLoading ? common("loading") : t("save")}
                        </Button>
                    </div>
                </form>
            </DialogContent>
        </Dialog>
    )
}
