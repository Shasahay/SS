import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductResponse } from 'src/app/model/product/productresponse';
import { environment } from 'src/environments/environment';
import { HelperService } from '../../helper/helper.service';
import {Observable} from 'rxjs/Rx';
import { ProductFilter } from 'src/app/model/product/productfilter';
import { Brand } from 'src/app/model/product/brand';
import { Category } from 'src/app/model/product/category';
import { Section } from 'src/app/model/product/section';
import { Grade } from 'src/app/model/product/grade';
import { SubCategory } from 'src/app/model/product/subcategory';
import { DefaultListResponse } from 'src/app/model/defaultlistresponse';
import { IProducttypeMapping } from 'src/app/model/product/producttypemapping';

@Injectable({
  providedIn: 'root'
})
export class ProductAPIService {

  public dataUrl = environment.apiUrl;
  public controller = 'Product';
  
  constructor( private http: HttpClient, private helperService : HelperService) { }

  getAllProduct(): Observable<ProductResponse[]>{
    return this.helperService.getFromService(this.controller + '/GetAllProduct')
    .map((response) => response as ProductResponse[]).catch(this.handleError)
  }
  getProduct(filter: ProductFilter): Observable<DefaultListResponse>{
    return this.helperService.postToService(this.controller+'/GetProduct', filter)
    .map((response) => response as DefaultListResponse).catch(this.handleError)
  }

  getProductBYId(productId: number): Observable<ProductResponse>{
    return this.helperService.getFromService(this.controller+`/getproductId/${productId}`, null)
    .map((response) => response as ProductResponse).catch(this.handleError)
  }

  getProductMappingById(productId: number): Observable<IProducttypeMapping[]>{
    return this.helperService.getFromService(this.controller+`/productmapping/${productId}`, null)
    .map((response) => response as IProducttypeMapping[]).catch(this.handleError)
  }

  getUserOrderedOnlineProductType():Observable<ProductResponse[]>{
    return this.helperService.getFromService(this.controller + '/getuseronlineproducts')
    .map((response) => response as ProductResponse[]).catch(this.handleError)
  }
  getCategory(): Observable<Category[]>{
    return this.helperService.getFromService(this.controller+'/GetCategories')
    .map((response) => response as Category[]).catch(this.handleError)
  }
  getSubCategory(): Observable<SubCategory[]>{
    return this.helperService.getFromService(this.controller+'/GetSubCategories')
    .map((response) => response as SubCategory[]).catch(this.handleError)
  }
  getSection(): Observable<Section[]>{
    return this.helperService.getFromService(this.controller+'/GetSections')
    .map((response) => response as Section[]).catch(this.handleError)
  }
  getGrade(): Observable<Grade[]>{
    return this.helperService.getFromService(this.controller+'/GetGrades')
    .map((response) => response as Grade[]).catch(this.handleError)
  }
  getBrands(): Observable<Brand[]>{
    return this.helperService.getFromService(this.controller+'/GetBrands')
    .map((response) => response as Brand[]).catch(this.handleError)
  } 

  
  private handleError(apiError:any){
    if(apiError._body != null){
      if(typeof apiError._body === 'string'){
        if(apiError._body.indeOf('Session expired') >= 0){
          window.location.href = location.origin + location.pathname + '#/SessionExpired';
        }
        else if(apiError._body.indeOf('Forbidden Access') >= 0){
          window.location.href = location.origin + location.pathname + '#/ForbiddenAccess';
        }
      }
    }
    return Observable.throwError(apiError);
  }
}
