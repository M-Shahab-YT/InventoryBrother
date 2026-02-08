import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Package, Tags, Ruler } from "lucide-react"
import { Link } from "@/i18n/navigation"
import { getTranslations } from "next-intl/server"

export default async function DashboardPage() {
    const t = await getTranslations("Dashboard")

    return (
        <div className="p-6">
            <h1 className="text-3xl font-bold mb-8">{t("title")}</h1>

            <div className="grid gap-6 md:grid-cols-3">
                <Link href="/catalog/brands">
                    <Card className="hover:bg-muted/50 transition-colors cursor-pointer">
                        <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                            <CardTitle className="text-sm font-medium">{t("brandsTitle")}</CardTitle>
                            <Tags className="h-4 w-4 text-muted-foreground" />
                        </CardHeader>
                        <CardContent>
                            <div className="text-2xl font-bold">{t("manageBrands")}</div>
                        </CardContent>
                    </Card>
                </Link>

                <Link href="/catalog/units">
                    <Card className="hover:bg-muted/50 transition-colors cursor-pointer">
                        <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                            <CardTitle className="text-sm font-medium">{t("unitsTitle")}</CardTitle>
                            <Ruler className="h-4 w-4 text-muted-foreground" />
                        </CardHeader>
                        <CardContent>
                            <div className="text-2xl font-bold">{t("manageUnits")}</div>
                        </CardContent>
                    </Card>
                </Link>

                <Link href="/catalog/categories">
                    <Card className="hover:bg-muted/50 transition-colors cursor-pointer">
                        <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
                            <CardTitle className="text-sm font-medium">{t("categoriesTitle")}</CardTitle>
                            <Package className="h-4 w-4 text-muted-foreground" />
                        </CardHeader>
                        <CardContent>
                            <div className="text-2xl font-bold">{t("manageCategories")}</div>
                        </CardContent>
                    </Card>
                </Link>
            </div>
        </div>
    )
}
