import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable} from 'rxjs/Rx';
import { environment } from 'src/environments/environment';
import { ERRORS_FROM_API } from 'src/app/shared/constants/error-constant';

@Injectable({
  providedIn: 'root'
})

export class HelperService {
    private apiUrl = environment.apiUrl;

    constructor(private http: HttpClient)   {  }

    getFromService(methodName: string, requestParams?: HttpParams){
        return this.http.get(this.apiUrl + methodName, {params: requestParams})
        .timeout(50000)
        .map(this.extractData, this)
        .catch(this.handleError)
    }

    getFromServiceRequestBody(methodName: string, requestBody: any){
        return this.http.get(this.apiUrl + methodName, (requestBody != null? requestBody : null))
        .timeout(50000)
        .catch(this.handleError)
    }

    postToService(methodName: String, requestBody: any, requestParams?: HttpParams){
        return this.http.post(this.apiUrl + methodName, (requestBody != null ? requestBody : null), {params:requestParams})
        .timeout(500000)
        .map(this.extractData, this)
        //.retry(1)
        .catch(this.handleError);
    }

    putToService(methodName: string, requestBody: any, requestParams: HttpParams){
       return this.http.put(this.apiUrl + methodName, (requestBody != null ? requestBody : null), {params:requestParams})
       .timeout(500000)
       .map(this.extractData, this)
        //.retry(1)
        .catch(this.handleError);
    }

    patchToService(methodName: string, requestBody: any, requestParams: HttpParams){
        return this.http.patch(this.apiUrl + methodName, (requestBody != null ? requestBody : null), {params:requestParams})
        .timeout(500000)
        .map(this.extractData, this)
         //.retry(1)
         .catch(this.handleError);
     }

     deleteFromService(methodName: string, requestParams?: HttpParams){
        return this.http.delete(this.apiUrl + methodName, {params: requestParams} )
        .timeout(50000)
        .catch(this.handleError)
     }

    extractData(res: Response, isCompresssed: any = false){
        let body: any;
        body = res;
        if(!(body === undefined || body === null)){
            // Error in message
            if(body.Error && body.Error !== null){
                return body.Error;
            }
            if(!(body === undefined || body === null)){
                return body;
            }else{
                // Return ERRORS_FROM_API.INVAID_RESPONSE
            }
        } else{
            // Invalid Response
            // Return ERRORS_FROM_API.INVAID_RESPONSE
        }
    }

    // Handle error : Api not working
    handleError(error: any){
        const errMsg = error.message || error.statusText || error || ERRORS_FROM_API.SERVER_ERROR;
        return Observable.throwError(errMsg);
    }
}