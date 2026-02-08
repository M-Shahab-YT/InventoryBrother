import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Card } from "@/components/ui/card"
import { Trash2, Plus, Minus, CreditCard, Banknote } from "lucide-react"
import { CartItem } from "@/types/pos"
import { useTranslations } from "next-intl"

interface CartSummaryProps {
    cart: CartItem[]
    subtotal: number
    discount: number
    setDiscount: (val: number) => void
    taxRate: number
    setTaxRate: (val: number) => void
    taxAmount: number
    netAmount: number
    processing: boolean
    onCheckout: () => void
    onUpdateQuantity: (productId: string, qty: number) => void
    onRemoveItem: (productId: string) => void
}

export function CartSummary({
    cart, subtotal, discount, setDiscount, taxRate, setTaxRate, taxAmount, netAmount, processing, onCheckout, onUpdateQuantity, onRemoveItem
}: CartSummaryProps) {
    const t = useTranslations("POS")

    return (
        <Card className="flex flex-col h-full bg-slate-50 border-l rounded-none p-0 overflow-hidden">
            <div className="p-4 border-b bg-white">
                <h2 className="text-lg font-bold">{t("currentSale")}</h2>
            </div>

            <div className="flex-1 overflow-y-auto p-4 space-y-4">
                {cart.length === 0 ? (
                    <div className="text-center text-muted-foreground mt-10">{t("emptyCart")}</div>
                ) : (
                    cart.map((item) => (
                        <div key={item.product.id} className="flex items-center justify-between bg-white p-3 rounded-lg shadow-sm border">
                            <div className="flex-1">
                                <div className="font-medium text-sm line-clamp-1">{item.product.name}</div>
                                <div className="text-xs text-muted-foreground">${item.product.price?.toFixed(2)} x {item.quantity}</div>
                            </div>
                            <div className="flex items-center gap-2">
                                <div className="flex items-center border rounded">
                                    <Button variant="ghost" size="icon" className="h-7 w-7" onClick={() => onUpdateQuantity(item.product.id, item.quantity - 1)} disabled={item.quantity <= 1}>
                                        <Minus className="h-3 w-3" />
                                    </Button>
                                    <span className="w-6 text-center text-xs">{item.quantity}</span>
                                    <Button variant="ghost" size="icon" className="h-7 w-7" onClick={() => onUpdateQuantity(item.product.id, item.quantity + 1)}>
                                        <Plus className="h-3 w-3" />
                                    </Button>
                                </div>
                                <Button variant="ghost" size="icon" className="h-8 w-8 text-destructive" onClick={() => onRemoveItem(item.product.id)}>
                                    <Trash2 className="h-4 w-4" />
                                </Button>
                            </div>
                        </div>
                    ))
                )}
            </div>

            <div className="p-4 bg-white border-t space-y-3">
                <div className="grid grid-cols-2 gap-2">
                    <div className="space-y-1">
                        <label className="text-xs font-medium">{t("discount")} ($)</label>
                        <Input type="number" value={discount} onChange={(e) => setDiscount(Number(e.target.value))} className="h-8 text-sm" />
                    </div>
                    <div className="space-y-1">
                        <label className="text-xs font-medium">{t("tax")} (%)</label>
                        <Input type="number" value={taxRate} onChange={(e) => setTaxRate(Number(e.target.value))} className="h-8 text-sm" />
                    </div>
                </div>

                <div className="space-y-1 pt-2">
                    <div className="flex justify-between text-sm">
                        <span>{t("subtotal")}</span>
                        <span>${subtotal.toFixed(2)}</span>
                    </div>
                    <div className="flex justify-between text-sm text-muted-foreground">
                        <span>{t("tax")} ({taxRate}%)</span>
                        <span>${taxAmount.toFixed(2)}</span>
                    </div>
                    <div className="flex justify-between text-sm text-destructive">
                        <span>{t("discount")}</span>
                        <span>-${discount.toFixed(2)}</span>
                    </div>
                    <div className="flex justify-between text-xl font-bold border-t pt-2 mt-2">
                        <span>{t("total")}</span>
                        <span>${netAmount.toFixed(2)}</span>
                    </div>
                </div>

                <div className="grid grid-cols-2 gap-2 mt-4">
                    <Button variant="outline" className="flex items-center gap-2" disabled={processing}>
                        <CreditCard className="h-4 w-4" /> {t("card")}
                    </Button>
                    <Button className="flex items-center gap-2 h-12 text-lg font-bold" disabled={cart.length === 0 || processing} onClick={onCheckout}>
                        <Banknote className="h-5 w-5" /> {processing ? t("processing") : t("checkout")}
                    </Button>
                </div>
            </div>
        </Card>
    )
}
