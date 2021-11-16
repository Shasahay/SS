import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { OrderAPIService } from '../services/module/order/order.api.service';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  baseUrl = environment.apiUrl;

  constructor(private orderService: OrderAPIService) { }

  getOrdersForUser() {
    return this.orderService.getUserOrder();
    //return this.http.get(this.baseUrl + 'orders');
  }

  getOrderDetails(id: number) {
    debugger
    return this.orderService.getUserOrderById(id);
    //return this.http.get(this.baseUrl + 'orders/' + id);
  }
}
