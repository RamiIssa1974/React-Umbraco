import { CustomerDetails } from "./CustomerDetails";
import { OrderItemModel } from "./OrderItemModel";

export type OrderModel = {
    id: number;
    userId?: string;
    customerId: number;
    statusId: number;
    deleveryPrice: number;
    createDate: string; // DateTime in backend → string (ISO format) in frontend
    address?: string | null;
    notes?: string | null;
    discount: number;
    customer: CustomerDetails;
    orderItems: OrderItemModel[];
};
