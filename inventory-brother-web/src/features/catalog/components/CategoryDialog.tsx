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

interface CategoryDialogProps {
    categories: Category[]
}

export function CategoryDialog({ categories }: CategoryDialogProps) {
    const [open, setOpen] = useState(false)

    const handleSubmit = async (formData: FormData) => {
        await createCategory(formData)
        setOpen(false)
    }

    return (
        <Dialog open={open} onOpenChange={setOpen}>
            <DialogTrigger asChild>
                <Button>
                    <Plus className="mr-2 h-4 w-4" />
                    Add Category
                </Button>
            </DialogTrigger>
            <DialogContent>
                <DialogHeader>
                    <DialogTitle>Add New Category</DialogTitle>
                </DialogHeader>
                <form action={handleSubmit} className="space-y-4">
                    <div className="space-y-2">
                        <Label htmlFor="name">Category Name</Label>
                        <Input id="name" name="name" placeholder="Enter category name" required />
                    </div>

                    <div className="space-y-2">
                        <Label htmlFor="parentId">Parent Category</Label>
                        <Select name="parentId">
                            <SelectTrigger>
                                <SelectValue placeholder="Select parent (optional)" />
                            </SelectTrigger>
                            <SelectContent>
                                <SelectItem value="0">None</SelectItem>
                                {categories.map(c => (
                                    <SelectItem key={c.id} value={c.id.toString()}>
                                        {c.name}
                                    </SelectItem>
                                ))}
                            </SelectContent>
                        </Select>
                    </div>

                    <div className="flex justify-end">
                        <Button type="submit">Save</Button>
                    </div>
                </form>
            </DialogContent>
        </Dialog>
    )
}
