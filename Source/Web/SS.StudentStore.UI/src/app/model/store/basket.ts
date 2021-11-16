import { v4 as uuidv4 } from 'uuid';


export interface IBasket {
    basketId: number;
    basketUId: string;
    items: IBasketItem[];
    clientSecret?: string;
    paymentIntentId?: string;
    deliveryMethodId?: number;
    shippingPrice?: number;
  }

export interface IBasketItem {
    basketItemId: number;
    basketId: number;
    productId: number;
    productName: string;
    productTypeId: number;
    price: number;
    quantity: number;
    pictureUrl: string;
    numberOfMonths:number
  }

  export class Basket implements IBasket {
    basketId: number;
    basketUId = uuidv4();
      items: IBasketItem[] = [];
     }



export interface IBasketTotals {
  shipping: number;
  subtotal: number;
  total: number;
}
