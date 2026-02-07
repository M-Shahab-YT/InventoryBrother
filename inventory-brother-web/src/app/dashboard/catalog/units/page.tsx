import { getUnits } from "@/actions/catalog"
import { UnitList } from "@/features/catalog/components/UnitList"

export default async function UnitsPage() {
    const units = await getUnits()

    return (
        <div className="p-6">
            <h1 className="text-2xl font-bold mb-6">Catalog Management</h1>
            <UnitList initialUnits={units} />
        </div>
    )
}
