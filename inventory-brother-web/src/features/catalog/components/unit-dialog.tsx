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
import { createUnit } from "@/actions/catalog"
import { useState } from "react"
import { Plus } from "lucide-react"
import { useTranslations } from "next-intl"

export function UnitDialog() {
    const t = useTranslations("Catalog")
    const common = useTranslations("Common")
    const [open, setOpen] = useState(false)
    const [isLoading, setIsLoading] = useState(false)
    const [name, setName] = useState("")

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault()
        setIsLoading(true)

        try {
            const formData = new FormData()
            formData.append("name", name)
            await createUnit(formData)
            setOpen(false)
            setName("")
        } catch (error) {
            console.error("Failed to create unit:", error)
        } finally {
            setIsLoading(false)
        }
    }

    return (
        <Dialog open={open} onOpenChange={setOpen}>
            <DialogTrigger asChild>
                <Button>
                    <Plus className="mr-2 h-4 w-4" />
                    {t("addUnit")}
                </Button>
            </DialogTrigger>
            <DialogContent>
                <DialogHeader>
                    <DialogTitle>{t("addNewUnit")}</DialogTitle>
                </DialogHeader>
                <form onSubmit={handleSubmit} className="space-y-4">
                    <div className="space-y-2">
                        <Label htmlFor="name">{t("unitName")}</Label>
                        <Input
                            id="name"
                            placeholder={t("enterUnitName")}
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                            required
                        />
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
