import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { IDeliveryMethod } from '../model/order/deliveryMethod';
import { map } from 'rxjs/operators';
//import { IOrderToCreate } from '../shared/models/order';
import { IOrderToCreate } from '../model/order/order';
import { OrderAPIService } from '../services/module/order/order.api.service';
import { Observable } from 'rxjs';
import { IOrder } from '../shared/models/order';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient, private oderService: OrderAPIService) { }

  createOrder(order: IOrderToCreate){
    debugger
    return this.oderService.createOrder(order);
     
    //return this.http.post(this.baseUrl + '/orders/create-order', order);
  }

  getDeliveryMethods(): Observable<IDeliveryMethod[]> {
    return this.oderService.getDeliveryMethod().pipe(
      map((dm: IDeliveryMethod[]) => {
        return dm.sort((a,b) => b.price)
      })
    );

    // return this.http.get(this.baseUrl + 'orders/deliveryMethods').pipe(
    //   map((dm: IDeliveryMethod[]) => {
    //     return dm.sort((a, b) => b.price - a.price);
    //   })
    // );
  }
}
