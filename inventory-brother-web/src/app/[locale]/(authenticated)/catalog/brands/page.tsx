import { getBrands } from "@/actions/catalog"
import { BrandList } from "@/features/catalog/components/brand-list"
import { getTranslations } from "next-intl/server"

export default async function BrandsPage() {
    const t = await getTranslations("Catalog")
    const brands = await getBrands()

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6">{t("title")}</h1>
            <BrandList initialBrands={brands} />
        </div>
    )
}
