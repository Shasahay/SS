import { Component, OnInit, ChangeDetectorRef, ViewChildren } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from 'src/app/basket/basket.service';
import { ProductResponse } from 'src/app/model/product/productresponse';
import { StoreService } from '../store.service'
import { IProducttypeMapping } from 'src/app/model/product/producttypemapping';
import { MatDialog } from '@angular/material/dialog';
import { ProductPreviewComponent } from '../product-preview/product-preview.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PdfViewerModule } from 'ng2-pdf-viewer';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
 
  product: ProductResponse;
  availProductTypes: IProducttypeMapping[];
  quantity = 1;
  productType: IProducttypeMapping;
  images: string[];
  image: string;
  selectedItem: string;
  constructor(private bcService: BreadcrumbService,
              private basketService: BasketService, private activatedRoute : ActivatedRoute , 
              private storeService: StoreService, private ref: ChangeDetectorRef, 
              public dialog: MatDialog,
              private modalService: NgbModal) {
    this.bcService.set('@productDetails', '');
   }

  ngOnInit(): void {
    this.loadProduct();
    this.getProductImage();
    this.image = this.images[0];
    this.availableProductType();
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      // this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      // this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  // addItemToCart() {
  //   this.basketService.addItemToBasket(this.product, this.productType, this.quantity);
  // }

  // incrementQuantity() {
  //   this.quantity++;
  // }

  // decrementQuantity() {
  //   if (this.quantity > 1) {
  //   this.quantity--;
  //   }
  // }
  loadProduct(){
    this.storeService.getProduct(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe( product =>{
      this.product = product;
      this.bcService.set('@productDetails', product.name);
    } )
  }

  availableProductType(){
    this.storeService.getProductMapping(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe((productType : IProducttypeMapping[])=>{
        this.availProductTypes = productType;
        this.productType = this.availProductTypes.find( x=> x.name ==='Paperback')
        this.ref.detectChanges();
    })
  };

  selectProductType(ProductTypeId : number){
    this.productType = this.availProductTypes.find( x=> x.productTypeId == ProductTypeId)
    this.ref.detectChanges();
  }
  browseImage(img: string): void{
    this.image = img;
  }

  getProductImage(){
    this.images = [];
    this.images.push('http://localhost:4200/assets/images/bslide2.jpg');
    this.images.push('http://localhost:4200/assets/images/hero1.jpg');
    this.images.push('http://localhost:4200/assets/images/hero2.jpg');
    this.images.push('http://localhost:4200/assets/images/hero3.jpg');
    this.images.push('http://localhost:4200/assets/images/hero4.jpg');
  }
  activateClass(event, img): void{
    this.selectedItem = img
  }
  
}
