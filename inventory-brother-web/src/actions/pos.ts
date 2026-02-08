'use server'

import { revalidatePath } from "next/cache"
import { POSService } from "@/services/pos-service"
import { SaleRequest } from "@/types/pos"

export async function createSale(data: SaleRequest) {
    const result = await POSService.createSale(data)
    
    revalidatePath("/pos")
    revalidatePath("/inventory/warehouses")
    revalidatePath("/finance/ledger")
    
    return result
}

export async function getSaleHistory() {
    return await POSService.getSaleHistory()
}
