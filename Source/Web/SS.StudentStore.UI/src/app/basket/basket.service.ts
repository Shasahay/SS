import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { IBasket, IBasketItem, Basket, IBasketTotals } from '../model/store/basket';
import { map } from 'rxjs/operators';
import { IProduct } from '../shared/models/product';
import { IDeliveryMethod } from '../model/order/deliveryMethod';
import { ProductResponse } from '../model/product/productresponse';
import { BasketAPIService } from '../services/module/shop/basket.api.service';
import { PaymentAPIService } from '../services/module/order/payment.api.service';
import { IProducttypeMapping } from '../model/product/producttypemapping';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  // similar to async pipe
  basket$ = this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<IBasketTotals>(null);
  basketTotals$ = this.basketTotalSource.asObservable();
  shipping = 0;

  constructor(private http: HttpClient, private basketApiService: BasketAPIService, private paymentService: PaymentAPIService) { }

  createPaymentIntent(){
    return this.paymentService.addOrUpdatePaymentIntent(this.getCurrentBasketValue().basketUId).pipe(
      map((basket: IBasket) =>{
          this.basketSource.next(basket);
      })
    )
    // return this.http.post(this.baseUrl + 'payments/' + this.getCurrentBasketValue().basketUId, {})
    //   .pipe(
    //     map((basket: IBasket) => {
    //       this.basketSource.next(basket);
    //     })
    //   );
  }

  setShippingPrice(deliveryMethod: IDeliveryMethod) {
    this.shipping = deliveryMethod.price;
    const basket = this.getCurrentBasketValue();
    basket.deliveryMethodId = deliveryMethod.deliveryMethodId;
    basket.shippingPrice = deliveryMethod.price;
    this.calculateTotals();
    this.setBasket(basket);
  }
  
  getBasket(uId: string) {
      return this.basketApiService.getBasket(uId).pipe(
              map((basket: IBasket) => {
                this.basketSource.next(basket);
                this.shipping = basket.shippingPrice;
                this.calculateTotals();
              }));
  }

  setBasket(basket: IBasket){
    var v = this.basketApiService.AddOrUpdateBasket(basket).subscribe( (response : IBasket) =>{
      this.basketSource.next(response);
      this.calculateTotals();
    })
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  // addItemToBasket(item: ProductResponse, quantity = 1) {
  //   const itemToAdd: IBasketItem = this.mapProductToBasketItem(item, quantity);
  //   const basket = this.getCurrentBasketValue() ?? this.createBasket();
  //   basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
  //   this.setBasket(basket);
  // }

  addItemToBasket(item: ProductResponse, productType: IProducttypeMapping, quantity = 1) {
    debugger
    const itemToAdd: IBasketItem = this.mapProductToBasketItem(item, productType, quantity);
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.setBasket(basket);
  }

  incrementItemQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(x => x.productId === item.productId);
    basket.items[foundItemIndex].quantity++;
    this.setBasket(basket);
  }

  decrementItemQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(x => x.productId === item.productId);
    if (basket.items[foundItemIndex].quantity > 1) {
      basket.items[foundItemIndex].quantity--;
      this.setBasket(basket);
    } else {
      this.removeItemFromBasket(item);
    }
  }
  removeItemFromBasket(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    if (basket.items.some(x => x.productId === item.productId)) {
      basket.items = basket.items.filter(x => x.basketItemId !== item.basketItemId)
      if (basket.items.length > 0) {
        this.setBasket(basket);
      } else {
        this.deleteBasket(basket);
      }
    }
  }

  deleteLocalBasket(id: string) {
    this.basketSource.next(null);
    this.basketTotalSource.next(null);
    localStorage.removeItem('basket_id');
  }

  deleteBasket(basket: IBasket) {

    return this.basketApiService.deleteBasket(basket.basketUId).subscribe (() => {
      this.basketSource.next(null);
      this.basketTotalSource.next(null);
      localStorage.removeItem('basket_id');
    }, error => {
      console.log(error);
    });
    // return this.http.delete(this.baseUrl + 'basket?id=' + basket.basketUId).subscribe (() => {
    //   this.basketSource.next(null);
    //   this.basketTotalSource.next(null);
    //   localStorage.removeItem('basket_id');
    // }, error => {
    //   console.log(error);
    // });
  }

 private calculateTotals() {
   const basket = this.getCurrentBasketValue();
   const shipping = this.shipping;
   const subtotal = basket.items.reduce((a, b) => (b.price * b.quantity) + a, 0);
   const total = shipping + subtotal;
   this.basketTotalSource.next({shipping, total, subtotal});
 }
 private addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    //const index = items.findIndex(i => i.productId === itemToAdd.productId);
    const index = items.findIndex(i => i.productId === itemToAdd.productId && i.productTypeId === itemToAdd.productTypeId);
    if (index === -1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity;
    }
    return items;
  }

  private createBasket(): IBasket {
    const basket = new Basket();
    basket.basketId = null;
    localStorage.setItem('basket_id', basket.basketUId);
    return basket;
  }

  private mapProductToBasketItem(item: ProductResponse, productType: IProducttypeMapping, quantity: number): IBasketItem {
    return {
      basketItemId: null,
      basketId:null,
      productId: item.productId,
      productName: item.name,
      productTypeId: productType.productTypeId,
      price: productType.price == undefined ? item.price : productType.price,
      pictureUrl: item.pictureUrl,
      quantity,
      numberOfMonths:quantity
    };
  }
}
