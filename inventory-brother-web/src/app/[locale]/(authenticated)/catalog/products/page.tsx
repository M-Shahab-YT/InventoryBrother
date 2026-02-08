import { getProducts } from "@/actions/products"
import { getBrands, getUnits, getCategories } from "@/actions/catalog"
import { ProductList } from "@/features/catalog/components/product-list"
import { getTranslations } from "next-intl/server"

export default async function ProductsPage() {
    const t = await getTranslations("Catalog")
    const [products, brands, units, categories] = await Promise.all([
        getProducts(),
        getBrands(),
        getUnits(),
        getCategories()
    ])

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6">{t("productsTitle")}</h1>
            <ProductList
                initialProducts={products}
                brands={brands}
                units={units}
                categories={categories}
            />
        </div>
    )
}
