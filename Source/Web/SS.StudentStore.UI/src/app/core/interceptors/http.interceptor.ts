import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()

export class APIInterceptor implements HttpInterceptor{

    private addToken(req: HttpRequest<any>, token: string): HttpRequest<any>{
        if (req.url.indexOf('Account/address') > 0 || 
        req.url.indexOf('Account/currentuser') > 0 ||
        req.url.indexOf('Order') > 0
        )
        req.clone({setHeaders : { Authorization: 'Bearer ' + token}})
        return req;
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
       // throw new Error('Method not implemented.');
       var tokenizeUrl = this.addToken(req,this.getToken());
       return next.handle(tokenizeUrl);

    }

    private getToken(): string{
        return localStorage.getItem('token')
    }

}