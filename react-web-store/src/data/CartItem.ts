import { ProductVariationModel } from "./ProductVariationModel";

// Types for a single cart item
export interface CartItem {
    productId: number;
    productName: string;
    quantity: number;
    color: string;
    price: number;
    salePrice?: number;
    selectedVariationId?: number;
    selectedVariation?: ProductVariationModel | null;
    note?: string;
}
