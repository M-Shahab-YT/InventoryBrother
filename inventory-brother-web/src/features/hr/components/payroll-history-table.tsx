'use client'

import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow,
} from "@/components/ui/table"
import { Badge } from "@/components/ui/badge"
import { useLocale } from "next-intl"
import { DateService } from "@/services/date-service"

interface PayrollHistoryTableProps {
    history: any[]
}

export function PayrollHistoryTable({ history }: PayrollHistoryTableProps) {
    const locale = useLocale()
    const calendar = DateService.getPreferredCalendar(locale)
    const monthNames = DateService.getMonthNames(locale, calendar)

    return (
        <div className="border rounded-md overflow-hidden bg-white">
            <Table>
                <TableHeader className="bg-slate-50">
                    <TableRow>
                        <TableHead>Employee</TableHead>
                        <TableHead>Period</TableHead>
                        <TableHead>Amount</TableHead>
                        <TableHead>Processed Date</TableHead>
                        <TableHead>Status</TableHead>
                    </TableRow>
                </TableHeader>
                <TableBody>
                    {history.map((record) => (
                        <TableRow key={record.id}>
                            <TableCell className="font-medium">{record.employeeName}</TableCell>
                            <TableCell>
                                {monthNames.find(m => m.value === record.month.toString())?.label} {record.year}
                            </TableCell>
                            <TableCell className="font-mono font-bold">
                                ${record.netSalary.toLocaleString()}
                            </TableCell>
                            <TableCell className="text-muted-foreground text-sm">
                                {record.processedAt ? new Date(record.processedAt).toLocaleDateString(locale) : "-"}
                            </TableCell>
                            <TableCell>
                                <Badge variant="outline" className="bg-green-50 text-green-700 border-green-200">
                                    {record.status}
                                </Badge>
                            </TableCell>
                        </TableRow>
                    ))}
                    {history.length === 0 && (
                        <TableRow>
                            <TableCell colSpan={5} className="text-center py-10 text-muted-foreground">
                                No payroll records found.
                            </TableCell>
                        </TableRow>
                    )}
                </TableBody>
            </Table>
        </div>
    )
}
