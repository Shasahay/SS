import { Injectable } from '@angular/core';
import { constants } from 'buffer';
import { ProductType } from '../model/product/producttype';
import { ProductAPIService } from '../services/module/product/product.api.service';
import { Application_Constants } from '../shared/constants/application-constant';

@Injectable({
  providedIn: 'root'
})
export class UploadService {

  constructor(private producService: ProductAPIService) { }

  getCategories(){
    return this.producService.getCategory();
  }
  getSubCategories(){
    return this.producService.getSubCategory();
  }
  getSection(){
    return this.producService.getSection();
  }
  getBrand(){
    return this.producService.getBrands();
  }
  getGrade(){
    return this.producService.getGrade();
  }

  getProductType(){
    //return this.producService.getProductTypes();
    // Currently Hard coding latter get from DB
    var  productType: ProductType[] = [ { productTypeId : Application_Constants.paperbackProductTypeId , name : 'Paper Book' },
                                        { productTypeId : Application_Constants.ebookProductTypeId , name : 'E Book' },
                                        { productTypeId : Application_Constants.subscribeProductTypeId , name : 'Subscription' }
                                      ]
   
             return productType;                         
  }
}
