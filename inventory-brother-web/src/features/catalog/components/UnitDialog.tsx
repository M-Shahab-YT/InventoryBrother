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

export function UnitDialog() {
    const [open, setOpen] = useState(false)

    const handleSubmit = async (formData: FormData) => {
        await createUnit(formData)
        setOpen(false)
    }

    return (
        <Dialog open={open} onOpenChange={setOpen}>
            <DialogTrigger asChild>
                <Button>
                    <Plus className="mr-2 h-4 w-4" />
                    Add Unit
                </Button>
            </DialogTrigger>
            <DialogContent>
                <DialogHeader>
                    <DialogTitle>Add New Unit</DialogTitle>
                </DialogHeader>
                <form action={handleSubmit} className="space-y-4">
                    <div className="space-y-2">
                        <Label htmlFor="name">Unit Name</Label>
                        <Input id="name" name="name" placeholder="Enter unit name (e.g., kg, pcs)" required />
                    </div>
                    <div className="flex justify-end">
                        <Button type="submit">Save</Button>
                    </div>
                </form>
            </DialogContent>
        </Dialog>
    )
}
