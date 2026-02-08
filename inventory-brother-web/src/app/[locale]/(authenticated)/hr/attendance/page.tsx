import { getTodayAttendance } from "@/actions/hr"
import { AttendanceLogger } from "@/features/hr/components/attendance-logger"

export default async function AttendancePage() {
    const logs = await getTodayAttendance()

    return (
        <div className="space-y-6">
            <h1 className="text-3xl font-bold">Attendance Tracking</h1>
            <AttendanceLogger initialLogs={logs} />
        </div>
    )
}
