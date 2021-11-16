import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { ProductResponse } from 'src/app/model/product/productresponse';
import { SpaceService } from '../space.service';

@Component({
  selector: 'app-electronic-product-items',
  templateUrl: './electronic-product-items.component.html',
  styleUrls: ['./electronic-product-items.component.scss']
})
export class ElectronicProductItemsComponent implements OnInit {
  @Input() electronicProducts : ProductResponse[];
  @Output() itemsSelectedEvent = new EventEmitter<ProductResponse>();
  
  constructor(private spaceService: SpaceService) { }

  ngOnInit(): void {
  }

  onItemClicked(product: ProductResponse){
    //var prod = this.electronicProducts.find( x=> x.productTypeId == productId && x.productTypeId == prodTypeId)
    //var prodDocumentUrl = 'htttp://localhost:/4200/assets/document/203010001.pdf';  //prod.documentUrl;
    this.itemsSelectedEvent.emit(product);
  }

}
