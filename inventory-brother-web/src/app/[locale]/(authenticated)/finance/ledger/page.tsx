import { getLedger } from "@/actions/finance"
import { LedgerList } from "@/features/finance/components/ledger-list"

export default async function LedgerPage() {
    const entries = await getLedger()

    return (
        <div className="space-y-6">
            <h1 className="text-3xl font-bold">General Ledger</h1>
            <LedgerList entries={entries} />
        </div>
    )
}
