import { Component, Input, OnChanges, SimpleChange } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { ProductResponse } from 'src/app/model/product/productresponse';
import { IProducttypeMapping } from 'src/app/model/product/producttypemapping';
@Component({
  selector: 'app-card-display',
  templateUrl: './card-display.component.html',
  styleUrls: ['./card-display.component.scss']
})
export class CardDisplayComponent implements OnChanges {
 @Input() productType: IProducttypeMapping;
 @Input() product: ProductResponse;
 quantity = 1;
  constructor(private basketService: BasketService) { }

  ngOnChanges(changes: any): void {
    
  }
  addItemToCart() {
    // this.basketService.addItemToBasket(this.product, this.quantity);
    this.basketService.addItemToBasket(this.product, this.productType, this.quantity);
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    if (this.quantity > 1) {
    this.quantity--;
    }
  }

}
