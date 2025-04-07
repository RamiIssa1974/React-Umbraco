'use client';

import { useEffect } from "react";
import { useProductStore } from "@/stores/productStore";
import "./products.css";

export default function ProductsPage() {
    const { products, fetchProducts, hasHydrated } = useProductStore();

    useEffect(() => {
        
        if (hasHydrated && products.length === 0) {
            console.log("products.length: ", products.length);
            console.log("products: ", products);
            fetchProducts();
        }
    }, []);

    return (
        <div className="products-container">
            <h1>Products</h1>
            <table className="products-table">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Name</th>
                        <th>Price</th>
                        <th>Barcode</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map((p, index) => (
                        <tr key={p.id}>
                            <td>{index + 1}</td>
                            <td>{p.productName}</td>
                            <td>{p.price}</td>
                            <td>{p.barcode}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}
