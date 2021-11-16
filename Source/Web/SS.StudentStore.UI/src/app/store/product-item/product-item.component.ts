import { Component, OnInit, Input } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { BasketService } from 'src/app/basket/basket.service';
import { ProductResponse } from 'src/app/model/product/productresponse';
import { IProducttypeMapping, ProductTypeMapping } from 'src/app/model/product/producttypemapping';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent implements OnInit {
@Input() product: ProductResponse;
defaultProductType: IProducttypeMapping;
  constructor(private basketService: BasketService) { }

  ngOnInit(): void {
    this.setDefaultProductType();
  }
  getProductType(productId: number)
  {
    
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.product, this.defaultProductType);
  }

  setDefaultProductType(){
    this.defaultProductType = new ProductTypeMapping() // Default is paper back and prodctType id = 1
    this.defaultProductType.productTypeId = 1
  }

}
