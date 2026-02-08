'use client'

import { useState, useEffect } from "react"
import { useForm } from "react-hook-form"
import { FinanceAccount, NewFinanceAccount } from "@/db/schema"
import { createAccount, updateAccount } from "@/actions/finance"
import { Button } from "@/components/ui/button"
import {
    Dialog,
    DialogContent,
    DialogHeader,
    DialogTitle,
    DialogFooter,
} from "@/components/ui/dialog"
import { useTranslations } from "next-intl"
import {
    Form,
    FormControl,
    FormField,
    FormItem,
    FormLabel,
    FormMessage,
} from "@/components/ui/form"
import { Input } from "@/components/ui/input"
import {
    Select,
    SelectContent,
    SelectItem,
    SelectTrigger,
    SelectValue,
} from "@/components/ui/select"

const ACCOUNT_TYPES = [
    "Asset",
    "Liability",
    "Equity",
    "Revenue",
    "Expense"
]

interface AccountDialogProps {
    open: boolean
    onOpenChange: (open: boolean) => void
    account?: FinanceAccount | null
    accounts: FinanceAccount[]
}

export function AccountDialog({ open, onOpenChange, account, accounts }: AccountDialogProps) {
    const t = useTranslations("Finance")
    const common = useTranslations("Common")
    const [loading, setLoading] = useState(false)

    const form = useForm<NewFinanceAccount>({
        defaultValues: {
            name: "",
            code: "",
            type: "Asset",
            parentId: null,
            description: "",
            storeId: 1,
        }
    })

    useEffect(() => {
        if (account) {
            form.reset({
                name: account.name,
                code: account.code || "",
                type: account.type,
                parentId: account.parentId,
                description: account.description || "",
            })
        } else {
            form.reset({
                name: "",
                code: "",
                type: "Asset",
                parentId: null,
                description: "",
                storeId: 1,
            })
        }
    }, [account, form])

    const onSubmit = async (values: NewFinanceAccount) => {
        setLoading(true)
        try {
            if (account) {
                await updateAccount(account.id, values)
            } else {
                await createAccount(values)
            }
            onOpenChange(false)
        } catch (error) {
            console.error(error)
            alert(t("errorSaving"))
        } finally {
            setLoading(false)
        }
    }

    return (
        <Dialog open={open} onOpenChange={onOpenChange}>
            <DialogContent>
                <DialogHeader>
                    <DialogTitle>{account ? t("editAccount") : t("addNewAccount")}</DialogTitle>
                </DialogHeader>
                <Form {...form}>
                    <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-4">
                        <div className="grid grid-cols-2 gap-4">
                            <FormField
                                control={form.control}
                                name="code"
                                render={({ field }) => (
                                    <FormItem>
                                        <FormLabel>{t("accountCode")}</FormLabel>
                                        <FormControl>
                                            <Input {...field} value={field.value || ""} placeholder="e.g. 1010" />
                                        </FormControl>
                                        <FormMessage />
                                    </FormItem>
                                )}
                            />
                            <FormField
                                control={form.control}
                                name="type"
                                render={({ field }) => (
                                    <FormItem>
                                        <FormLabel>{t("type")}</FormLabel>
                                        <Select onValueChange={field.onChange} defaultValue={field.value}>
                                            <FormControl>
                                                <SelectTrigger>
                                                    <SelectValue placeholder={t("selectType")} />
                                                </SelectTrigger>
                                            </FormControl>
                                            <SelectContent>
                                                {ACCOUNT_TYPES.map(type => (
                                                    <SelectItem key={type} value={type}>{t(type.toLowerCase() as any)}</SelectItem>
                                                ))}
                                            </SelectContent>
                                        </Select>
                                        <FormMessage />
                                    </FormItem>
                                )}
                            />
                        </div>
                        <FormField
                            control={form.control}
                            name="name"
                            render={({ field }) => (
                                <FormItem>
                                    <FormLabel>{t("accountName")}</FormLabel>
                                    <FormControl>
                                        <Input {...field} value={field.value || ""} placeholder="e.g. Cash in Hand" />
                                    </FormControl>
                                    <FormMessage />
                                </FormItem>
                            )}
                        />
                        <FormField
                            control={form.control}
                            name="parentId"
                            render={({ field }) => (
                                <FormItem>
                                    <FormLabel>{t("parentAccount")}</FormLabel>
                                    <Select
                                        onValueChange={(val) => field.onChange(val === "none" ? null : val)}
                                        defaultValue={field.value || "none"}
                                    >
                                        <FormControl>
                                            <SelectTrigger>
                                                <SelectValue placeholder={t("selectParent")} />
                                            </SelectTrigger>
                                        </FormControl>
                                        <SelectContent>
                                            <SelectItem value="none">{t("noneRoot")}</SelectItem>
                                            {accounts.filter(a => a.id !== account?.id).map(a => (
                                                <SelectItem key={a.id} value={a.id}>{a.code} - {a.name}</SelectItem>
                                            ))}
                                        </SelectContent>
                                    </Select>
                                    <FormMessage />
                                </FormItem>
                            )}
                        />
                        <FormField
                            control={form.control}
                            name="description"
                            render={({ field }) => (
                                <FormItem>
                                    <FormLabel>{t("description")}</FormLabel>
                                    <FormControl>
                                        <Input {...field} value={field.value || ""} />
                                    </FormControl>
                                    <FormMessage />
                                </FormItem>
                            )}
                        />
                        <DialogFooter>
                            <Button type="button" variant="outline" onClick={() => onOpenChange(false)}>{common("cancel")}</Button>
                            <Button type="submit" disabled={loading}>
                                {loading ? common("loading") : t("saveAccount")}
                            </Button>
                        </DialogFooter>
                    </form>
                </Form>
            </DialogContent>
        </Dialog>
    )
}
