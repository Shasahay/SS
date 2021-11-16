import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Brand } from 'src/app/model/product/brand';
import { Category } from 'src/app/model/product/category';
import { Grade } from 'src/app/model/product/grade';
import { ProductType } from 'src/app/model/product/producttype';
import { Section } from 'src/app/model/product/section';
import { StageProduct } from 'src/app/model/product/stageproduct';
import { SubCategory } from 'src/app/model/product/subcategory';
import { Application_Constants } from 'src/app/shared/constants/application-constant';
import { UploadService } from '../upload.service';


@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent implements OnInit {
  isSubmitted = false;
  isOnlineProduct: boolean = false;
  addProductForm: FormGroup;
  categories: Category[];
  subcategories: SubCategory[];
  grade: Grade[];
  brand: Brand[];
  section: Section[];
  productType: ProductType[];
  selectedPT: ProductType[];
  list : any[];
  dataimage:any;
  newProduct: StageProduct;
  acceptedUploadFileType: string = 'jpg,png,jpeg'
  coverPicUploadCaption: string = 'Upload Small Picture (Display as Cover)'
  fullSizePicUploadCaption: string = 'Upload Full page Picture (full size image)'
  docUploadUrlCaption: string = 'Upload pdf version of your item'
  maxCoverImage: number = 4;
  maxFullSizeImage: number = 1;
  maxDocumentUpload: number = 1;
  acceptedDocUploadFileType: string = 'pdf'
  @ViewChild('fileInput') fileInput: ElementRef;
  fileAttr = 'Choose File';
  constructor(private fb: FormBuilder, private uploadService: UploadService) { 
    this.categories = [];
    this.subcategories = [];
    this.grade = [];
    this.brand = [];
    this.section = [];
    this.productType = [];
    //this.list = [];
    this.newProduct = new StageProduct();
  }

  ngOnInit(): void {
     this.createAddProductForm();
     this.dafaultData();
  }
 
    createAddProductForm(){
      this.addProductForm = this.fb.group({
        title:[null, Validators.required],
        name:[null, Validators.required],
        description:[null],
        price:[null, Validators.required],
        categoryId: [''],
        subCategoryId: [''],
        gradeId: [''],
        sectionId: [''],
        brandId: [''],
        productTypeId: ['', [Validators.required]]
        //coverPics: ['', [Validators.required]]  // not Mandatory
      })
  };

  get f(){
  return this.addProductForm.controls;
  }
 // Choose city using select dropdown
  changeHandler(e) {
    
    switch(e.target.getAttribute('formControlName')){
        case 'categoryId':{
          this.addProductForm.get('categoryId').setValue(e.target.value, {
            onlySelf: true
        })
        this.newProduct.categoryId = parseInt(e.target.value)
        break;
        }
        case 'subCategoryId':{
          this.addProductForm.get('subCategoryId').setValue(e.target.value, {
            onlySelf: true
        })
        this.newProduct.subCategoryId = parseInt(e.target.value)
        break;
        }
        case 'gradeId':{
          this.addProductForm.get('gradeId').setValue(e.target.value, {
            onlySelf: true
        })
        this.newProduct.gradeId = parseInt(e.target.value)
        break;
        }
        case 'sectionId':{
          this.addProductForm.get('sectionId').setValue(e.target.value, {
            onlySelf: true
        })
        this.newProduct.sectionId = parseInt(e.target.value)
        break;
        }
        case 'brandId':{
          this.addProductForm.get('brandId').setValue(e.target.value, {
            onlySelf: true
        })
        this.newProduct.brandId = parseInt(e.target.value)
        break;
        }
        // case 'productTypeId':{
        //   this.addProductForm.get('productTypeId').setValue(e.target.value, {
        //     onlySelf: true
        // })
        // break;
        // }
        default: break;
    }
  }

  dafaultData(){
    this.loadcategory();
    this.loadSubcategory();
    this.loadSection();
    this.loadGrade();
    this.loadBrand();
    this.loadProductType();
  }

  onSubmit() {
    this.isSubmitted = true;
    if (!this.addProductForm.valid) {
      return false;
    } else {
      this.newProduct.title = this.addProductForm.value.title;
      this.newProduct.name = this.addProductForm.value.name;
      this.newProduct.description = this.addProductForm.value.description;
      this.newProduct.price = this.addProductForm.value.price;
      alert(JSON.stringify(this.addProductForm.value))
    }
  }
  loadcategory(){
    this.uploadService.getCategories().subscribe(res =>{
      this.categories = res;
     })
  }
  loadSection(){
    this.uploadService.getSection().subscribe(res =>{
      this.section = res;
     })
  }
  loadSubcategory(){
    this.uploadService.getSubCategories().subscribe(res =>{
      this.subcategories = res;
     })
  }
  loadGrade(){
    this.uploadService.getGrade().subscribe(res =>{
      this.grade = res;
     })
  }
  loadBrand(){
    this.uploadService.getBrand().subscribe(res =>{
      this.brand = res;
     })
  }
  loadProductType(){
    this.productType = this.uploadService.getProductType();
  }
  shareCheckedList(item:any[]){
    this.selectedPT = [];
    if(item != null || item.length > 0){
      this.addProductForm.patchValue({ 
        productTypeId: item[0].productTypeId
      })
      this.selectedPT = item;
      this.isOnlinePorduct(this.selectedPT);
    }
    
    
  }
  shareIndividualCheckedList(item:{}){
    console.log(item);
  }

  uploadFileEvt(imgFile: any) {
    if (imgFile.target.files && imgFile.target.files[0]) {
      this.fileAttr = '';
      Array.from(imgFile.target.files).forEach((file: File) => {
        this.fileAttr += file.name + ' - ';
      });

      // HTML5 FileReader API
      let reader = new FileReader();
      reader.onload = (e: any) => {
        let image = new Image();
        image.src = e.target.result;
        image.onload = rs => {
          let imgBase64Path = e.target.result;
          console.log(imgBase64Path);
          this.dataimage = imgBase64Path;
        };
      };
      reader.readAsDataURL(imgFile.target.files[0]);
      
      // Reset if duplicate image uploaded again
      this.fileInput.nativeElement.value = "";
    } else {
      this.fileAttr = 'Choose File';
    }
  }

  isOnlinePorduct(pt: ProductType[]){
    this.isOnlineProduct = false;
    // check is Ebook Product or Subscribe 
    if(pt.find(x=> x.productTypeId == ( Application_Constants.ebookProductTypeId || Application_Constants.subscribeProductTypeId))){
    this.isOnlineProduct =  true;
    }
  }

  createProduct(){

  }
  coverPictureUploadEventHandler(event: File[]){
    console.log('coverPictureUploadEventHandler : ' +event)
  }
  fullPictureUploadEventHandler(event: File[]){
    console.log('FullPictureUploadEventHandler : ' +event)
  }
  documentUploadEventHandler(event: File[]){
    console.log('documentUploadEventHandler : ' +event)
  }
}
