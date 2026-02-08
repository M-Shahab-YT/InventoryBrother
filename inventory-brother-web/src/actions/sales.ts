'use server'

import { db } from "@/lib/db"
import { sales, saleItems, customers, products } from "@/db/schema"
import { desc, eq } from "drizzle-orm"

export async function getSales() {
    return await db.select({
        id: sales.id,
        invoiceNo: sales.invoiceNo,
        saleDate: sales.saleDate,
        totalAmount: sales.totalAmount,
        netAmount: sales.netAmount,
        status: sales.status,
        customerName: customers.name,
    })
    .from(sales)
    .leftJoin(customers, eq(sales.customerId, customers.id))
    .orderBy(desc(sales.saleDate))
}

export async function getSaleDetails(saleId: string) {
    const sale = await db.query.sales.findFirst({
        where: eq(sales.id, saleId),
        with: {
            // If using drizzle with relational queries enabled
        }
    })
    
    // Explicit manual fetch if not using relations config
    const items = await db.select({
        id: saleItems.id,
        quantity: saleItems.quantity,
        unitPrice: saleItems.unitPrice,
        total: saleItems.total,
        productName: products.name,
    })
    .from(saleItems)
    .leftJoin(products, eq(saleItems.productId, products.id))
    .where(eq(saleItems.saleId, saleId))

    return { sale, items }
}
