import { Component, OnInit } from '@angular/core';
import { Grade } from 'src/app/model/product/grade';
import { ProductFilter } from 'src/app/model/product/productfilter';
import { ProductAPIService } from 'src/app/services/module/product/product.api.service';

@Component({
  selector: 'app-grade-control',
  templateUrl: './grade-control.component.html',
  styleUrls: ['./grade-control.component.scss']
})
export class GradeControlComponent implements OnInit {

  grades: Grade[] = [];
  filter: ProductFilter;
  constructor(private productService: ProductAPIService) { }

  ngOnInit(): void {
    this.loadGrade();
    
  }

  loadGrade(){
    this.productService.getGrade().subscribe(res =>{
      this.grades = res;
      console.log(this.grades)
     }  )
  }

  onGradeSelected(gradeId: number) {
    console.log(gradeId);
    // const params = this.shopService.getShopParams();
    // params.brandId = brandId;
    // params.pageNumber = 1;
    // this.shopService.setShopParams(params);
    // this.getProducts();
   }


}
