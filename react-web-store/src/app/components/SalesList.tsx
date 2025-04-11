// components/SalesList.tsx
'use client';

import React, { useEffect, useState } from "react";
import { getActiveSales } from "@/services/productService";
import { SaleModel } from "@/data/SaleModel";
import "@/styles/sales.css";
import SaleCard from "./SaleCard";

const imagesUrl = 'http://umbraco.creativehandsco.com/';
const SalesList = () => {
    const [sales, setSales] = useState<SaleModel[]>([]);

    useEffect(() => {
        getActiveSales().then(setSales);
    }, []);

    return (
        <div className="sales-list">
            <h2>🔥 Active Sales</h2>
            {sales.length === 0 && <p>No sales available right now.</p>}

            {sales.map((sale, index) => (
                <div key={index}>
                    <SaleCard sale={sale} />
                </div>
            ))}
        </div>
    );
};

export default SalesList;
