import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, ReplaySubject, of, Observable } from 'rxjs';
import { IUser } from '../model/Identity/user';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { IAddress } from '../model/Identity/address';
import { AccountAPIService } from '../services/module/identity/account.api.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  // We need to have something which won't emit initial value rather wait till it has something.
  // Hence for that ReplaySubject. I have given to hold one user object and it will cache this as well
  private currentUserSource = new ReplaySubject<IUser>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private accountService: AccountAPIService, private router: Router) { }



  loadCurrentUser(token: string) {
    if (token === null) {
      this.currentUserSource.next(null);
      return of(null);
    }
    // let headers = new HttpHeaders();
    // headers = headers.set('Authorization', `bearer ${token}`);

    return this.accountService.getCurrentUser().pipe(
      map((user: IUser) => {
        if(user){
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      })
    )

    // return this.http.get(this.baseUrl + 'account', {headers}).pipe(
    //   map((user: IUser) => {
    //     if (user) {
    //       localStorage.setItem('token', user.token);
    //       this.currentUserSource.next(user);
    //     }
    //   })
    // );
  }

  login(values: any) {
    return this.accountService.login(values).pipe(
      map((user: IUser) => {
        if(user){
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      })
    )
    // return this.http.post(this.baseUrl + 'account/login', values).pipe(
    //   map((user: IUser) => {
    //     if (user) {
    //       localStorage.setItem('token', user.token);
    //       this.currentUserSource.next(user);
    //     }
    //   })
    // );
  }

  register(values: any) {
    debugger
   return this.accountService.createOrUpdateUser(values).pipe(
      map((user: IUser) => {
        if(user){
          localStorage.setItem('token', user.token);
           this.currentUserSource.next(user);
        }
      })
    )

    // return this.http.post(this.baseUrl + 'account/register', values).pipe(
    //   map((user: IUser) => {
    //     if (user) {
    //       localStorage.setItem('token', user.token);
    //       this.currentUserSource.next(user);
    //     }
    //   })
    // );
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

  checkEmailExists(email: string): Observable<boolean> {
    return this.accountService.isEmailExist(email);
  }

  getUserAddress(): Observable<IAddress>{
    return this.accountService.getUserAddress()
    //return this.http.get<IAddress>(this.baseUrl + 'account/address');
  }

  updateUserAddress(address: IAddress) {
    return this.accountService.createOrUpdatAddress(address)
  }
}
