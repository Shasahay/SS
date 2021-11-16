import { NgModule} from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TextInputComponent } from './components/text-input/text-input.component';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { StepperComponent } from './components/stepper/stepper.component';
import { BasketSummaryComponent } from './components/basket-summary/basket-summary.component';
import { RouterModule } from '@angular/router';
import {MatCardModule} from '@angular/material/card'
import { CardDisplayComponent } from './components/card-display/card-display.component';
import { ProductTypeIdentifierPipe } from './pipe/product-type-identifier.pipe';
// import { MatSidenavModule } from '@angular/material/sidenav';
// import { MatCheckboxModule } from '@angular/material/checkbox';
import { EproductsPipe } from './pipe/eproducts.pipe';
import { SubscribeproductsPipe } from './pipe/subscribeproducts.pipe';
import { TileComponent } from './tile/tile.component';
import { MultiSelectDropdownComponent } from './components/multi-select-dropdown/multi-select-dropdown.component';
import { FileUploadComponent } from './components/file-upload/file-upload.component';
import { NgxFileDropModule } from 'ngx-file-drop';

@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    OrderTotalsComponent,
    TextInputComponent,
    StepperComponent,
    BasketSummaryComponent,
    CardDisplayComponent,
    ProductTypeIdentifierPipe,
    EproductsPipe,
    SubscribeproductsPipe,
    TileComponent,
    MultiSelectDropdownComponent,
    FileUploadComponent
  ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
    CdkStepperModule,
    MatCardModule,
    NgxFileDropModule,
    RouterModule
  ],
  exports: [
    PaginationModule,
    PagingHeaderComponent,
    PagerComponent,
    CarouselModule,
    OrderTotalsComponent,
    ReactiveFormsModule,
    BsDropdownModule,
    TextInputComponent,
    CdkStepperModule,
    StepperComponent,
    BasketSummaryComponent,
    CardDisplayComponent,
    EproductsPipe,
    SubscribeproductsPipe,
    TileComponent,
    MultiSelectDropdownComponent,
    FileUploadComponent
  ]
})
export class SharedModule { }
