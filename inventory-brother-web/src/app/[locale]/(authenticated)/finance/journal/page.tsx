import { getAccounts, getJournalEntries } from "@/actions/finance"
import { JournalEntryForm } from "@/features/finance/components/journal-entry-form"
import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow
} from "@/components/ui/table"
import { Badge } from "@/components/ui/badge"

export default async function JournalPage() {
    const [accounts, entries] = await Promise.all([
        getAccounts(),
        getJournalEntries()
    ])

    return (
        <div className="space-y-6">
            <h1 className="text-3xl font-bold">General Journal</h1>

            <JournalEntryForm accounts={accounts} />

            <div className="space-y-4">
                <h2 className="text-xl font-semibold">Recent Entries</h2>
                <div className="border rounded-md bg-white">
                    <Table>
                        <TableHeader>
                            <TableRow>
                                <TableHead>Date</TableHead>
                                <TableHead>Reference</TableHead>
                                <TableHead>Description</TableHead>
                                <TableHead>Status</TableHead>
                            </TableRow>
                        </TableHeader>
                        <TableBody>
                            {entries.map((entry: any) => (
                                <TableRow key={entry.id}>
                                    <TableCell>{new Date(entry.date || Date.now()).toLocaleDateString()}</TableCell>
                                    <TableCell className="font-mono">{entry.referenceNo}</TableCell>
                                    <TableCell>{entry.description}</TableCell>
                                    <TableCell>
                                        <Badge>{entry.status}</Badge>
                                    </TableCell>
                                </TableRow>
                            ))}
                            {entries.length === 0 && (
                                <TableRow>
                                    <TableCell colSpan={4} className="text-center py-6 text-muted-foreground">
                                        No journal entries found.
                                    </TableCell>
                                </TableRow>
                            )}
                        </TableBody>
                    </Table>
                </div>
            </div>
        </div>
    )
}
