import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Package, Tags, Ruler } from "lucide-react"
import Link from "next/link"

export default function DashboardPage() {
    return (
        <div className="p-6">
            <h1 className="text-3xl font-bold mb-8">Dashboard</h1>

            <div className="grid gap-6 md:grid-cols-3">
                <Link href="/dashboard/catalog/brands">
                    <Card className="hover:bg-muted/50 transition-colors cursor-pointer">
                        <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                            <CardTitle className="text-sm font-medium">Brands</CardTitle>
                            <Tags className="h-4 w-4 text-muted-foreground" />
                        </CardHeader>
                        <CardContent>
                            <div className="text-2xl font-bold">Manage Brands</div>
                        </CardContent>
                    </Card>
                </Link>

                <Link href="/dashboard/catalog/units">
                    <Card className="hover:bg-muted/50 transition-colors cursor-pointer">
                        <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                            <CardTitle className="text-sm font-medium">Units</CardTitle>
                            <Ruler className="h-4 w-4 text-muted-foreground" />
                        </CardHeader>
                        <CardContent>
                            <div className="text-2xl font-bold">Manage Units</div>
                        </CardContent>
                    </Card>
                </Link>

                <Link href="/dashboard/catalog/categories">
                    <Card className="hover:bg-muted/50 transition-colors cursor-pointer">
                        <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                            <CardTitle className="text-sm font-medium">Categories</CardTitle>
                            <Package className="h-4 w-4 text-muted-foreground" />
                        </CardHeader>
                        <CardContent>
                            <div className="text-2xl font-bold">Manage Categories</div>
                        </CardContent>
                    </Card>
                </Link>
            </div>
        </div>
    )
}
