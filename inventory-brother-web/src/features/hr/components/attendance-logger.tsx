'use client'

import { useState, useRef, useEffect } from "react"
import { logAttendance } from "@/actions/hr"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow
} from "@/components/ui/table"
import { Scan, CheckCircle2, LogOut as LogOutIcon, User } from "lucide-react"
import { toast } from "sonner"

interface AttendanceLoggerProps {
    initialLogs: any[]
}

export function AttendanceLogger({ initialLogs }: AttendanceLoggerProps) {
    const [barcode, setBarcode] = useState("")
    const [loading, setLoading] = useState(false)
    const inputRef = useRef<HTMLInputElement>(null)

    // Keep input focused for scanner support
    useEffect(() => {
        const focusInput = () => inputRef.current?.focus()
        focusInput()
        window.addEventListener("click", focusInput)
        return () => window.removeEventListener("click", focusInput)
    }, [])

    const handleLog = async (e: React.FormEvent) => {
        e.preventDefault()
        if (!barcode.trim()) return

        setLoading(true)
        try {
            const res = await logAttendance(barcode)
            toast.success(
                res.type === "in"
                    ? `Clocked In: ${res.employee.name}`
                    : `Clocked Out: ${res.employee.name}`
            )
            setBarcode("")
        } catch (error: any) {
            toast.error(error.message || "Failed to log attendance")
        } finally {
            setLoading(false)
        }
    }

    return (
        <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
            <Card className="lg:col-span-1 border-2 border-primary/20 shadow-lg">
                <CardHeader>
                    <CardTitle className="flex items-center gap-2">
                        <Scan className="h-5 w-5 text-primary" />
                        Scan ID Card
                    </CardTitle>
                </CardHeader>
                <CardContent>
                    <form onSubmit={handleLog} className="space-y-4">
                        <div className="p-8 bg-slate-50 border-2 border-dashed rounded-xl flex flex-col items-center justify-center text-center space-y-4">
                            <div className="h-16 w-16 bg-white rounded-full shadow-sm flex items-center justify-center">
                                <Scan className="h-8 w-8 text-slate-400 animate-pulse" />
                            </div>
                            <p className="text-sm text-muted-foreground">
                                Scan employee barcode or type ID manually
                            </p>
                            <Input
                                ref={inputRef}
                                value={barcode}
                                onChange={(e) => setBarcode(e.target.value)}
                                placeholder="Employee ID..."
                                className="text-center font-mono text-lg h-12"
                                autoComplete="off"
                            />
                        </div>
                        <Button type="submit" className="w-full h-12 text-lg" disabled={loading}>
                            {loading ? "Processing..." : "Submit Log"}
                        </Button>
                    </form>
                </CardContent>
            </Card>

            <Card className="lg:col-span-2">
                <CardHeader>
                    <CardTitle>Today&apos;s Attendance Logs</CardTitle>
                </CardHeader>
                <CardContent>
                    <div className="border rounded-md">
                        <Table>
                            <TableHeader>
                                <TableRow>
                                    <TableHead>Employee</TableHead>
                                    <TableHead>Clock In</TableHead>
                                    <TableHead>Clock Out</TableHead>
                                    <TableHead>Status</TableHead>
                                </TableRow>
                            </TableHeader>
                            <TableBody>
                                {initialLogs.map((log) => (
                                    <TableRow key={log.id}>
                                        <TableCell>
                                            <div className="flex items-center gap-2">
                                                <div className="h-8 w-8 rounded-full bg-slate-100 flex items-center justify-center">
                                                    <User className="h-4 w-4 text-slate-500" />
                                                </div>
                                                <div>
                                                    <p className="font-medium">{log.employeeName}</p>
                                                    <p className="text-xs text-muted-foreground font-mono">{log.employeeId}</p>
                                                </div>
                                            </div>
                                        </TableCell>
                                        <TableCell>
                                            <div className="flex items-center gap-1.5 text-green-600 font-medium">
                                                <CheckCircle2 className="h-4 w-4" />
                                                {log.clockIn ? new Date(log.clockIn).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }) : "-"}
                                            </div>
                                        </TableCell>
                                        <TableCell>
                                            <div className="flex items-center gap-1.5 text-amber-600 font-medium">
                                                <LogOutIcon className="h-4 w-4" />
                                                {log.clockOut ? new Date(log.clockOut).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }) : "-"}
                                            </div>
                                        </TableCell>
                                        <TableCell>
                                            <span className="text-xs px-2 py-0.5 bg-slate-100 rounded-full font-medium">
                                                {log.status}
                                            </span>
                                        </TableCell>
                                    </TableRow>
                                ))}
                                {initialLogs.length === 0 && (
                                    <TableRow>
                                        <TableCell colSpan={4} className="text-center py-10 text-muted-foreground">
                                            No attendance logs yet today.
                                        </TableCell>
                                    </TableRow>
                                )}
                            </TableBody>
                        </Table>
                    </div>
                </CardContent>
            </Card>
        </div>
    )
}
