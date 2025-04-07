import { ProductVariationModel } from "./ProductVariationModel";
export interface SaveProductRequest {
    id: number;
    name: string;
    description: string;
    barcode: string;
    price: number;
    salePrice: number | null;
    images: string[];            // Existing images (optional usage)
    uploadedImages: string[];    // Newly uploaded images from UploadFilesResponse
    categories: number[];
    productVariations: ProductVariationModel[];
    availableColours: string[];
    stockQuantity: number;
}
 