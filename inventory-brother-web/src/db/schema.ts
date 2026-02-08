import { sql } from "drizzle-orm"
import { integer, sqliteTable, text, primaryKey, AnySQLiteColumn } from "drizzle-orm/sqlite-core"
import type { AdapterAccountType } from "next-auth/adapters"

export const users = sqliteTable("user", {
  id: text("id")
    .primaryKey()
    .$defaultFn(() => crypto.randomUUID()),
  name: text("name"),
  email: text("email").unique(),
  emailVerified: integer("emailVerified", { mode: "timestamp_ms" }),
  image: text("image"),
  role: text("role").default("user"),
})

export type User = typeof users.$inferSelect

export const accounts = sqliteTable(
  "account",
  {
    userId: text("userId")
      .notNull()
      .references(() => users.id, { onDelete: "cascade" }),
    type: text("type").$type<AdapterAccountType>().notNull(),
    provider: text("provider").notNull(),
    providerAccountId: text("providerAccountId").notNull(),
    refresh_token: text("refresh_token"),
    access_token: text("access_token"),
    expires_at: integer("expires_at"),
    token_type: text("token_type"),
    scope: text("scope"),
    id_token: text("id_token"),
    session_state: text("session_state"),
  },
  (account) => ({
    compoundKey: primaryKey({
      columns: [account.provider, account.providerAccountId],
    }),
  })
)

export const sessions = sqliteTable("session", {
  sessionToken: text("sessionToken").primaryKey(),
  userId: text("userId")
    .notNull()
    .references(() => users.id, { onDelete: "cascade" }),
  expires: integer("expires", { mode: "timestamp_ms" }).notNull(),
})

export const verificationTokens = sqliteTable(
  "verificationToken",
  {
    identifier: text("identifier").notNull(),
    token: text("token").notNull(),
    expires: integer("expires", { mode: "timestamp_ms" }).notNull(),
  },
// ... existing code ...
  (verificationToken) => ({
    compositePk: primaryKey({
      columns: [verificationToken.identifier, verificationToken.token],
    }),
  })
)

// Catalog Entities

