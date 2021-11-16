import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable} from 'rxjs/Rx';
import { Basket, IBasket } from 'src/app/model/store/basket';
import { environment } from 'src/environments/environment';
import { HelperService } from '../../helper/helper.service';

@Injectable({
    providedIn: 'root'
  })

  export class BasketAPIService{

    public dataUrl = environment.apiUrl;
    public controller = 'Basket';
    constructor(private helperService : HelperService)   {  }

    getBasket(basketUId: string): Observable<Basket>{
        return this.helperService.postToService(this.controller + '/GetBasket/'+basketUId, null)
        .map((response) => response as Basket).catch(this.handleError)
    }

    AddBasket(basket: Basket): Observable<boolean>{
        return this.helperService.postToService(this.controller + '/AddBasket', basket)
        .map((response) => response as boolean).catch(this.handleError)
    }

    AddOrUpdateBasket(basket: Basket): Observable<IBasket>{
      return this.helperService.postToService(this.controller + '/AddOrUpdateBasket', basket)
      .map((response) => response as Basket).catch(this.handleError)
  }

  deleteBasket(basketUId: string): Observable<boolean>{
    return this.helperService.deleteFromService(this.controller + '/delete/'+basketUId, null)
    .map((response) => response as boolean).catch(this.helperService.handleError)
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