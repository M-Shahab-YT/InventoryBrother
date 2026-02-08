'use server'

import { db } from "@/lib/db"
import { customers, NewCustomer } from "@/db/schema"
import { revalidatePath } from "next/cache"
import { eq, desc } from "drizzle-orm"

export async function getCustomers() {
  return await db.select().from(customers).orderBy(desc(customers.createdAt))
}

export async function createCustomer(formData: FormData) {
  const data: NewCustomer = {
    name: formData.get("name") as string,
    mobile: formData.get("mobile") as string,
    email: formData.get("email") as string,
    address: formData.get("address") as string,
    type: formData.get("type") as string || "Retail",
    contactPerson: formData.get("contactPerson") as string,
    status: "Active",
    areaCode: formData.get("areaCode") as string,
    storeId: 1, // Default store
  }
  
  await db.insert(customers).values(data)
  revalidatePath("/sales/customers")
}

export async function updateCustomer(id: string, formData: FormData) {
    const data: Partial<NewCustomer> = {
        name: formData.get("name") as string,
        mobile: formData.get("mobile") as string,
        email: formData.get("email") as string,
        address: formData.get("address") as string,
        type: formData.get("type") as string,
        contactPerson: formData.get("contactPerson") as string,
        areaCode: formData.get("areaCode") as string,
    }

    await db.update(customers).set(data).where(eq(customers.id, id))
    revalidatePath("/sales/customers")
}

export async function deleteCustomer(id: string) {
  await db.delete(customers).where(eq(customers.id, id))
  revalidatePath("/sales/customers")
}
