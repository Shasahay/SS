import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DefaultListResponse } from '../model/defaultlistresponse';
import { ProductFilter } from '../model/product/productfilter';
import { ProductResponse } from '../model/product/productresponse';
import { ProductAPIService } from '../services/module/product/product.api.service';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
  })

  export class StoreService {

    products: ProductResponse[] = [];
    prodList = new DefaultListResponse();
    storeParams = new ProductFilter();
    constructor( private http: HttpClient, private productService : ProductAPIService){ 
        //this.setStoreParams();
      }


    getProducts(useCache: boolean) {

        if (useCache === false) {
          this.products = [];
        }

        // Below Parameter check later
    
        // if (this.products.length > 0 && useCache === true) {
        //   const pagesReceived = Math.ceil(this.products.length / this.storeParams.pageSize);
    
        //   if (this.storeParams.pageNumber <= pagesReceived) {
        //     this.prodList.data = this.products.slice((this.storeParams.pageNumber - 1) *
        //     this.storeParams.pageSize, this.storeParams.pageNumber * this.storeParams.pageSize);
    
        //     return of(this.prodList);
        //   }
        // }
        // let params = new HttpParams();
    
        // if (this.storeParams.categoryId !== 0) {
        //   params = params.append('categogyId', this.storeParams.brandId.toString());
        // }
       
    
        // //params = params.append('sort', this.shopParams.sort);
        // params = params.append('pageIndex', this.storeParams.pageNumber.toString());
        // params = params.append('pageIndex', this.storeParams.pageSize.toString());
    
        // if (this.storeParams.search) {
        //   params = params.append('search', this.storeParams.search);
        // }

            return this.productService.getProduct(this.storeParams).pipe(
                map(response => {
                  // Filled array once all products loaded
                  // will append the new set of data with existing set
                  this.products = [...this.products, ...response.data];
                  this.prodList = response;
                  return this.prodList;
                })
              );

      }

    getProduct(id: number) {
        // basically angular components throw everything once we switch to another component...
        // Hence, returning from service is best way to stay efficient
        // Then once by id product is accessed, it gets retrieved from products array directly as a cached result.
        const product = this.products.find(p => p.productId === id);
    
        if (product) {
          return of(product);
        }
        return this.productService.getProductBYId(id);
      }

      setStoreParams(filter: ProductFilter) {
        this.storeParams = filter;
      }
    
      getStoreParams() {
        return this.storeParams;
      }
    
      getSubCategory(){
        return this.productService.getSubCategory();
      }

      getCategory(){
        return this.productService.getCategory();
      }

      getProductMapping(productId: number){
        return this.productService.getProductMappingById(productId);
      }
  }


  