import { Product } from "@/db/schema"

interface ProductCardProps {
    product: Product
    onSelect: (product: Product) => void
}

export function ProductCard({ product, onSelect }: ProductCardProps) {
    return (
        <button
            onClick={() => onSelect(product)}
            className="flex flex-col items-center justify-between p-4 border rounded-lg hover:bg-slate-50 transition-colors text-center h-40 bg-white shadow-sm"
        >
            <div className="text-sm font-medium line-clamp-2">{product.name}</div>
            <div className="text-xs text-muted-foreground">{product.barcode}</div>
            <div className="mt-2 font-bold text-lg text-primary">
                ${product.price?.toFixed(2)}
            </div>
            <div className="text-xs text-muted-foreground">
                Stock: {product.stockQuantity || 0}
            </div>
        </button>
    )
}
