import { Employee, Attendance, Payroll } from "@/db/schema"

export interface EmployeeWithStatus extends Employee {
    status: "Active" | "Inactive" | "Terminated"
}

export interface AttendanceLog extends Attendance {
    employeeName?: string
    employeeIdCode?: string // The custom barcode/ID
}

export interface PayrollProcessingResult extends Payroll {
    employeeName: string
}

export interface MonthlyPayrollRequest {
    month: number
    year: number
    calendar?: string
}
