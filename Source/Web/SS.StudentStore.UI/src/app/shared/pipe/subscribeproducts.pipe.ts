import { Pipe, PipeTransform } from '@angular/core';
import { ProductResponse } from 'src/app/model/product/productresponse';
import { Application_Constants } from '../constants/application-constant';

@Pipe({
  name: 'subscribeproducts'
})
export class SubscribeproductsPipe implements PipeTransform {

  transform(value: ProductResponse[], ...args: unknown[]): ProductResponse[] {
    return this.getSubscribeproducts(value);
  }

  getSubscribeproducts(value: ProductResponse[]): ProductResponse[]{
    return value.filter( x=> x.productTypeId == Application_Constants.subscribeProductTypeId);
  }


}
