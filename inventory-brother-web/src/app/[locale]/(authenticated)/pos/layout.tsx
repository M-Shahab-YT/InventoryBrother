import { ReactNode } from "react"

export default function POSLayout({ children }: { children: ReactNode }) {
    return (
        <div className="min-h-screen bg-slate-50 overflow-hidden flex flex-col">
            <main className="flex-1 overflow-auto">
                {children}
            </main>
        </div>
    )
}
