import { db } from "@/lib/db"
import { sales, saleItems, stocks, products } from "@/db/schema"
import { eq, sql, and, desc } from "drizzle-orm"
import { SaleRequest } from "@/types/pos"
import { FinanceService } from "./finance-service"
import { SYSTEM_ACCOUNTS } from "@/constants/finance"

export class POSService {
    static async createSale(data: SaleRequest) {
        return await db.transaction(async (tx) => {
            const totalAmount = data.items.reduce((sum, item) => sum + (item.quantity * item.unitPrice), 0)
            const totalCost = data.items.reduce((sum, item) => sum + (item.quantity * item.costPrice), 0)
            const netAmount = totalAmount - data.discount + data.tax

            // 1. Create Sale Header
            const [sale] = await tx.insert(sales).values({
                invoiceNo: `INV-${Date.now()}`,
                customerId: data.customerId,
                warehouseId: data.warehouseId,
                totalAmount,
                discount: data.discount,
                tax: data.tax,
                netAmount,
                paymentMethod: data.paymentMethod,
                status: "Completed"
            }).returning()

            // 2. Create Sale Items & Update Stock
            for (const item of data.items) {
                const lineTotal = item.unitPrice * item.quantity

                await tx.insert(saleItems).values({
                    saleId: sale.id,
                    productId: item.productId,
                    quantity: item.quantity,
                    unitPrice: item.unitPrice,
                    total: lineTotal,
                    costPrice: item.costPrice
                })

                // Deduct Stock (using stocks table as per schema)
                const [existingStock] = await tx.select().from(stocks).where(
                    and(
                        eq(stocks.productId, item.productId),
                        eq(stocks.warehouseId, data.warehouseId)
                    )
                ).limit(1)

                if (existingStock) {
                    await tx.update(stocks)
                        .set({ quantity: (existingStock.quantity || 0) - item.quantity, updatedAt: new Date() })
                        .where(eq(stocks.id, existingStock.id))
                } else {
                    await tx.insert(stocks).values({
                        productId: item.productId,
                        warehouseId: data.warehouseId,
                        quantity: -item.quantity
                    })
                }
            }

            // 3. Record Journal Entries (Auto)
            await FinanceService.recordAutoJournalEntry(tx, {
                description: `Sale - Invoice ${sale.invoiceNo}`,
                referenceNo: sale.invoiceNo || "",
                items: [
                    { code: SYSTEM_ACCOUNTS.CASH.code, debit: netAmount, credit: 0 },
                    { code: SYSTEM_ACCOUNTS.SALES.code, debit: 0, credit: netAmount },
                    { code: SYSTEM_ACCOUNTS.COGS.code, debit: totalCost, credit: 0 },
                    { code: SYSTEM_ACCOUNTS.INVENTORY.code, debit: 0, credit: totalCost },
                ]
            })

            return { sale, items: data.items }
        })
    }

    static async getSaleHistory() {
        return await db.select().from(sales).orderBy(desc(sales.createdAt))
    }
}
