'use client'

import { Sale, SaleItem, Product } from "@/db/schema"
import { Separator } from "@/components/ui/separator"

interface ReceiptProps {
    sale: Partial<Sale>
    items: { product: Product, quantity: number }[]
    businessName?: string
    businessAddress?: string
    businessPhone?: string
}

import { useTranslations } from "next-intl"

export function Receipt({
    sale,
    items,
    businessName = "Inventory Brother",
    businessAddress = "123 Business Lane, City, Country",
    businessPhone = "+123 456 7890"
}: ReceiptProps) {
    const t = useTranslations("Receipt")
    const subtotal = items.reduce((sum, item) => sum + (item.quantity * (item.product.price || 0)), 0)
    const tax = sale.tax || 0
    const discount = sale.discount || 0
    const total = subtotal + tax - discount

    return (
        <div className="p-8 bg-white text-black font-mono text-sm max-w-[400px] mx-auto border" id="printable-receipt">
            <div className="text-center space-y-1 mb-6">
                <h1 className="text-xl font-bold uppercase">{businessName}</h1>
                <p className="text-xs">{businessAddress}</p>
                <p className="text-xs">{t('phoneLabel')} {businessPhone}</p>
            </div>

            <Separator className="my-4" />

            <div className="space-y-1 mb-4 flex justify-between text-xs">
                <div>
                    <p>{t('invoiceLabel')} <span className="font-bold">{sale.invoiceNo}</span></p>
                    <p>{t('dateLabel')} {new Date().toLocaleDateString()}</p>
                </div>
                <div className="text-right">
                    <p>{t('timeLabel')} {new Date().toLocaleTimeString()}</p>
                    <p>{t('customerLabel')} {sale.customerId || t('walkIn')}</p>
                </div>
            </div>

            <Separator className="my-4" />

            <table className="w-full mb-4">
                <thead>
                    <tr className="border-b text-xs">
                        <th className="text-left py-1">{t('itemHeader')}</th>
                        <th className="text-center py-1">{t('qtyHeader')}</th>
                        <th className="text-right py-1">{t('priceHeader')}</th>
                        <th className="text-right py-1">{t('totalHeader')}</th>
                    </tr>
                </thead>
                <tbody>
                    {items.map((item, idx) => (
                        <tr key={idx} className="text-xs">
                            <td className="py-2">{item.product.name}</td>
                            <td className="py-2 text-center">{item.quantity}</td>
                            <td className="py-2 text-right">${item.product.price?.toFixed(2)}</td>
                            <td className="py-2 text-right">${(item.quantity * (item.product.price || 0)).toFixed(2)}</td>
                        </tr>
                    ))}
                </tbody>
            </table>

            <Separator className="my-4" />

            <div className="space-y-1 text-xs">
                <div className="flex justify-between">
                    <span>{t('subtotal')}</span>
                    <span>${subtotal.toFixed(2)}</span>
                </div>
                <div className="flex justify-between">
                    <span>{t('tax')}</span>
                    <span>+${tax.toFixed(2)}</span>
                </div>
                <div className="flex justify-between">
                    <span>{t('discount')}</span>
                    <span>-${discount.toFixed(2)}</span>
                </div>
                <div className="flex justify-between font-bold text-lg pt-4 border-t mt-4 border-dashed">
                    <span>{t('total')}</span>
                    <span>${total.toFixed(2)}</span>
                </div>
            </div>

            <div className="mt-8 text-center text-[10px] space-y-1 text-gray-500 italic">
                <p>{t('thankYou')}</p>
                <p>{t('keepReceipt')}</p>
                <p>{t('poweredBy')}</p>
            </div>

            <style jsx global>{`
        @media print {
          body * {
            visibility: hidden;
          }
          #printable-receipt, #printable-receipt * {
            visibility: visible;
          }
          #printable-receipt {
            position: absolute;
            left: 0;
            top: 0;
            width: 100%;
            border: none;
          }
        }
      `}</style>
        </div>
    )
}
