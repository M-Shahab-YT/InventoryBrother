'use client'

import { Button } from "@/components/ui/button"
import { Loader2 } from "lucide-react"
import {
    Select,
    SelectContent,
    SelectItem,
    SelectTrigger,
    SelectValue,
} from "@/components/ui/select"
import { useLocale } from "next-intl"
import { DateService } from "@/services/date-service"

interface PayrollControlPanelProps {
    month: string
    setMonth: (val: string) => void
    year: string
    setYear: (val: string) => void
    onGenerate: () => void
    loading: boolean
}

export function PayrollControlPanel({
    month, setMonth, year, setYear, onGenerate, loading
}: PayrollControlPanelProps) {
    const locale = useLocale()
    const calendar = DateService.getPreferredCalendar(locale)
    const months = DateService.getMonthNames(locale, calendar)
    const years = DateService.getYears(2024, 2026) // Could be more dynamic later

    return (
        <div className="flex flex-wrap items-end gap-4 bg-slate-50 p-6 rounded-xl border">
            <div className="space-y-2">
                <label className="text-sm font-medium">Select Month</label>
                <Select value={month} onValueChange={setMonth}>
                    <SelectTrigger className="w-[180px] bg-white">
                        <SelectValue placeholder="Month" />
                    </SelectTrigger>
                    <SelectContent>
                        {months.map((m) => (
                            <SelectItem key={m.value} value={m.value}>{m.label}</SelectItem>
                        ))}
                    </SelectContent>
                </Select>
            </div>
            <div className="space-y-2">
                <label className="text-sm font-medium">Select Year</label>
                <Select value={year} onValueChange={setYear}>
                    <SelectTrigger className="w-[120px] bg-white">
                        <SelectValue placeholder="Year" />
                    </SelectTrigger>
                    <SelectContent>
                        {years.map((y) => (
                            <SelectItem key={y} value={y}>{y}</SelectItem>
                        ))}
                    </SelectContent>
                </Select>
            </div>
            <Button onClick={onGenerate} disabled={loading} className="h-10 px-8">
                {loading ? (
                    <>
                        <Loader2 className="mr-2 h-4 w-4 animate-spin" />
                        Processing...
                    </>
                ) : (
                    "Generate Payroll"
                )}
            </Button>
        </div>
    )
}
