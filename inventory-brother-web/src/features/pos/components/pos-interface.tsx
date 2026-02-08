'use client'

import { useState, useMemo } from "react"
import { Product, Customer } from "@/db/schema"
import { Input } from "@/components/ui/input"
import { Button } from "@/components/ui/button"
import { Search, User } from "lucide-react"
import {
    Select,
    SelectContent,
    SelectItem,
    SelectTrigger,
    SelectValue,
} from "@/components/ui/select"
import {
    Dialog,
    DialogContent,
    DialogHeader,
    DialogTitle,
    DialogFooter,
} from "@/components/ui/dialog"
import { Receipt } from "./receipt"
import { ProductCard } from "./product-card"
import { CartSummary } from "./cart-summary"
import { usePOS } from "../hooks/use-pos"

interface POSInterfaceProps {
    products: Product[]
    customers: Customer[]
    warehouseId: number
}

import { useTranslations } from "next-intl"

export function POSInterface({ products, customers, warehouseId }: POSInterfaceProps) {
    const t = useTranslations("POS")
    const commonT = useTranslations("Common")

    const {
        cart, addToCart, removeFromCart, updateQuantity,
        subtotal, discount, setDiscount, taxRate, setTaxRate,
        taxAmount, netAmount, selectedCustomerId, setSelectedCustomerId,
        processing, handleCheckout, lastSale, receiptOpen, setReceiptOpen
    } = usePOS(warehouseId)

    const [searchTerm, setSearchTerm] = useState("")

    const filteredProducts = useMemo(() => {
        return products.filter(p =>
            p.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
            (p.barcode && p.barcode.includes(searchTerm))
        )
    }, [products, searchTerm])

    const handlePrint = () => {
        window.print()
    }

    return (
        <div className="flex h-[calc(100vh-65px)] gap-4">
            <Dialog open={receiptOpen} onOpenChange={setReceiptOpen}>
                <DialogContent className="max-w-md print:p-0 print:border-none">
                    <DialogHeader className="print:hidden">
                        <DialogTitle>{t("receipt")}</DialogTitle>
                    </DialogHeader>
                    {lastSale && (
                        <Receipt
                            sale={lastSale.sale}
                            items={lastSale.items}
                        />
                    )}
                    <DialogFooter className="print:hidden">
                        <Button variant="outline" onClick={() => setReceiptOpen(false)}>{commonT("close")}</Button>
                        <Button onClick={handlePrint}>{commonT("print")}</Button>
                    </DialogFooter>
                </DialogContent>
            </Dialog>

            <div className="flex-1 flex flex-col gap-4 overflow-hidden">
                <div className="flex items-center gap-4 bg-white p-2 rounded-lg shadow-sm border">
                    <div className="relative flex-1">
                        <Search className="absolute left-2.5 top-2.5 h-4 w-4 text-muted-foreground" />
                        <Input
                            placeholder={t("searchPlaceholder")}
                            className="pl-8"
                            value={searchTerm}
                            onChange={(e) => setSearchTerm(e.target.value)}
                            autoFocus
                        />
                    </div>
                    <div className="w-[200px] flex items-center gap-2">
                        <User className="h-4 w-4 text-muted-foreground" />
                        <Select value={selectedCustomerId} onValueChange={setSelectedCustomerId}>
                            <SelectTrigger className="h-9">
                                <SelectValue placeholder={t("walkInCustomer")} />
                            </SelectTrigger>
                            <SelectContent>
                                <SelectItem value="walk-in">{t("walkInCustomer")}</SelectItem>
                                {customers.map(c => (
                                    <SelectItem key={c.id} value={c.id}>{c.name}</SelectItem>
                                ))}
                            </SelectContent>
                        </Select>
                    </div>
                </div>

                <div className="grid grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 gap-4 overflow-y-auto pb-4 pr-1">
                    {filteredProducts.map(product => (
                        <ProductCard
                            key={product.id}
                            product={product}
                            onSelect={addToCart}
                        />
                    ))}
                    {filteredProducts.length === 0 && (
                        <div className="col-span-full text-center py-10 text-muted-foreground bg-white border rounded-lg">
                            {commonT("error")}: {searchTerm}
                        </div>
                    )}
                </div>
            </div>

            <div className="w-[380px] shrink-0">
                <CartSummary
                    cart={cart}
                    subtotal={subtotal}
                    discount={discount}
                    setDiscount={setDiscount}
                    taxRate={taxRate}
                    setTaxRate={setTaxRate}
                    taxAmount={taxAmount}
                    netAmount={netAmount}
                    processing={processing}
                    onCheckout={handleCheckout}
                    onUpdateQuantity={updateQuantity}
                    onRemoveItem={removeFromCart}
                />
            </div>
        </div>
    )
}
