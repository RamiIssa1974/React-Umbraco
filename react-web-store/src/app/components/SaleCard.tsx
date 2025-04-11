// components/SaleCard.tsx
import React from "react";
import { SaleModel } from "@/services/productService";

const imagesUrl = 'http://umbraco.creativehandsco.com/';

interface SaleCardProps {
    sale: SaleModel;
}

const SaleCard: React.FC<SaleCardProps> = ({ sale }) => {
    return (
        <div className="sale-card">
            <img src={imagesUrl + sale.imageUrl} alt={sale.title} />
            <h3>{sale.title}</h3>
            <p>
                <strike>{sale.normalPrice} ₪</strike>{" "}
                <strong>{sale.salePrice} ₪</strong>
            </p>
            <ul>
                {sale.specifications.map((spec, i) => (
                    <li key={i}>{spec}</li>
                ))}
            </ul>
            <small dangerouslySetInnerHTML={{ __html: sale.legalInfo }} />
        </div>
    );
};

export default SaleCard;
