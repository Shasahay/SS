import { Component, OnInit } from '@angular/core';
import { Brand } from 'src/app/model/product/brand';
import { ProductFilter } from 'src/app/model/product/productfilter';
import { ProductAPIService } from 'src/app/services/module/product/product.api.service';

@Component({
  selector: 'app-brand-control',
  templateUrl: './brand-control.component.html',
  styleUrls: ['./brand-control.component.scss']
})
export class BrandControlComponent implements OnInit {
  brands: Brand[] = [];
  
  constructor(private productService: ProductAPIService) { }

  ngOnInit(): void {
    this.loadBrand();
    
  }

  loadBrand(){
    this.productService.getBrands().subscribe(res =>{
      this.brands = res;
      console.log(this.brands)
     }  )
  }

  onBrandSelected(categoryId: number) {
    console.log(categoryId);
    // const params = this.shopService.getShopParams();
    // params.brandId = brandId;
    // params.pageNumber = 1;
    // this.shopService.setShopParams(params);
    // this.getProducts();
   }

}
