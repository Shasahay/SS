import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UploadRoutingModule } from './upload-routing.module';
import { UploadComponent } from './upload.component';
import { AddProductComponent } from './add-product/add-product.component';
import { SharedModule } from '../shared/shared.module';
import { MatFileUploadModule } from 'angular-material-fileupload';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [UploadComponent, AddProductComponent],
  imports: [
    CommonModule,
    MatFileUploadModule,
    UploadRoutingModule,
    MatInputModule,
    MatProgressBarModule,
    MatToolbarModule,
    FormsModule,
    MatFormFieldModule,

    SharedModule
  ]
})
export class UploadModule { }
