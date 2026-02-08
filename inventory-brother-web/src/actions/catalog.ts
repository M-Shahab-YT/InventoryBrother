'use server'

import { db } from "@/lib/db"
import { brands, units, categories } from "@/db/schema"
import { revalidatePath } from "next/cache"
import { eq } from "drizzle-orm"

// Brands
export async function getBrands() {
  return await db.select().from(brands)
}

export async function createBrand(formData: FormData) {
  const name = formData.get("name") as string
  await db.insert(brands).values({ name })
  revalidatePath("/catalog/brands")
}

export async function deleteBrand(id: number) {
  await db.delete(brands).where(eq(brands.id, id))
  revalidatePath("/catalog/brands")
}

// Units
export async function getUnits() {
  return await db.select().from(units)
}

export async function createUnit(formData: FormData) {
  const name = formData.get("name") as string
  await db.insert(units).values({ name })
  revalidatePath("/catalog/units")
}

export async function deleteUnit(id: number) {
  await db.delete(units).where(eq(units.id, id))
  revalidatePath("/catalog/units")
}

// Categories
export async function getCategories() {
  return await db.select().from(categories)
}

export async function createCategory(formData: FormData) {
  const name = formData.get("name") as string
  const parentId = formData.get("parentId") ? parseInt(formData.get("parentId") as string) : undefined
  await db.insert(categories).values({ name, parentId })
  revalidatePath("/catalog/categories")
}

export async function deleteCategory(id: number) {
  await db.delete(categories).where(eq(categories.id, id))
  revalidatePath("/catalog/categories")
}
