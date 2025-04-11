import { ProductModel } from "@/data/ProductModel";
import { GetProductRequest } from "@/data/Requests";
import { SaleModel } from "@/data/SaleModel";

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

export const getActiveSales = async (): Promise<SaleModel[]> => {
    try {
        const res = await fetch("http://umbraco-api.creativehandsco.com/api/Products/GetActiveSales"); // update to deployed API if needed
        if (!res.ok) throw new Error("Failed to fetch active sales");

        return await res.json();
    } catch (error) {
        console.error("Error fetching sales:", error);
        return [];
    }
};
