import { Pipe, PipeTransform } from '@angular/core';
import { ProductResponse } from 'src/app/model/product/productresponse';
import { Application_Constants } from '../constants/application-constant';

@Pipe({
  name: 'eproducts'
})
export class EproductsPipe implements PipeTransform {

  transform(value: ProductResponse[], ...args: unknown[]): ProductResponse[] {
    return this.getEproducts(value);
  }

  getEproducts(value: ProductResponse[]): ProductResponse[]{
    return value.filter( x=> x.productTypeId == Application_Constants.ebookProductTypeId);
  }

}
