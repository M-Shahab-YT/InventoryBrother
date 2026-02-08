'use client'

import { useState } from "react"
import { Employee } from "@/db/schema"
import { Button } from "@/components/ui/button"
import { Plus, Edit2, Search, User } from "lucide-react"
import { EmployeeDialog } from "./employee-dialog"
import { Input } from "@/components/ui/input"
import {
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableHeader,
    TableRow,
} from "@/components/ui/table"
import { Badge } from "@/components/ui/badge"

interface EmployeeListProps {
    employees: Employee[]
}

export function EmployeeList({ employees }: EmployeeListProps) {
    const [searchTerm, setSearchTerm] = useState("")
    const [selectedEmployee, setSelectedEmployee] = useState<Employee | null>(null)
    const [dialogOpen, setDialogOpen] = useState(false)

    const filtered = employees.filter(e =>
        e.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
        e.employeeId.toLowerCase().includes(searchTerm.toLowerCase()) ||
        e.department?.toLowerCase().includes(searchTerm.toLowerCase())
    )

    const handleAdd = () => {
        setSelectedEmployee(null)
        setDialogOpen(true)
    }

    const handleEdit = (employee: Employee) => {
        setSelectedEmployee(employee)
        setDialogOpen(true)
    }

    return (
        <div className="space-y-4">
            <div className="flex justify-between items-center gap-4">
                <div className="relative flex-1 max-w-sm">
                    <Search className="absolute left-2.5 top-2.5 h-4 w-4 text-muted-foreground" />
                    <Input
                        placeholder="Search employees..."
                        className="pl-8"
                        value={searchTerm}
                        onChange={(e) => setSearchTerm(e.target.value)}
                    />
                </div>
                <Button onClick={handleAdd}>
                    <Plus className="h-4 w-4 mr-2" /> Add Employee
                </Button>
            </div>

            <div className="border rounded-md bg-white">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead>ID</TableHead>
                            <TableHead>Name</TableHead>
                            <TableHead>Department</TableHead>
                            <TableHead>Position</TableHead>
                            <TableHead>Salary</TableHead>
                            <TableHead>Status</TableHead>
                            <TableHead className="text-right">Actions</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {filtered.map((employee) => (
                            <TableRow key={employee.id}>
                                <TableCell className="font-mono text-xs">{employee.employeeId}</TableCell>
                                <TableCell>
                                    <div className="flex items-center gap-2">
                                        <div className="h-8 w-8 rounded-full bg-slate-100 flex items-center justify-center">
                                            <User className="h-4 w-4 text-slate-500" />
                                        </div>
                                        <span className="font-medium">{employee.name}</span>
                                    </div>
                                </TableCell>
                                <TableCell>{employee.department}</TableCell>
                                <TableCell>{employee.position}</TableCell>
                                <TableCell>${employee.salary?.toLocaleString()}</TableCell>
                                <TableCell>
                                    <Badge variant={employee.status === "Active" ? "default" : "secondary"}>
                                        {employee.status}
                                    </Badge>
                                </TableCell>
                                <TableCell className="text-right">
                                    <Button variant="ghost" size="icon" onClick={() => handleEdit(employee)}>
                                        <Edit2 className="h-4 w-4" />
                                    </Button>
                                </TableCell>
                            </TableRow>
                        ))}
                        {filtered.length === 0 && (
                            <TableRow>
                                <TableCell colSpan={7} className="text-center py-10 text-muted-foreground">
                                    No employees found.
                                </TableCell>
                            </TableRow>
                        )}
                    </TableBody>
                </Table>
            </div>

            <EmployeeDialog
                open={dialogOpen}
                onOpenChange={setDialogOpen}
                employee={selectedEmployee}
            />
        </div>
    )
}
