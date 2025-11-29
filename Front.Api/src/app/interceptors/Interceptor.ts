import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, map, catchError, throwError, finalize } from 'rxjs';
import Swal from 'sweetalert2';
import { Constants } from '../shared/constants';
import { Router } from '@angular/router';

// Interfaz para tu modelo de respuesta base
interface BaseResponseModel<T> {
  statusCode: number;
  message: string;
  data: T;
}

@Injectable()
export class Interceptor implements HttpInterceptor {
  constructor(private router: Router) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const headers: { [header: string]: string } = {};

    // TODO: Descomentar cuando implementes autenticación
    //
    const token = localStorage.getItem(Constants.Session.TOKEN)?.trim();
    const user = localStorage.getItem(Constants.Session.EMAIL)?.trim();

    if (token && token !== '') {
      headers['Authorization'] = `Bearer ${token}`;
    }
    if (user && user !== '') {
      headers['UserAudit'] = `${user}`;
    }
    //

    const clonedReq = req.clone({
      setHeaders: headers,
    });

    // this.loadingService.setLoading(true);

    return next.handle(clonedReq).pipe(
      map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
          if (event.body) {
            const modifiedBody: BaseResponseModel<any> = event.body.data;
            return event.clone({ body: modifiedBody });
          }
        }
        return event;
      }),

      catchError((error: HttpErrorResponse) => {
        if (error.status === 400) {
          Swal.fire({
            title: Constants.Title.VALIDATE,
            text: error.error.message,
            icon: 'warning',
            confirmButtonText: Constants.Buttons.CONFIRM_BUTTON,
          });
        } else if (error.status === 404) {
          Swal.fire({
            title: Constants.Title.VALIDATE,
            text: error.error.message,
            icon: 'info',
            confirmButtonText: Constants.Buttons.CONFIRM_BUTTON,
          });
        } else if (error.status === 401) {
          Swal.fire({
            title: Constants.Title.UNAUTHORIZED,
            text: Constants.Messages.SESSION_EXPIRED,
            icon: 'warning',
            confirmButtonText: Constants.Buttons.CONFIRM_BUTTON,
          }).then(() => {
            try {
              localStorage.removeItem(Constants.Session.TOKEN);
              localStorage.removeItem(Constants.Session.EMAIL);
              localStorage.removeItem('password');
            } catch (e) {}

            this.router.navigate(['/user']);
          });
        } else if (error.status === 403) {
          Swal.fire({
            title: Constants.Title.ACCESS_DENIED,
            text: Constants.Messages.ACCESS_DENIED,
            icon: 'error',
            confirmButtonText: Constants.Buttons.CONFIRM_BUTTON,
          });
        } else if (error.status === 500) {
          Swal.fire({
            title: Constants.Title.SERVER_ERROR,
            text: error.error.message,
            icon: 'error',
            confirmButtonText: Constants.Buttons.CONFIRM_BUTTON,
          });
        } else {
          Swal.fire({
            title: Constants.Title.ERROR,
            text: error.error.message,
            icon: 'error',
            confirmButtonText: Constants.Buttons.CONFIRM_BUTTON,
          });
        }

        return throwError(() => error.message);
      }),

      finalize(() => {
        // this.loadingService.setLoading(false);
      })
    );
  }
}
