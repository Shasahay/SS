import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable} from 'rxjs/Rx';
import { IDeliveryMethod } from 'src/app/model/order/deliveryMethod';
import { IOrder, IOrderToCreate } from 'src/app/model/order/order';
import { environment } from 'src/environments/environment';
import { HelperService } from '../../helper/helper.service';

@Injectable({
    providedIn: 'root'
  })

  export class OrderAPIService{
    public dataUrl = environment.apiUrl;
    public controller = 'Order';
    constructor( private http: HttpClient, private helperService : HelperService)   {  }

    getDeliveryMethod():Observable<IDeliveryMethod[]>{
       return this.helperService.getFromService(this.controller + '/delivery-method')
        .map((response) => response as IDeliveryMethod[]).catch(this.helperService.handleError)
    };

     createOrder(ordertoCreate: IOrderToCreate):Observable<IOrder>{
       return this.helperService.postToService(this.controller + '/create-order', ordertoCreate)
       .map((response) => response as IOrder).catch(this.helperService.handleError)
     };

     getUserOrder(): Observable<IOrder[]>{
       return this.helperService.getFromService(this.controller)
       .map((response) => response as IOrder[]).catch(this.helperService.handleError)
     };

     getUserOrderById(orderId: number): Observable<IOrder>{
      return this.helperService.getFromService(this.controller+'/' +orderId)
      .map((response) => response as IOrder).catch(this.helperService.handleError)
    }
   }
