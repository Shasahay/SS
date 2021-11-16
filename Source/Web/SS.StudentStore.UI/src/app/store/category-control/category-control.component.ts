import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Category } from 'src/app/model/product/category';
import { ProductFilter } from 'src/app/model/product/productfilter';
import { StoreService } from '../store.service';


@Component({
  selector: 'app-category-control',
  templateUrl: './category-control.component.html',
  styleUrls: ['./category-control.component.scss']
})
export class CategoryControlComponent implements OnInit {
@Output() onCategorySelectedEvent = new EventEmitter<number>();
  categories: Category[] = [];
  filter: ProductFilter;
  constructor(private storeService: StoreService) { 
    this.filter = this.storeService.getStoreParams();
  }

  ngOnInit(): void {
    this.loadCaterogy();
    
  }

  loadCaterogy(){
    this.storeService.getCategory().subscribe(res =>{
      this.categories = res;
     })
  }

  onCategorySelected(categoryId: number) {
    this.onCategorySelectedEvent.emit(categoryId);
   }

}
