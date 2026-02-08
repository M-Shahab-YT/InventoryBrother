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
import { createSupplier } from "@/actions/supplier"
import { useState } from "react"
import { Plus } from "lucide-react"

export function SupplierDialog() {
    const [open, setOpen] = useState(false)

    const handleSubmit = async (formData: FormData) => {
        await createSupplier(formData)
        setOpen(false)
    }

    return (
        <Dialog open={open} onOpenChange={setOpen}>
            <DialogTrigger asChild>
                <Button>
                    <Plus className="mr-2 h-4 w-4" />
                    Add Supplier
                </Button>
            </DialogTrigger>
            <DialogContent className="max-w-md">
                <DialogHeader>
                    <DialogTitle>Add New Supplier</DialogTitle>
                </DialogHeader>
                <form action={handleSubmit} className="space-y-4">
                    <div className="space-y-2">
                        <Label htmlFor="name">Supplier Name</Label>
                        <Input id="name" name="name" placeholder="Business Name" required />
                    </div>

                    <div className="grid grid-cols-2 gap-4">
                        <div className="space-y-2">
                            <Label htmlFor="contactPerson">Contact Person</Label>
                            <Input id="contactPerson" name="contactPerson" placeholder="Name" />
                        </div>
                        <div className="space-y-2">
                            <Label htmlFor="mobile">Mobile</Label>
                            <Input id="mobile" name="mobile" placeholder="Phone" />
                        </div>
                    </div>

                    <div className="space-y-2">
                        <Label htmlFor="email">Email</Label>
                        <Input id="email" name="email" type="email" placeholder="Email address" />
                    </div>

                    <div className="space-y-2">
                        <Label htmlFor="address">Address</Label>
                        <Input id="address" name="address" placeholder="Location" />
                    </div>

                    <div className="space-y-2">
                        <Label htmlFor="openingBalance">Opening Balance</Label>
                        <Input type="number" step="0.01" id="openingBalance" name="openingBalance" defaultValue="0" />
                    </div>

                    <div className="flex justify-end pt-2">
                        <Button type="submit">Save Supplier</Button>
                    </div>
                </form>
            </DialogContent>
        </Dialog>
    )
}
