export interface UploadFilesResponse {
    VideoId: number;
    ProductId: number;
    PurchaseId: number;
    UploadedImages: string[];
}

export interface GetCartResponse {
    Id: number;
    OrderItems: OrderItemResponse[];
}

export interface OrderItemResponse {
    Id: number;
    Product: {
        Id: number;
        Name: string;
        // Add more if needed
    };
    Quantity: number;
    UnitPrice: number;
    ProductVariation?: {
        Id: number;
    } | null;
    Colours?: string[]; // or whatever structure you have
}
