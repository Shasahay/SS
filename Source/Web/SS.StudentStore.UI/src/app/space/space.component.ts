import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { IOrder, IOrderItem } from '../model/order/order';
import { ProductResponse } from '../model/product/productresponse';
import { Application_Constants } from '../shared/constants/application-constant';
import { SpaceService } from './space.service';

@Component({
  selector: 'app-space',
  templateUrl: './space.component.html',
  styleUrls: ['./space.component.scss']
})
export class SpaceComponent implements OnInit {
  userOrderProducts: ProductResponse[];
  ebookProducts: ProductResponse[];
  subscribeProducts: ProductResponse[];
  isExpanded = true;
  opened: boolean = true;
  src = "http://localhost:4200/assets/document/203010001.pdf"
  totalPages: number;
  page: number = 1;
  isLoaded: boolean = false;
  constructor( private spaceService: SpaceService, private ref: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.getUserOrderProduct()
  }

  getUserOrderProduct(){
    this.spaceService.getUserOrderOnlineProduct().subscribe((result) => {
      if(result != null || result != undefined){
        this.userOrderProducts = result;
        this.getUserEbookProduct(this.userOrderProducts);
        this.getUserSuscribeOrder(this.userOrderProducts);
      }
    })
  }

  getUserEbookProduct(product: ProductResponse[]){
    if(product != null && product.length > 0){
      this.ebookProducts = product.filter( x=> x.productTypeId == Application_Constants.ebookProductTypeId)
      this.ref.detectChanges();
    }
  }

  getUserSuscribeOrder(product: ProductResponse[]){
    if(product != null && product.length > 0){
      this.subscribeProducts = product.filter( x=> x.productTypeId == Application_Constants.subscribeProductTypeId)
      this.ref.detectChanges();
    }
  }
  browseProduct(event: ProductResponse){
    debugger
    var docUrl = undefined;
    if(event != null){
      var browseProduct = this.ebookProducts.find( x=> x.productId == event.productId && x.productTypeId == event.productTypeId)
      //docUrl = browseProduct.documentUrl;
      if(docUrl != undefined || docUrl != null){
        this.src = docUrl;
        this.src = "http://localhost:4200/assets/document/403000542.pdf";
      }
      this.src = "http://localhost:4200/assets/document/403000542.pdf";
    }
  };
  nextPage() {
    this.page += 1;
  }

  previousPage() {
    this.page -= 1;
  }

  afterLoadComplete(pdfData: any) {
    this.totalPages = pdfData.numPages;
    this.isLoaded = true;
  }
  itemclick(){
    alert("this is India");
  }
}
