import { ProductModel } from "@/data/ProductModel";
import { GetProductRequest } from "@/data/Requests";

const API_URL = "http://umbraco-api.creativehandsco.com/api/Products/GetProducts"; // Adjust if needed
//const API_URL = "http://localhost:5262/api/products/GetProducts"; // Adjust if needed
export async function fetchProducts(request: GetProductRequest = {}): Promise<ProductModel[]> {
    const res = await fetch(API_URL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(request)
    });

    if (!res.ok) {
        console.error("Failed to fetch products");
        return [];
    }

    return res.json();
}
