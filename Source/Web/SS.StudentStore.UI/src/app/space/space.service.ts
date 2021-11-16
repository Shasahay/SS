import { Injectable } from '@angular/core';
import { OrderAPIService } from '../services/module/order/order.api.service';
import { ProductAPIService } from '../services/module/product/product.api.service';

@Injectable({
  providedIn: 'root'
})
export class SpaceService {

  constructor(private productService: ProductAPIService) { }

  getUserOrderOnlineProduct(){
    return this.productService.getUserOrderedOnlineProductType();
  }
}
