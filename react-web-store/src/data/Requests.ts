 export type GetOrderRequest = {
    OrderId: number;
    CustomerId: number;
    CustomerName: string;
    CustomerTel: string;
    StatusId: number;
     
};

export interface GetProductRequest {
    id?: number;
    name?: string;
    description?: string;
    barcode?: string;
    categoryId?: number;
    subCategoryId?: number;
}


export interface AddToCartRequest {
    UserId: string;
    ProductId: number;
    ProductVariationId?: number;
    Quantity: number;
    ProductPrice: number;
    ProductSalePrice: number;
    ProductUnitPrice: number;
    OrderId: number;
    Note: string;
    OrderItemColours?: string[];
}

export interface SendOrderRequest {
    OrderId: number;
    UserID: string;
    CustomerName: string;
    CustomerTel: string;
    Address: string;
    Notes: string;
}
