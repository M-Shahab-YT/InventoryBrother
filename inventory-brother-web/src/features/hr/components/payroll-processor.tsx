'use client'

import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { DollarSign, History } from "lucide-react"
import { PayrollControlPanel } from "./payroll-control-panel"
import { PayrollHistoryTable } from "./payroll-history-table"
import { usePayroll } from "../hooks/use-payroll"

interface PayrollProcessorProps {
  history: any[]
}

export function PayrollProcessor({ history }: PayrollProcessorProps) {
  const { month, setMonth, year, setYear, loading, handleGenerate } = usePayroll()

  return (
    <div className="space-y-6">
      <Card className="border-2 border-primary/20">
        <CardHeader>
          <CardTitle className="flex items-center gap-2 text-primary">
            <DollarSign className="h-5 w-5" />
            Process Monthly Payroll
          </CardTitle>
        </CardHeader>
        <CardContent>
          <PayrollControlPanel
            month={month}
            setMonth={setMonth}
            year={year}
            setYear={setYear}
            onGenerate={handleGenerate}
            loading={loading}
          />
          <p className="mt-4 text-xs text-muted-foreground italic">
            * This will automatically create a Journal Entry in Finance for the total salary amount.
          </p>
        </CardContent>
      </Card>

      <Card>
        <CardHeader>
          <CardTitle className="flex items-center gap-2">
            <History className="h-5 w-5" />
            Payroll History
          </CardTitle>
        </CardHeader>
        <CardContent>
          <PayrollHistoryTable history={history} />
        </CardContent>
      </Card>
    </div>
  )
}