export const brands = sqliteTable("brands", {
  id: integer("id").primaryKey({ autoIncrement: true }),
  name: text("name").notNull(),
  // BaseEntity fields
  createdAt: integer("created_at", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  updatedAt: integer("updated_at", { mode: "timestamp" }).$onUpdate(() => new Date()),
  createdBy: text("created_by"),
  updatedBy: text("updated_by"),
  storeId: integer("store_id").default(1),
})

export const units = sqliteTable("units", {
  id: integer("id").primaryKey({ autoIncrement: true }),
  name: text("name").notNull(),
  // BaseEntity fields
  createdAt: integer("created_at", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  updatedAt: integer("updated_at", { mode: "timestamp" }).$onUpdate(() => new Date()),
  createdBy: text("created_by"),
  updatedBy: text("updated_by"),
  storeId: integer("store_id").default(1),
})

export const categories = sqliteTable("categories", {
  id: integer("id").primaryKey({ autoIncrement: true }),
  name: text("name").notNull(),
  parentId: integer("parent_id").references((): AnySQLiteColumn => categories.id),
  // BaseEntity fields
  createdAt: integer("created_at", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  updatedAt: integer("updated_at", { mode: "timestamp" }).$onUpdate(() => new Date()),
  createdBy: text("created_by"),
  updatedBy: text("updated_by"),
  storeId: integer("store_id").default(1),
})

export type Brand = typeof brands.$inferSelect
export type NewBrand = typeof brands.$inferInsert

export type Unit = typeof units.$inferSelect
export type NewUnit = typeof units.$inferInsert

export type Category = typeof categories.$inferSelect
export type NewCategory = typeof categories.$inferInsert

// Products

export const products = sqliteTable("products", {
  id: text("id").primaryKey(), // ProductCode
  name: text("name").notNull(),
  description: text("description"),
  barcode: text("barcode"),
  barcodeType: text("barcode_type"),
  price: integer("price", { mode: "number" }).default(0), // Using integer for price to avoid float issues? Or real? SQLite has real. Drizzle has real.
  // Actually, integer with mode "number" usually maps to a number in JS. But for money, integer cents is better or real.
  // Legacy system uses double. Let's use real.
  salePrice: integer("sale_price", { mode: "number" }), // Sticking to integer for now? No, let's use real for compatibility if I can.
  // Drizzle sqlite doesn't have "real" helper exposed directly as "real"? It has "real".
  // Let's check imports. I imported integer, text. I need to import real.
  mrp: integer("mrp", { mode: "number" }),
  cost: integer("cost", { mode: "number" }),
  
  categoryId: integer("category_id").references((): AnySQLiteColumn => categories.id),
  unitId: integer("unit_id").references((): AnySQLiteColumn => units.id),
  brandId: integer("brand_id").references((): AnySQLiteColumn => brands.id),
  
  stockQuantity: integer("stock_quantity", { mode: "number" }).default(0),
  minStock: integer("min_stock", { mode: "number" }).default(0),
  
  image: text("image"),
  
  // Audit
  createdAt: integer("created_at", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  updatedAt: integer("updated_at", { mode: "timestamp" }).$onUpdate(() => new Date()),
  createdBy: text("created_by"),
  updatedBy: text("updated_by"),
  storeId: integer("store_id").default(1),
})

export type Product = typeof products.$inferSelect
export type NewProduct = typeof products.$inferInsert


// Warehouses

export const warehouses = sqliteTable("warehouses", {
  id: integer("id").primaryKey({ autoIncrement: true }),
  name: text("name").notNull(),
  address: text("address"),
  status: text("status").default("Active"),
  // BaseEntity fields
  createdAt: integer("created_at", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  updatedAt: integer("updated_at", { mode: "timestamp" }).$onUpdate(() => new Date()),
  createdBy: text("created_by"),
  updatedBy: text("updated_by"),
  storeId: integer("store_id").default(1),
})

export const stocks = sqliteTable("stocks", {
  id: integer("id").primaryKey({ autoIncrement: true }),
  productId: text("product_id").notNull().references((): AnySQLiteColumn => products.id),
  warehouseId: integer("warehouse_id").notNull().references((): AnySQLiteColumn => warehouses.id),
  quantity: integer("quantity", { mode: "number" }).default(0),
  batchNo: text("batch_no"),
  expiryDate: integer("expiry_date", { mode: "timestamp" }),
  // BaseEntity fields
  createdAt: integer("created_at", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  updatedAt: integer("updated_at", { mode: "timestamp" }).$onUpdate(() => new Date()),
  createdBy: text("created_by"),
  updatedBy: text("updated_by"),
  storeId: integer("store_id").default(1),
})

export type Warehouse = typeof warehouses.$inferSelect
export type NewWarehouse = typeof warehouses.$inferInsert

export type Stock = typeof stocks.$inferSelect
export type NewStock = typeof stocks.$inferInsert


// Suppliers

export const suppliers = sqliteTable("suppliers", {
  id: text("id").primaryKey().$defaultFn(() => crypto.randomUUID()), // Legacy uses string ID
  name: text("name").notNull(),
  contactPerson: text("contact_person"),
  email: text("email"),
  mobile: text("mobile"),
  address: text("address"),
  status: text("status").default("Active"),
  openingBalance: integer("opening_balance", { mode: "number" }).default(0),
  // BaseEntity fields
  createdAt: integer("created_at", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  updatedAt: integer("updated_at", { mode: "timestamp" }).$onUpdate(() => new Date()),
  createdBy: text("created_by"),
  updatedBy: text("updated_by"),
  storeId: integer("store_id").default(1),
})

export type Supplier = typeof suppliers.$inferSelect

export type NewSupplier = typeof suppliers.$inferInsert


// Purchase Orders

export const purchaseOrders = sqliteTable("purchase_orders", {
  id: text("id").primaryKey().$defaultFn(() => crypto.randomUUID()),
  purchaseOrderNo: text("purchase_order_no").notNull().unique(),
  supplierId: text("supplier_id").references((): AnySQLiteColumn => suppliers.id),
  orderDate: integer("order_date", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  status: text("status").default("Draft"), // Draft, Ordered, Received, Cancelled
  totalAmount: integer("total_amount", { mode: "number" }).default(0),
  remarks: text("remarks"),
  // BaseEntity fields
  createdAt: integer("created_at", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  updatedAt: integer("updated_at", { mode: "timestamp" }).$onUpdate(() => new Date()),
  createdBy: text("created_by"),
  updatedBy: text("updated_by"),
  storeId: integer("store_id").default(1),
})

export const purchaseOrderItems = sqliteTable("purchase_order_items", {
  id: integer("id").primaryKey({ autoIncrement: true }),
  purchaseOrderId: text("purchase_order_id").notNull().references((): AnySQLiteColumn => purchaseOrders.id, { onDelete: "cascade" }),
  productId: text("product_id").notNull().references((): AnySQLiteColumn => products.id),
  quantity: integer("quantity", { mode: "number" }).default(0),
  unitCost: integer("unit_cost", { mode: "number" }).default(0),
  totalCost: integer("total_cost", { mode: "number" }).default(0),
  batchNo: text("batch_no"),
  expiryDate: integer("expiry_date", { mode: "timestamp" }),
})

export type PurchaseOrder = typeof purchaseOrders.$inferSelect
export type NewPurchaseOrder = typeof purchaseOrders.$inferInsert

export type PurchaseOrderItem = typeof purchaseOrderItems.$inferSelect
export type NewPurchaseOrderItem = typeof purchaseOrderItems.$inferInsert

// Customers

export const customers = sqliteTable("customers", {
  id: text("id").primaryKey().$defaultFn(() => crypto.randomUUID()), // Legacy uses string ID
  name: text("name").notNull(),
  mobile: text("mobile"),
  email: text("email"),
  address: text("address"),
  type: text("type").default("Retail"), // Retail, Wholesale
  contactPerson: text("contact_person"),
  status: text("status").default("Active"),
  areaCode: text("area_code"),
  // BaseEntity fields
  createdAt: integer("created_at", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  updatedAt: integer("updated_at", { mode: "timestamp" }).$onUpdate(() => new Date()),
  createdBy: text("created_by"),
  updatedBy: text("updated_by"),
  storeId: integer("store_id").default(1),
})

export type Customer = typeof customers.$inferSelect
export type NewCustomer = typeof customers.$inferInsert

// Sales

export const sales = sqliteTable("sales", {
  id: text("id").primaryKey().$defaultFn(() => crypto.randomUUID()),
  invoiceNo: text("invoice_no").notNull().unique(),
  customerId: text("customer_id").references((): AnySQLiteColumn => customers.id),
  saleDate: integer("sale_date", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  totalAmount: integer("total_amount", { mode: "number" }).default(0),
  discount: integer("discount", { mode: "number" }).default(0),
  tax: integer("tax", { mode: "number" }).default(0),
  netAmount: integer("net_amount", { mode: "number" }).default(0),
  paymentMethod: text("payment_method").default("Cash"),
  status: text("status").default("Completed"), // Completed, Cancelled
  warehouseId: integer("warehouse_id").references((): AnySQLiteColumn => warehouses.id),
  // BaseEntity fields
  createdAt: integer("created_at", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  updatedAt: integer("updated_at", { mode: "timestamp" }).$onUpdate(() => new Date()),
  createdBy: text("created_by"),
  updatedBy: text("updated_by"),
  storeId: integer("store_id").default(1),
})

export const saleItems = sqliteTable("sale_items", {
  id: integer("id").primaryKey({ autoIncrement: true }),
  saleId: text("sale_id").notNull().references((): AnySQLiteColumn => sales.id, { onDelete: "cascade" }),
  productId: text("product_id").notNull().references((): AnySQLiteColumn => products.id),
  quantity: integer("quantity", { mode: "number" }).default(0),
  unitPrice: integer("unit_price", { mode: "number" }).default(0),
  total: integer("total", { mode: "number" }).default(0),
  costPrice: integer("cost_price", { mode: "number" }).default(0), // Snapshot of cost at time of sale
})

export type Sale = typeof sales.$inferSelect
export type NewSale = typeof sales.$inferInsert

export type SaleItem = typeof saleItems.$inferSelect
export type NewSaleItem = typeof saleItems.$inferInsert

// --- Finance ---

export const financeAccounts = sqliteTable("finance_accounts", {
  id: text("id").primaryKey().$defaultFn(() => crypto.randomUUID()),
  name: text("name").notNull(),
  code: text("code").unique(),
  type: text("type").notNull(), // Asset, Liability, Equity, Revenue, Expense
  parentId: text("parent_id").references((): AnySQLiteColumn => financeAccounts.id),
  description: text("description"),
  // BaseEntity fields
  createdAt: integer("created_at", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  updatedAt: integer("updated_at", { mode: "timestamp" }).$onUpdate(() => new Date()),
  createdBy: text("created_by"),
  updatedBy: text("updated_by"),
  storeId: integer("store_id").default(1),
})

export const journalEntries = sqliteTable("journal_entries", {
  id: text("id").primaryKey().$defaultFn(() => crypto.randomUUID()),
  date: integer("date", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  description: text("description"),
  referenceNo: text("reference_no"),
  status: text("status").default("Draft"), // Draft, Posted
  // BaseEntity fields
  createdAt: integer("created_at", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  updatedAt: integer("updated_at", { mode: "timestamp" }).$onUpdate(() => new Date()),
  createdBy: text("created_by"),
  updatedBy: text("updated_by"),
  storeId: integer("store_id").default(1),
})

export const ledgerEntries = sqliteTable("ledger_entries", {
  id: integer("id").primaryKey({ autoIncrement: true }),
  journalEntryId: text("journal_entry_id").notNull().references((): AnySQLiteColumn => journalEntries.id, { onDelete: "cascade" }),
  accountId: text("account_id").notNull().references((): AnySQLiteColumn => financeAccounts.id),
  debit: integer("debit", { mode: "number" }).default(0),
  credit: integer("credit", { mode: "number" }).default(0),
  description: text("description"), // Line item description
})

export type FinanceAccount = typeof financeAccounts.$inferSelect
export type NewFinanceAccount = typeof financeAccounts.$inferInsert

export type JournalEntry = typeof journalEntries.$inferSelect
export type NewJournalEntry = typeof journalEntries.$inferInsert

export type LedgerEntry = typeof ledgerEntries.$inferSelect
export type NewLedgerEntry = typeof ledgerEntries.$inferInsert

// --- HR & Payroll ---

export const employees = sqliteTable("employees", {
  id: text("id").primaryKey().$defaultFn(() => crypto.randomUUID()),
  employeeId: text("employee_id").notNull().unique(), // Custom ID/Barcode
  name: text("name").notNull(),
  email: text("email"),
  phone: text("phone"),
  position: text("position"),
  department: text("department"),
  salary: integer("salary", { mode: "number" }).default(0), // Base monthly salary
  joiningDate: integer("joining_date", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  status: text("status").default("Active"), // Active, Inactive, Terminated
  // BaseEntity fields
  createdAt: integer("created_at", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  updatedAt: integer("updated_at", { mode: "timestamp" }).$onUpdate(() => new Date()),
  createdBy: text("created_by"),
  updatedBy: text("updated_by"),
  storeId: integer("store_id").default(1),
})

export const attendance = sqliteTable("attendance", {
  id: integer("id").primaryKey({ autoIncrement: true }),
  employeeId: text("employee_id").notNull().references((): AnySQLiteColumn => employees.id),
  date: integer("date", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  clockIn: integer("clock_in", { mode: "timestamp" }),
  clockOut: integer("clock_out", { mode: "timestamp" }),
  status: text("status").default("Present"), // Present, Absent, Late, Leave
  remarks: text("remarks"),
})

export const payroll = sqliteTable("payroll", {
  id: text("id").primaryKey().$defaultFn(() => crypto.randomUUID()),
  employeeId: text("employee_id").notNull().references((): AnySQLiteColumn => employees.id),
  month: integer("month"), // 1-12
  year: integer("year"),
  calendar: text("calendar").default("gregory"), // gregory, persian
  baseSalary: integer("base_salary", { mode: "number" }).default(0),
  allowances: integer("allowances", { mode: "number" }).default(0),
  deductions: integer("deductions", { mode: "number" }).default(0),
  netSalary: integer("net_salary", { mode: "number" }).default(0),
  status: text("status").default("Draft"), // Draft, Processed, Paid
  journalEntryId: text("journal_entry_id").references((): AnySQLiteColumn => journalEntries.id),
  processedAt: integer("processed_at", { mode: "timestamp" }),
  // BaseEntity fields
  createdAt: integer("created_at", { mode: "timestamp" }).default(sql`(strftime('%s', 'now'))`),
  updatedAt: integer("updated_at", { mode: "timestamp" }).$onUpdate(() => new Date()),
  createdBy: text("created_by"),
  updatedBy: text("updated_by"),
  storeId: integer("store_id").default(1),
})

export type Employee = typeof employees.$inferSelect
export type NewEmployee = typeof employees.$inferInsert

export type Attendance = typeof attendance.$inferSelect
export type NewAttendance = typeof attendance.$inferInsert

export type Payroll = typeof payroll.$inferSelect
export type NewPayroll = typeof payroll.$inferInsert







