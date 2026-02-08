'use server'

import { db } from "@/lib/db"
import { warehouses, stocks, NewWarehouse, NewStock } from "@/db/schema"
import { revalidatePath } from "next/cache"
import { eq, and } from "drizzle-orm"

// Warehouses
export async function getWarehouses() {
  return await db.select().from(warehouses)
}

export async function createWarehouse(formData: FormData) {
  const data: NewWarehouse = {
    name: formData.get("name") as string,
    address: formData.get("address") as string,
    status: "Active",
  }
  await db.insert(warehouses).values(data)
  revalidatePath("/inventory/warehouses")
}

export async function deleteWarehouse(id: number) {
  await db.delete(warehouses).where(eq(warehouses.id, id))
  revalidatePath("/inventory/warehouses")
}

// Stocks
export async function getStocks(warehouseId?: number) {
  let query = db.select().from(stocks)
  if (warehouseId) {
    // @ts-ignore - simple where clause
    query = query.where(eq(stocks.warehouseId, warehouseId))
  }
  return await query
}

export async function adjustStock(formData: FormData) {
  const productId = formData.get("productId") as string
  const warehouseId = parseInt(formData.get("warehouseId") as string)
  const quantity = parseFloat(formData.get("quantity") as string)
  const type = formData.get("type") as "in" | "out"
  const batchNo = formData.get("batchNo") as string
  
  const adjustment = type === "in" ? quantity : -quantity
  
  // Basic transaction or check-then-update
  // Drizzle transaction:
  await db.transaction(async (tx) => {
    // Check if stock record exists for this product+warehouse+batch
    // Note: If batchNo is important, we should include it in the key. 
    // For now, let's assume we match on product+warehouse, and maybe batch if provided?
    // Let's simplify: One stock record per product per warehouse (ignoring batch aggregation for now, or just inserting new records?)
    // Usually stock is aggregated. "Stock" entity in schemas usually matches `ProductLocation` logic?
    // In legacy `Stock.cs`, it has `BatchNo` and `ProductCode`. It seems like individual lots.
    
    // If we want to track lots, we insert a new record for every IN, and maybe decrease specific record for OUT?
    // OR we just aggregate quantity.
    // Given the simple schema `quantity` field, let's aggregate for now or insert if tracking lots.
    // If `stocks` table represents "Current Stock State", then we should upsert.
    
    const existingStock = await tx.select().from(stocks).where(
        and(
            eq(stocks.productId, productId),
            eq(stocks.warehouseId, warehouseId),
            // eq(stocks.batchNo, batchNo) // If we track strictly by batch
        )
    ).limit(1)

    if (existingStock.length > 0) {
        const newQty = (existingStock[0].quantity || 0) + adjustment
        await tx.update(stocks)
            .set({ quantity: newQty, updatedAt: new Date() })
            .where(eq(stocks.id, existingStock[0].id))
    } else {
        if (type === 'out') throw new Error("Cannot remove stock that doesn't exist")
        await tx.insert(stocks).values({
            productId,
            warehouseId,
            quantity: adjustment,
            batchNo: batchNo || 'BATCH-' + Date.now(),
        })
    }
  })

  revalidatePath("/catalog/products")
  revalidatePath("/inventory/warehouses")
}
