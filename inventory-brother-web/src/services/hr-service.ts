import { db } from "@/lib/db"
import { employees, attendance, payroll, NewEmployee } from "@/db/schema"
import { eq, and, sql, desc, asc } from "drizzle-orm"
import { AttendanceLog, PayrollProcessingResult, MonthlyPayrollRequest } from "@/types/hr"
import { FinanceService } from "./finance-service"
import { SYSTEM_ACCOUNTS } from "@/constants/finance"

export class HRService {
    static async getEmployees() {
        return await db.select().from(employees).orderBy(asc(employees.name))
    }

    static async createEmployee(data: any) {
        const [employee] = await db.insert(employees).values(data).returning()
        return employee
    }

    static async updateEmployee(id: string, data: any) {
        return await db.update(employees).set({ ...data, updatedAt: new Date() }).where(eq(employees.id, id))
    }

    static async deleteEmployee(id: string) {
        return await db.delete(employees).where(eq(employees.id, id))
    }

    static async getTodayAttendance() {
        const today = new Date()
        today.setHours(0, 0, 0, 0)
        
        return await db.select({
            id: attendance.id,
            employeeId: attendance.employeeId,
            date: attendance.date,
            clockIn: attendance.clockIn,
            clockOut: attendance.clockOut,
            status: attendance.status,
            remarks: attendance.remarks,
            employeeName: employees.name,
            employeeIdCode: employees.employeeId
        })
        .from(attendance)
        .innerJoin(employees, eq(attendance.employeeId, employees.id))
        .where(eq(attendance.date, today))
    }

    static async logAttendance(employeeIdCode: string) {
        const today = new Date()
        today.setHours(0, 0, 0, 0)

        const [employee] = await db.select().from(employees).where(eq(employees.employeeId, employeeIdCode)).limit(1)
        if (!employee) throw new Error("Employee not found")

        const existing = await db.select().from(attendance)
            .where(and(eq(attendance.employeeId, employee.id), eq(attendance.date, today)))
            .limit(1)

        if (existing.length === 0) {
            const [record] = await db.insert(attendance).values({
                employeeId: employee.id,
                date: today,
                clockIn: new Date(),
                status: "Present"
            }).returning()
            return { type: "in", record, employee }
        } else {
            const log = existing[0]
            if (log.clockOut) throw new Error("Already clocked out for today")
            const [record] = await db.update(attendance).set({ clockOut: new Date() }).where(eq(attendance.id, log.id)).returning()
            return { type: "out", record, employee }
        }
    }

    static async getPayrollHistory() {
        return await db.select({
            id: payroll.id,
            employeeId: payroll.employeeId,
            month: payroll.month,
            year: payroll.year,
            calendar: payroll.calendar,
            baseSalary: payroll.baseSalary,
            allowances: payroll.allowances,
            deductions: payroll.deductions,
            netSalary: payroll.netSalary,
            status: payroll.status,
            journalEntryId: payroll.journalEntryId,
            processedAt: payroll.processedAt,
            employeeName: employees.name
        })
        .from(payroll)
        .innerJoin(employees, eq(payroll.employeeId, employees.id))
        .orderBy(desc(payroll.processedAt))
    }

    static async generatePayroll(data: MonthlyPayrollRequest) {
        const activeEmployees = await db.select().from(employees).where(eq(employees.status, "Active"))
        let totalNetSalary = 0

        const results = await db.transaction(async (tx) => {
            const processedRecords = []
            for (const emp of activeEmployees) {
                const [record] = await tx.insert(payroll).values({
                    employeeId: emp.id,
                    month: data.month,
                    year: data.year,
                    calendar: data.calendar || "gregory",
                    baseSalary: emp.salary || 0,
                    netSalary: emp.salary || 0,
                    status: "Processed",
                    processedAt: new Date()
                }).returning()
                processedRecords.push(record)
                totalNetSalary += (emp.salary || 0)
            }

            return processedRecords
        })

        return results
    }
}
