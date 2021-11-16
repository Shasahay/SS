import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Observable} from 'rxjs/Rx';
import { IUser } from 'src/app/model/Identity/user';
import { IAddress } from 'src/app/model/Identity/address';
import { environment } from 'src/environments/environment';
import { HelperService } from '../../helper/helper.service';

@Injectable({
    providedIn: 'root'
  })

  export class AccountAPIService{
    public dataUrl = environment.apiUrl;
    public controller = 'Account';
    constructor( private http: HttpClient, private helperService : HelperService)   {  }

    isEmailExist(email: string):Observable<boolean>{
        return this.helperService.getFromService(this.controller+ '/IsEmailExist/'+ email)
        .map((response) => response as boolean).catch(this.handleError)
    }

    getCurrentUser():Observable<IUser>{
      return this.helperService.getFromService(this.controller+ '/currentuser')
      .map((response) => response as IUser).catch(this.handleError)
  }

    createOrUpdateUser( user: IUser): Observable<IUser>{  
        return this.helperService.postToService(this.controller +'/AddUser', user)
        .map((response) => response as IUser).catch(this.handleError)
    }

    getUserByEmail(email: string): Observable<IUser>{
        return this.helperService.postToService(this.controller+'/GetUserByEmail/' +email, null)
        .map((response) => response as IUser).catch(this.handleError)
    }

    login(values: any): Observable<IUser>{
        return this.helperService.postToService(this.controller + '/login', values)
        .map((response) => response as IUser).catch(this.handleError)
    }

    createOrUpdatAddress(address: IAddress): Observable<IAddress>{  
      return this.helperService.postToService(this.controller +'/addorupdate-address', address)
      .map((response) => response as IAddress).catch(this.handleError)
  }

    getUserAddress():Observable<IAddress>{
      return this.helperService.getFromService(this.controller + '/address')
      .map((response) => response as IAddress).catch(this.handleError) 
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