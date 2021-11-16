import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Category } from '../model/product/category';
import { ProductFilter } from '../model/product/productfilter';
import { ProductResponse } from '../model/product/productresponse';
import { StoreService } from './store.service';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.scss']
})
export class StoreComponent implements OnInit {
  @ViewChild('search', {static:false}) searchTerm: ElementRef

  products: ProductResponse[] =[];
  productFilter: ProductFilter
  totalCount: number;
  constructor(private storeService: StoreService) {
    this.productFilter = this.storeService.getStoreParams();
   }

  ngOnInit(): void {
    //this.loadProducts(this.productFilter)
    this.loadProducts(false);
    
  }
  // loadProducts(filter: ProductFilter){
  //   this.productService.getProduct(filter).subscribe(res =>{
  //       this.products = res.data;
  //       this.totalCount = res.totalCount;
  //    }  )
  // }

  loadProducts(useCache = false){
    this.storeService.getProducts(useCache).subscribe(res =>{
        this.products = res.data;
        this.totalCount = res.totalCount;
     }  )
  }

  onPageChanged(event: any){
    const params = this.storeService.getStoreParams();
    if(params.pageNumber !==event){
      params.pageNumber = event;
      this.storeService.setStoreParams(params);
      this.loadProducts(true);
    }
  }

  onSearch(){
    const params = this.storeService.getStoreParams();
    params.search = this.searchTerm.nativeElement.value;
    params.pageNumber = 1;
    this.storeService.setStoreParams(params);
    this.loadProducts();
  }

  onReset(){
    this.searchTerm.nativeElement.value = '';
    this.productFilter = new ProductFilter();
    this.storeService.setStoreParams(this.productFilter);
    this.loadProducts();
  }
  onCategorySelectedHandle(categoryId){
    const params = this.storeService.getStoreParams();
    params.categoryId = categoryId;
    params.pageNumber = 1;
   this.storeService.setStoreParams(params);
   this.loadProducts();
  }
  onSubCategorySelectedHandle(subCategoryId){
    const params = this.storeService.getStoreParams();
    params.subCategoryId = subCategoryId;
    params.pageNumber = 1;
   this.storeService.setStoreParams(params);
   this.loadProducts();
  }
}
