 
import { CategoryModel } from './CategoryModel';
import { ProductVariationModel } from './ProductVariationModel';
import { ColorModel } from './ColorModel';

export interface ProductModel {
    id: number;
    productName: string;
    price: number;
    salePrice: number;
    barcode: string;
    description: string; // could be changed to a richer type later if needed
    stockQuantity: number;
    categories: CategoryModel[];
    availableColors: ColorModel[];
    productVariations: ProductVariationModel[];
    images: string[];
}
