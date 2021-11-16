import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable} from 'rxjs/Rx';
import { IDeliveryMethod } from 'src/app/model/order/deliveryMethod';
import { IBasket } from 'src/app/model/store/basket';
import { environment } from 'src/environments/environment';
import { HelperService } from '../../helper/helper.service';

@Injectable({
    providedIn: 'root'
  })

  export class PaymentAPIService{
    public dataUrl = environment.apiUrl;
    public controller = 'Payment';
    constructor(private helperService : HelperService)   {  }

    addOrUpdatePaymentIntent(basketUId: string): Observable<IBasket>{
        return this.helperService.postToService(this.controller + '/'+basketUId, null)
        .map((response) => response as IBasket).catch(this.helperService.handleError)
    };
  }