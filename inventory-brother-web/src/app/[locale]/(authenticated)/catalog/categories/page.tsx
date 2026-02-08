import { getCategories } from "@/actions/catalog"
import { CategoryList } from "@/features/catalog/components/category-list"
import { getTranslations } from "next-intl/server"

export default async function CategoriesPage() {
    const t = await getTranslations("Catalog")
    const categories = await getCategories()

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6">{t("title")}</h1>
            <CategoryList initialCategories={categories} />
        </div>
    )
}
