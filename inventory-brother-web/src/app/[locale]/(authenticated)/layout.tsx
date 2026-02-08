import { Link } from '@/i18n/navigation'
import { Button } from "@/components/ui/button"
import { getTranslations } from 'next-intl/server';
import {
    LayoutDashboard,
    Package,
    Tags,
    LogOut,
    Sliders,
    Users,
    ShoppingCart,
    Users2,
    Calculator,
    BarChart3,
    Search
} from "lucide-react"
import { ModeToggle } from "@/components/mode-toggle"
import { LanguageSwitcher } from "@/components/language-switcher"
import { Input } from "@/components/ui/input"

export default async function AuthenticatedLayout({
    children,
}: {
    children: React.ReactNode
}) {
    const t = await getTranslations('Navigation');

    const navItems = [
        { href: "/dashboard", icon: LayoutDashboard, label: t('dashboard') },
        { href: "/catalog/products", icon: Package, label: t('products') },
        { href: "/catalog/brands", icon: Tags, label: t('brands') },
        { href: "/catalog/categories", icon: Package, label: t('categories') },
        { href: "/inventory/warehouses", icon: Package, label: t('warehouses') },
        { href: "/inventory/adjustments", icon: Sliders, label: t('adjustments') },
        { href: "/inventory/suppliers", icon: Users, label: t('suppliers') },
        { href: "/purchasing/orders", icon: ShoppingCart, label: t('purchasing') },
        { href: "/sales/customers", icon: Users2, label: t('customers') },
        { href: "/sales/history", icon: ShoppingCart, label: t('salesHistory') },
        { href: "/finance/accounts", icon: Calculator, label: t('chartOfAccounts') },
        { href: "/finance/journal", icon: Calculator, label: t('journal') },
        { href: "/finance/ledger", icon: Calculator, label: t('generalLedger') },
        { href: "/finance/reports", icon: BarChart3, label: t('financialReports') },
        { href: "/hr/employees", icon: Users2, label: t('employees') },
        { href: "/hr/attendance", icon: Calculator, label: t('attendance') },
        { href: "/hr/payroll", icon: Calculator, label: t('payroll') },
        { href: "/pos", icon: Calculator, label: t('pos') },
    ]

    return (
        <div className="flex h-screen bg-muted/40">
            {/* Sidebar */}
            <aside className="hidden w-64 flex-col border-r bg-background sm:flex">
                <div className="flex h-14 items-center border-b px-4 lg:h-[60px] lg:px-6">
                    <Link href="/" className="flex items-center gap-2 font-semibold">
                        <Package className="h-6 w-6" />
                        <span className="">{t('title')}</span>
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
                    <form action={async () => {
                        "use server"
                        const { signOut } = await import("@/auth")
                        await signOut({ redirectTo: "/login" })
                    }}>
                        <Button variant="outline" className="w-full justify-start gap-2">
                            <LogOut className="h-4 w-4" />
                            {t('signOut')}
                        </Button>
                    </form>
                </div>
            </aside>

            {/* Main Content */}
            <main className="flex flex-1 flex-col overflow-hidden">
                <header className="flex h-14 items-center gap-4 border-b bg-muted/40 px-6 lg:h-[60px]">
                    <div className="w-full flex-1">
                        <form>
                            <div className="relative">
                                <Search className="absolute left-2.5 top-2.5 h-4 w-4 text-muted-foreground" />
                                <Input
                                    type="search"
                                    placeholder={t('searchPlaceholder')}
                                    className="w-full appearance-none bg-background pl-8 shadow-none md:w-2/3 lg:w-1/3"
                                />
                            </div>
                        </form>
                    </div>
                    <LanguageSwitcher />
                    <ModeToggle />
                </header>
                <div className="flex-1 overflow-auto p-4 lg:p-6">
                    {children}
                </div>
            </main>
        </div>
    )
}
