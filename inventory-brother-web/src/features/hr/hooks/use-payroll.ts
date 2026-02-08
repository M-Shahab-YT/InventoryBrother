import { useState, useMemo } from "react"
import { generatePayroll } from "@/actions/hr"
import { toast } from "sonner"
import { useLocale } from "next-intl"
import { DateService } from "@/services/date-service"

export function usePayroll() {
  const locale = useLocale()
  const calendar = DateService.getPreferredCalendar(locale)
  const current = useMemo(() => DateService.getCurrentPeriod(calendar), [calendar])

  const [loading, setLoading] = useState(false)
  const [month, setMonth] = useState(current.month)
  const [year, setYear] = useState(current.year)

  const handleGenerate = async () => {
    setLoading(true)
    try {
      // Pass calendar context to ensure server knows which Month "1" we mean
      const results = await generatePayroll(Number(month), Number(year), calendar)
      if (results.length === 0) {
        toast.info("No new payroll records to process for this period.")
      } else {
        toast.success(`Successfully processed payroll for ${results.length} employees.`)
      }
      return results
    } catch (error: any) {
      toast.error(error.message || "Failed to generate payroll")
      throw error
    } finally {
      setLoading(false)
    }
  }

  return {
    month,
    setMonth,
    year,
    setYear,
    loading,
    handleGenerate
  }
}
