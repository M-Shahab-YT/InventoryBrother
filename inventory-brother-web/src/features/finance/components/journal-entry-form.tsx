'use client'

import { useState } from "react"
import { useForm, useFieldArray } from "react-hook-form"
import { FinanceAccount } from "@/db/schema"
import { createJournalEntry } from "@/actions/finance"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Plus, Trash2, AlertCircle } from "lucide-react"
import {
    Form,
    FormControl,
    FormField,
    FormItem,
    FormLabel,
    FormMessage,
} from "@/components/ui/form"
import {
    Select,
    SelectContent,
    SelectItem,
    SelectTrigger,
    SelectValue,
} from "@/components/ui/select"
import { Card, CardContent, CardHeader, CardTitle, CardFooter } from "@/components/ui/card"
import { Alert, AlertDescription, AlertTitle } from "@/components/ui/alert"
import { useTranslations } from "next-intl"

interface JournalEntryFormProps {
    accounts: FinanceAccount[]
}

export function JournalEntryForm({ accounts }: JournalEntryFormProps) {
    const [loading, setLoading] = useState(false)
    const [error, setError] = useState<string | null>(null)

    const form = useForm({
        defaultValues: {
            description: "",
            referenceNo: "",
            date: new Date().toISOString().split('T')[0],
            items: [
                { accountId: "", debit: 0, credit: 0, description: "" },
                { accountId: "", debit: 0, credit: 0, description: "" }
            ]
        }
    })

    const { fields, append, remove } = useFieldArray({
        control: form.control,
        name: "items"
    })

    const watchItems = form.watch("items")
    const totalDebit = watchItems.reduce((sum, item) => sum + (Number(item.debit) || 0), 0)
    const totalCredit = watchItems.reduce((sum, item) => sum + (Number(item.credit) || 0), 0)
    const isBalanced = Math.abs(totalDebit - totalCredit) < 0.01

    const onSubmit = async (values: any) => {
        if (!isBalanced) {
            setError("Entries must be balanced (Total Debit = Total Credit)")
            return
        }

        setLoading(true)
        setError(null)
        try {
            await createJournalEntry({
                ...values,
                date: new Date(values.date),
                items: values.items.map((item: any) => ({
                    ...item,
                    debit: Number(item.debit),
                    credit: Number(item.credit)
                }))
            })
            form.reset()
            alert("Journal Entry Posted Successfully")
        } catch (e: any) {
            setError(e.message)
        } finally {
            setLoading(false)
        }
    }

    return (
        <Card>
            <CardHeader>
                <CardTitle>New Journal Entry</CardTitle>
            </CardHeader>
            <CardContent>
                <Form {...form}>
                    <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-6">
                        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
                            <FormField
                                control={form.control}
                                name="date"
                                render={({ field }) => (
                                    <FormItem>
                                        <FormLabel>Date</FormLabel>
                                        <FormControl>
                                            <Input type="date" {...field} />
                                        </FormControl>
                                        <FormMessage />
                                    </FormItem>
                                )}
                            />
                            <FormField
                                control={form.control}
                                name="referenceNo"
                                render={({ field }) => (
                                    <FormItem>
                                        <FormLabel>Reference #</FormLabel>
                                        <FormControl>
                                            <Input {...field} placeholder="JV-001" />
                                        </FormControl>
                                        <FormMessage />
                                    </FormItem>
                                )}
                            />
                            <FormField
                                control={form.control}
                                name="description"
                                render={({ field }) => (
                                    <FormItem className="md:col-span-1">
                                        <FormLabel>Remarks</FormLabel>
                                        <FormControl>
                                            <Input {...field} placeholder="Overall transaction description" />
                                        </FormControl>
                                        <FormMessage />
                                    </FormItem>
                                )}
                            />
                        </div>

                        <div className="space-y-4">
                            <div className="flex justify-between items-center text-sm font-bold border-b pb-2">
                                <span className="flex-1">Account</span>
                                <span className="w-32">Debit</span>
                                <span className="w-32">Credit</span>
                                <span className="w-10"></span>
                            </div>
                            {fields.map((field, index) => (
                                <div key={field.id} className="flex gap-4 items-start">
                                    <div className="flex-1">
                                        <FormField
                                            control={form.control}
                                            name={`items.${index}.accountId`}
                                            render={({ field }) => (
                                                <FormItem>
                                                    <Select onValueChange={field.onChange} defaultValue={field.value}>
                                                        <FormControl>
                                                            <SelectTrigger>
                                                                <SelectValue placeholder="Select Account" />
                                                            </SelectTrigger>
                                                        </FormControl>
                                                        <SelectContent>
                                                            {accounts.map(a => (
                                                                <SelectItem key={a.id} value={a.id}>{a.code} - {a.name}</SelectItem>
                                                            ))}
                                                        </SelectContent>
                                                    </Select>
                                                    <FormMessage />
                                                </FormItem>
                                            )}
                                        />
                                    </div>
                                    <div className="w-32">
                                        <FormField
                                            control={form.control}
                                            name={`items.${index}.debit`}
                                            render={({ field }) => (
                                                <FormItem>
                                                    <FormControl>
                                                        <Input type="number" step="0.01" {...field} />
                                                    </FormControl>
                                                    <FormMessage />
                                                </FormItem>
                                            )}
                                        />
                                    </div>
                                    <div className="w-32">
                                        <FormField
                                            control={form.control}
                                            name={`items.${index}.credit`}
                                            render={({ field }) => (
                                                <FormItem>
                                                    <FormControl>
                                                        <Input type="number" step="0.01" {...field} />
                                                    </FormControl>
                                                    <FormMessage />
                                                </FormItem>
                                            )}
                                        />
                                    </div>
                                    <Button
                                        type="button"
                                        variant="ghost"
                                        size="icon"
                                        className="h-10 w-10 text-destructive"
                                        onClick={() => remove(index)}
                                        disabled={fields.length <= 2}
                                    >
                                        <Trash2 className="h-4 w-4" />
                                    </Button>
                                </div>
                            ))}
                        </div>

                        <Button
                            type="button"
                            variant="outline"
                            size="sm"
                            onClick={() => append({ accountId: "", debit: 0, credit: 0, description: "" })}
                        >
                            <Plus className="h-4 w-4 mr-2" /> Add Line
                        </Button>

                        <div className="flex justify-end gap-10 text-lg font-bold border-t pt-4">
                            <div className="text-right">
                                <p className="text-sm text-muted-foreground">Total Debit</p>
                                <p>${totalDebit.toFixed(2)}</p>
                            </div>
                            <div className="text-right">
                                <p className="text-sm text-muted-foreground">Total Credit</p>
                                <p>${totalCredit.toFixed(2)}</p>
                            </div>
                        </div>

                        {error && (
                            <Alert variant="destructive">
                                <AlertCircle className="h-4 w-4" />
                                <AlertTitle>Error</AlertTitle>
                                <AlertDescription>{error}</AlertDescription>
                            </Alert>
                        )}

                        {!isBalanced && totalDebit > 0 && (
                            <Alert>
                                <AlertCircle className="h-4 w-4" />
                                <AlertDescription>Entry is not balanced. Difference: ${(totalDebit - totalCredit).toFixed(2)}</AlertDescription>
                            </Alert>
                        )}

                        <CardFooter className="px-0 pt-6">
                            <Button type="submit" className="w-full" disabled={loading || !isBalanced || totalDebit === 0}>
                                {loading ? "Posting..." : "Post Journal Entry"}
                            </Button>
                        </CardFooter>
                    </form>
                </Form>
            </CardContent>
        </Card>
    )
}
