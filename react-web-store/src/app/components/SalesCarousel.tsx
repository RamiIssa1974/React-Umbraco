// components/SalesCarousel.tsx
'use client';

import React, { useEffect, useState } from "react";
import Slider from "react-slick";
import { getActiveSales, SaleModel } from "@/services/productService";
import "@/styles/sales.css";
import SaleCard from "./SaleCard";

const imagesUrl = 'http://umbraco.creativehandsco.com/';
const SalesCarousel = () => {
    const [sales, setSales] = useState<SaleModel[]>([]);

    useEffect(() => {
        getActiveSales().then(setSales);
    }, []);

    const settings = {
        dots: true,
        infinite: true,
        speed: 500,
        slidesToShow: 2,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 4000,
        arrows: true,
    };

    return (
        <div className="sales-list">
            <h2>🔥 Active Sales</h2>

            {sales.length === 0 ? (
                <p>No sales available right now.</p>
            ) : (
                <Slider {...settings}>
                    {sales.map((sale, index) => (
                        <div key={index}>
                            <SaleCard sale={sale} />
                        </div>
                    ))}

                </Slider>
            )}
        </div>
    );
};

export default SalesCarousel;
