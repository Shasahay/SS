import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StoreRoutingModule } from './store-routing.module';
import { ProductItemComponent } from './product-item/product-item.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { StoreComponent } from './store.component';
import { SharedModule } from '../shared/shared.module';
import { CategoryControlComponent } from './category-control/category-control.component';
import { SubcategoryControlComponent } from './subcategory-control/subcategory-control.component';
import { SectionControlComponent } from './section-control/section-control.component';
import { GradeControlComponent } from './grade-control/grade-control.component';
import { BrandControlComponent } from './brand-control/brand-control.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { ProductPreviewComponent } from './product-preview/product-preview.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDialogModule } from '@angular/material/dialog';
import { PdfViewerModule } from 'ng2-pdf-viewer';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    StoreComponent,
    ProductItemComponent,
    ProductDetailsComponent,
    CategoryControlComponent,
    SubcategoryControlComponent,
    SectionControlComponent,
    GradeControlComponent,
    BrandControlComponent,
    ProductPreviewComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatDialogModule,
    NgbModule,
    PdfViewerModule,
    StoreRoutingModule
  ]
})
export class StoreModule { }
