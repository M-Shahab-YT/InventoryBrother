import { getCategories } from "@/actions/catalog"
import { CategoryList } from "@/features/catalog/components/CategoryList"

export default async function CategoriesPage() {
    const categories = await getCategories()

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6">Catalog Management</h1>
            <CategoryList initialCategories={categories} />
        </div>
    )
}
