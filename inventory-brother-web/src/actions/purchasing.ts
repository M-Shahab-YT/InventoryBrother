'use server'

import { db } from "@/lib/db"
import { purchaseOrders, purchaseOrderItems, stocks, NewPurchaseOrder } from "@/db/schema"
import { revalidatePath } from "next/cache"
import { eq, desc, and } from "drizzle-orm"
import { FinanceService } from "@/services/finance-service"
import { SYSTEM_ACCOUNTS } from "@/constants/finance"

export async function getPurchaseOrders() {
// ...
// ... (rest of the functions unchanged until receiveOrder)
  return await db.select().from(purchaseOrders).orderBy(desc(purchaseOrders.createdAt))
}

export async function getPurchaseOrder(id: string) {
  const settings = await db.select().from(purchaseOrders).where(eq(purchaseOrders.id, id))
  if (settings.length === 0) return null
  
  const items = await db.select().from(purchaseOrderItems).where(eq(purchaseOrderItems.purchaseOrderId, id))
  
  return { ...settings[0], items }
}

export async function createPurchaseOrder(data: {
    supplierId: string,
    remarks?: string,
    items: { productId: string, quantity: number, unitCost: number }[]
}) {
    const totalAmount = data.items.reduce((sum, item) => sum + (item.quantity * item.unitCost), 0)
    
    await db.transaction(async (tx) => {
        // 1. Create PO
        const [po] = await tx.insert(purchaseOrders).values({
            purchaseOrderNo: `PO-${Date.now()}`, // Simple PO Number generation
            supplierId: data.supplierId,
            status: "Ordered",
            totalAmount,
            remarks: data.remarks
        }).returning()

        // 2. Create Items
        if (data.items.length > 0) {
            await tx.insert(purchaseOrderItems).values(
                data.items.map(item => ({
                    purchaseOrderId: po.id,
                    productId: item.productId,
                    quantity: item.quantity,
                    unitCost: item.unitCost,
                    totalCost: item.quantity * item.unitCost
                }))
            )
        }
    })
    
    revalidatePath("/purchasing/orders")
}

export async function receiveOrder(orderId: string, warehouseId: number) {
    await db.transaction(async (tx) => {
        // 1. Get PO Items
        const items = await tx.select().from(purchaseOrderItems).where(eq(purchaseOrderItems.purchaseOrderId, orderId))
        
        // 2. Update Stock for each item
        for (const item of items) {
             const existingStock = await tx.select().from(stocks).where(
                and(
                    eq(stocks.productId, item.productId),
                    eq(stocks.warehouseId, warehouseId)
                )
            ).limit(1)

            if (existingStock.length > 0) {
                await tx.update(stocks)
                    .set({ quantity: (existingStock[0].quantity || 0) + (item.quantity || 0), updatedAt: new Date() })
                    .where(eq(stocks.id, existingStock[0].id))
            } else {
                await tx.insert(stocks).values({
                    productId: item.productId,
                    warehouseId: warehouseId,
                    quantity: item.quantity || 0,
                    // batchNo? We could take from PO Item if we had it there. 
                    // current schema for PO items has batchNo. Assuming we fill it later or null.
                    batchNo: item.batchNo
                })
            }
        }
        
        // 3. Update PO Status
        await tx.update(purchaseOrders)
            .set({ status: "Received", updatedAt: new Date() })
            .where(eq(purchaseOrders.id, orderId))

        // 4. Automated Journal Entry
        const po = (await tx.select().from(purchaseOrders).where(eq(purchaseOrders.id, orderId)).limit(1))[0]
        const totalReceivedValue = items.reduce((sum, item) => sum + (item.totalCost || 0), 0)

        await FinanceService.recordAutoJournalEntry(tx, {
            description: `Inventory Received - PO ${po.purchaseOrderNo}`,
            referenceNo: po.purchaseOrderNo || "",
            items: [
                { code: SYSTEM_ACCOUNTS.INVENTORY.code, debit: totalReceivedValue, credit: 0 },
                { code: SYSTEM_ACCOUNTS.CASH.code, debit: 0, credit: totalReceivedValue }, // Assuming Cash for now
            ]
        })
    })
    
    revalidatePath("/purchasing/orders")
    revalidatePath(`/purchasing/orders/${orderId}`)
    revalidatePath("/inventory/warehouses")
    revalidatePath("/finance/ledger")
}
