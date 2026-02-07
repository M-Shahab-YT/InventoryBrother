import { getBrands } from "@/actions/catalog"
import { BrandList } from "@/features/catalog/components/BrandList"

export default async function BrandsPage() {
    const brands = await getBrands()

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6">Catalog Management</h1>
            <BrandList initialBrands={brands} />
        </div>
    )
}
