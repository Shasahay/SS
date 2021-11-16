import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ProductFilter } from 'src/app/model/product/productfilter';
import { SubCategory } from 'src/app/model/product/subcategory';
import { StoreService } from '../store.service';

@Component({
  selector: 'app-subcategory-control',
  templateUrl: './subcategory-control.component.html',
  styleUrls: ['./subcategory-control.component.scss']
})
export class SubcategoryControlComponent implements OnInit {
  @Output() onSubCategorySelectedEvent = new EventEmitter<number>();
  subCategories: SubCategory[] = [];
  filter: ProductFilter;
  constructor(private storeService: StoreService) { 
    this.filter = this.storeService.getStoreParams();
  }

  ngOnInit(): void {
    this.loadSubCategory();
    
  }

  loadSubCategory(){
    this.storeService.getSubCategory().subscribe(res =>{
      this.subCategories = res;
     }  )
  }

  onSubCategorySelected(subCategoryId: number) {
    debugger
    this.onSubCategorySelectedEvent.emit(subCategoryId);
   }
}
