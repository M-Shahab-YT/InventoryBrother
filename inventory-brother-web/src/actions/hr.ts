'use server'

import { revalidatePath } from "next/cache"
import { HRService } from "@/services/hr-service"
import { NewEmployee } from "@/db/schema"
import { MonthlyPayrollRequest } from "@/types/hr"

export async function getEmployees() {
    return await HRService.getEmployees()
}

export async function createEmployee(data: NewEmployee) {
    const employee = await HRService.createEmployee(data)
    revalidatePath("/hr/employees")
    return employee
}

export async function updateEmployee(id: string, data: Partial<NewEmployee>) {
    await HRService.updateEmployee(id, data)
    revalidatePath("/hr/employees")
}

export async function deleteEmployee(id: string) {
    await HRService.deleteEmployee(id)
    revalidatePath("/hr/employees")
}

// --- Attendance ---

export async function getTodayAttendance() {
    return await HRService.getTodayAttendance()
}

export async function logAttendance(empBarcode: string) {
    const result = await HRService.logAttendance(empBarcode)
    revalidatePath("/hr/attendance")
    return result
}

// --- Payroll ---

export async function getPayrollHistory() {
    return await HRService.getPayrollHistory()
}

export async function generatePayroll(month: number, year: number, calendar: string = 'gregory') {
    const results = await HRService.generatePayroll({ month, year, calendar })
    
    revalidatePath("/hr/payroll")
    revalidatePath("/finance/ledger")
    
    return results
}
