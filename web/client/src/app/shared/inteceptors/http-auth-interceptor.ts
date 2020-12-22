import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpHeaders,
  HttpResponse
} from '@angular/common/http';
import { UserService } from '../services/user.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { NotifyService } from '../services/notify.service';
@Injectable()
export class HttpAuthInterceptor implements HttpInterceptor {
  constructor(
    public userService: UserService,
    private notifyService: NotifyService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const token = this.userService.userAccount?.appKey;

    if (this.userService.isLoggedIn()) {
      request = request.clone({ headers: request.headers.set('Authorization', 'Bearer ' + token) });
    }

    request = request.clone({ headers: request.headers.set('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE, PATCH, OPTIONS') });
    request = request.clone({ headers: request.headers.set('Content-Type', 'application/json') });
    request = request.clone({ headers: request.headers.set('Accept', 'application/json') });


    return next.handle(request).pipe(
      map((event: HttpEvent<any>) => {
          if (event instanceof HttpResponse) {
            console.log('event--->>>', event);
            if (event.status) {
              if (event.status === 419){
                // toast to relogin
                this.notifyService.show('Your session has expired. Log in again.', {classname: 'alert-info'});
              } else if (event.status === 500){
                // toast server error
                this.notifyService.show('A server error occurred. Please try again.',
                 { classname: 'alert-danger text-light', delay: 5000 });
              }
            }
          }
          return event;
      }));
  }
}
