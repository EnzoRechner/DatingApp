import { HttpInterceptorFn } from '@angular/common/http';
import { catchError } from 'rxjs';
import { ToastService } from '../services/toast-service';
import { NavigationExtras, Router } from '@angular/router';
import { inject } from '@angular/core';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const toast = inject(ToastService);
  const router = inject(Router);

  return next(req).pipe(
    catchError(error => {
      if (error) {
        const errors = error.error.errors; 
        switch (error.status) {
          case 400:
          if (errors) {
            const modelStateErrors = [];
            for (const key in errors) {
              if (errors[key]) {
                modelStateErrors.push(errors[key])
              }
            }
            throw modelStateErrors.flat()
          } else {
            toast.error(error.error)
          }
          break;
          case 401:
            toast.error('Unatuhorized');
            break;
          case 404:
            toast.error('Hello')
            router.navigateByUrl('/not-found');
            break;
          case 500:
            const navigationExtras: NavigationExtras = { state: {error: error.error}}
            router.navigateByUrl('/server-error', navigationExtras);
            break;

          default:
            toast.error('Something went wrong')
            break;
        }
      }
      throw error;
    })
  );
};
