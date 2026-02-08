'use client'

import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow
} from "@/components/ui/table"

interface LedgerListProps {
    entries: any[]
}

export function LedgerList({ entries }: LedgerListProps) {
    const totalDebit = entries.reduce((sum, e) => sum + (e.debit || 0), 0)
    const totalCredit = entries.reduce((sum, e) => sum + (e.credit || 0), 0)

    return (
        <div className="space-y-4">
            <div className="border rounded-md bg-white">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead>Date</TableHead>
                            <TableHead>Account</TableHead>
                            <TableHead>Ref #</TableHead>
                            <TableHead>Description</TableHead>
                            <TableHead className="text-right">Debit</TableHead>
                            <TableHead className="text-right">Credit</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {entries.map((entry) => (
                            <TableRow key={entry.id}>
                                <TableCell>{new Date(entry.date).toLocaleDateString()}</TableCell>
                                <TableCell className="font-medium">{entry.accountName}</TableCell>
                                <TableCell className="font-mono text-xs">{entry.referenceNo}</TableCell>
                                <TableCell className="text-sm">{entry.description}</TableCell>
                                <TableCell className="text-right font-mono text-green-600">
                                    {entry.debit > 0 ? `$${entry.debit.toFixed(2)}` : "-"}
                                </TableCell>
                                <TableCell className="text-right font-mono text-red-600">
                                    {entry.credit > 0 ? `$${entry.credit.toFixed(2)}` : "-"}
                                </TableCell>
                            </TableRow>
                        ))}
                        {entries.length === 0 && (
                            <TableRow>
                                <TableCell colSpan={6} className="text-center py-10 text-muted-foreground">
                                    No ledger entries found.
                                </TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </div>

            <div className="flex justify-end gap-10 p-4 border rounded-md bg-slate-50 font-bold">
                <div className="text-right">
                    <p className="text-xs text-muted-foreground uppercase">Total Debit</p>
                    <p className="text-xl">${totalDebit.toFixed(2)}</p>
                </div>
                <div className="text-right border-l pl-10">
                    <p className="text-xs text-muted-foreground uppercase">Total Credit</p>
                    <p className="text-xl">${totalCredit.toFixed(2)}</p>
                </div>
                <div className="text-right border-l pl-10">
                    <p className="text-xs text-muted-foreground uppercase">Balance</p>
                    <p className={`text-xl ${totalDebit === totalCredit ? 'text-primary' : 'text-destructive'}`}>
                        ${(totalDebit - totalCredit).toFixed(2)}
                    </p>
                </div>
            </div>
        </div>
    )
}
