'use server'

import { db } from "@/lib/db"
import { products, NewProduct } from "@/db/schema"
import { revalidatePath } from "next/cache"
import { eq, desc } from "drizzle-orm"

export async function getProducts() {
  // We should probably join with categories, units, brands for display
  // Drizzle's query builder "with" syntax if we defined relations, or just raw joins or separate queries.
  // For now, let's just fetch products. We can fetch related data in the component if needed or use joins.
  // Actually, for the list, we want raw values or names.
  // Let's rely on simple select for now. relationships logic is better added later with keys.
  
  return await db.select().from(products).orderBy(desc(products.createdAt))
}

export async function createProduct(formData: FormData) {
  const data: NewProduct = {
    id: formData.get("id") as string, // ProductCode
    name: formData.get("name") as string,
    description: formData.get("description") as string,
    barcode: formData.get("barcode") as string,
    barcodeType: "CODE128", // Default
    price: parseFloat(formData.get("price") as string || "0"),
    salePrice: parseFloat(formData.get("salePrice") as string || "0"),
    mrp: parseFloat(formData.get("mrp") as string || "0"),
    cost: parseFloat(formData.get("cost") as string || "0"),
    
    categoryId: formData.get("categoryId") ? parseInt(formData.get("categoryId") as string) : undefined,
    unitId: formData.get("unitId") ? parseInt(formData.get("unitId") as string) : undefined,
    brandId: formData.get("brandId") ? parseInt(formData.get("brandId") as string) : undefined,
    
    stockQuantity: parseFloat(formData.get("stockQuantity") as string || "0"),
    minStock: parseFloat(formData.get("minStock") as string || "0"),
    
    image: formData.get("image") as string, // Base64 string from client
  }
  
  await db.insert(products).values(data)
  revalidatePath("/catalog/products")
}

export async function deleteProduct(id: string) {
  await db.delete(products).where(eq(products.id, id))
  revalidatePath("/catalog/products")
}
