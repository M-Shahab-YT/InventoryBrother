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
import { createCustomer, updateCustomer } from "@/actions/customer"
import { useState } from "react"
import { Plus } from "lucide-react"
import { Customer } from "@/db/schema"
import {
    Select,
    SelectContent,
    SelectItem,
    SelectTrigger,
    SelectValue,
} from "@/components/ui/select"

interface CustomerDialogProps {
    customer?: Customer
    trigger?: React.ReactNode
}

export function CustomerDialog({ customer, trigger }: CustomerDialogProps) {
    const [open, setOpen] = useState(false)

    const handleSubmit = async (formData: FormData) => {
        if (customer) {
            await updateCustomer(customer.id, formData)
        } else {
            await createCustomer(formData)
        }
        setOpen(false)
    }

    return (
        <Dialog open={open} onOpenChange={setOpen}>
            <DialogTrigger asChild>
                {trigger || (
                    <Button>
                        <Plus className="mr-2 h-4 w-4" />
                        Add Customer
                    </Button>
                )}
            </DialogTrigger>
            <DialogContent className="max-w-lg">
                <DialogHeader>
                    <DialogTitle>{customer ? 'Edit Customer' : 'Add New Customer'}</DialogTitle>
                </DialogHeader>
                <form action={handleSubmit} className="space-y-4">
                    <div className="grid grid-cols-2 gap-4">
                        <div className="space-y-2">
                            <Label htmlFor="name">Customer Name</Label>
                            <Input id="name" name="name" defaultValue={customer?.name} required />
                        </div>
                        <div className="space-y-2">
                            <Label htmlFor="type">Type</Label>
                            <Select name="type" defaultValue={customer?.type || "Retail"}>
                                <SelectTrigger>
                                    <SelectValue />
                                </SelectTrigger>
                                <SelectContent>
                                    <SelectItem value="Retail">Retail</SelectItem>
                                    <SelectItem value="Wholesale">Wholesale</SelectItem>
                                </SelectContent>
                            </Select>
                        </div>
                    </div>

                    <div className="grid grid-cols-2 gap-4">
                        <div className="space-y-2">
                            <Label htmlFor="mobile">Mobile</Label>
                            <Input id="mobile" name="mobile" defaultValue={customer?.mobile || ""} />
                        </div>
                        <div className="space-y-2">
                            <Label htmlFor="email">Email</Label>
                            <Input id="email" name="email" type="email" defaultValue={customer?.email || ""} />
                        </div>
                    </div>

                    <div className="space-y-2">
                        <Label htmlFor="contactPerson">Contact Person</Label>
                        <Input id="contactPerson" name="contactPerson" defaultValue={customer?.contactPerson || ""} />
                    </div>

                    <div className="space-y-2">
                        <Label htmlFor="address">Address</Label>
                        <Input id="address" name="address" defaultValue={customer?.address || ""} />
                    </div>

                    <div className="space-y-2">
                        <Label htmlFor="areaCode">Area Code</Label>
                        <Input id="areaCode" name="areaCode" defaultValue={customer?.areaCode || ""} />
                    </div>

                    <div className="flex justify-end pt-2">
                        <Button type="submit">{customer ? 'Update' : 'Save'} Customer</Button>
                    </div>
                </form>
            </DialogContent>
        </Dialog>
    )
}
