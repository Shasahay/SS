import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
// import { IBasketItem } from '../../models/basket';
// import { IOrderItem } from '../../models/order';
import { IBasketItem } from 'src/app/model/store/basket';
import { IOrderItem } from 'src/app/model/order/order';

@Component({
  selector: 'app-basket-summary',
  templateUrl: './basket-summary.component.html',
  styleUrls: ['./basket-summary.component.scss']
})
export class BasketSummaryComponent implements OnInit {
  @Output() decrement: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Output() increment: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Output() remove: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Input() isBasket = true;
  @Input() items: IBasketItem[] | IOrderItem[] = [];
  @Input() isOrder = false;

  constructor() { }

 ngOnInit(){
   
 }

  decrementItem(item: IBasketItem) {
    this.decrement.emit(item);
  }

  incrementItem(item: IBasketItem) {
    this.increment.emit(item);
  }

  removeBasketItem(item: IBasketItem) {
    this.remove.emit(item);
  }
// this is the constant method, 
// Assuming 1 = paperbook; 2 = Ebook and 3 = subscribe same as data insered in table
    
}
