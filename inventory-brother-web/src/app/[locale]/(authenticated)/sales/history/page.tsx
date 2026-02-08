import { getSales } from "@/actions/sales"
import { SalesHistory } from "@/features/sales/components/SalesHistory"

export default async function SalesHistoryPage() {
    const sales = await getSales()

    return (
        <div className="space-y-6">
            <div className="flex justify-between items-center">
                <h1 className="text-3xl font-bold">Sales History</h1>
            </div>
            <SalesHistory sales={sales} />
        </div>
    )
}
