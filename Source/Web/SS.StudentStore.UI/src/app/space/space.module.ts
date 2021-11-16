import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import {SharedModule} from '../shared/shared.module'
import { SpaceRoutingModule } from './space-routing.module';
import { SpaceComponent } from './space.component';
import {MatSidenavModule} from '@angular/material/sidenav';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { ElectronicProductItemsComponent } from './electronic-product-items/electronic-product-items.component';
import { PdfViewerModule } from 'ng2-pdf-viewer';

@NgModule({
  declarations: [SpaceComponent, ElectronicProductItemsComponent],
  imports: [
    CommonModule,
    SharedModule,
    MatSidenavModule,
    PdfViewerModule,
    ScrollingModule,
    SpaceRoutingModule,
  ],
  schemas:[
    CUSTOM_ELEMENTS_SCHEMA
  ]
  
})
export class SpaceModule { }
