import { getUnits } from "@/actions/catalog"
import { UnitList } from "@/features/catalog/components/unit-list"
import { getTranslations } from "next-intl/server"

export default async function UnitsPage() {
    const t = await getTranslations("Catalog")
    const units = await getUnits()

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6">{t("title")}</h1>
            <UnitList initialUnits={units} />
        </div>
    )
}
