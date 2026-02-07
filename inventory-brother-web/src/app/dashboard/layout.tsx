import { Link } from '@/i18n/navigation' // We need to setup navigation wrapper or use next/link if i18n not fully setup
import { Button } from "@/components/ui/button"
import {
    LayoutDashboard,
    Package,
    Tags,
    Ruler,
    Settings,
    LogOut
} from "lucide-react"

// Simple mock navigation for now. 
// In a real app, this would be in a config file and verified against permissions.
const navItems = [
    { href: "/dashboard", icon: LayoutDashboard, label: "Dashboard" },
    { href: "/dashboard/catalog/brands", icon: Tags, label: "Brands" },
    { href: "/dashboard/catalog/units", icon: Ruler, label: "Units" },
    { href: "/dashboard/catalog/categories", icon: Package, label: "Categories" },
]

export default function DashboardLayout({
    children,
}: {
    children: React.ReactNode
}) {
    return (
        <div className="flex h-screen bg-muted/40">
            {/* Sidebar */}
            <aside className="hidden w-64 flex-col border-r bg-background sm:flex">
                <div className="flex h-14 items-center border-b px-4 lg:h-[60px] lg:px-6">
                    <Link href="/" className="flex items-center gap-2 font-semibold">
                        <Package className="h-6 w-6" />
                        <span className="">Inv. Brother</span>
                    </Link>
                </div>
                <nav className="grid items-start px-2 text-sm font-medium lg:px-4 gap-1 mt-4">
                    {navItems.map((item) => (
                        <Link
                            key={item.href}
                            href={item.href}
                            className="flex items-center gap-3 rounded-lg px-3 py-2 text-muted-foreground transition-all hover:text-primary hover:bg-muted"
                        >
                            <item.icon className="h-4 w-4" />
                            {item.label}
                        </Link>
                    ))}
                </nav>
                <div className="mt-auto p-4 border-t">
                    <Button variant="outline" className="w-full justify-start gap-2">
                        <LogOut className="h-4 w-4" />
                        Sign Out
                    </Button>
                </div>
            </aside>

            {/* Main Content */}
            <main className="flex flex-1 flex-col gap-4 p-4 lg:gap-6 lg:p-6 overflow-auto">
                {children}
            </main>
        </div>
    )
}
