import { Component, OnInit } from '@angular/core';
import { ProductFilter } from 'src/app/model/product/productfilter';
import { Section } from 'src/app/model/product/section';
import { ProductAPIService } from 'src/app/services/module/product/product.api.service';

@Component({
  selector: 'app-section-control',
  templateUrl: './section-control.component.html',
  styleUrls: ['./section-control.component.scss']
})
export class SectionControlComponent implements OnInit {
  sections: Section[] = [];
  filter: ProductFilter;
  constructor(private productService: ProductAPIService) { }

  ngOnInit(): void {
    this.loadSection();
    
  }

  loadSection(){
    this.productService.getSection().subscribe(res =>{
      this.sections = res;
      console.log(this.sections)
     }  )
  }

  onSectionSelected(categoryId: number) {
    console.log(categoryId);
    // const params = this.shopService.getShopParams();
    // params.brandId = brandId;
    // params.pageNumber = 1;
    // this.shopService.setShopParams(params);
    // this.getProducts();
   }
}
