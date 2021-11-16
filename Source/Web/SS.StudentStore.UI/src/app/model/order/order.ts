import { IAddress } from '../Identity/address';

export interface IOrderToCreate {
    basketId: number;
    basketUId: string;
    deliveryMethodId: number;
    addressRequest: IAddress;
  }

export interface IOrder {
    orderId: number;
    userEmail: string;
    addressId: number;
    createdDate: string;
    deliveryMethodId: number;
    shippingPrice: number;
    orderItems: IOrderItem[];
    subtotal: number;
    total: number;
    status: string;
  }

export interface IOrderItem {
    orderItemId: number;
    orderId: number;
    productId: number;
    productName: string;
    price: number;
    quantity: number;
  }
