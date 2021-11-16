import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { StoreComponent } from './store.component';

const routes: Routes = [
  { path: '', component: StoreComponent },
  { path: ':id', component: ProductDetailsComponent, data: {breadcrumb: {alias: 'productDetails'}} },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StoreRoutingModule { }
