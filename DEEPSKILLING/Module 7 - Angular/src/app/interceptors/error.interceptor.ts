import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { NotificationService } from '../services/notification.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const notifications = inject(NotificationService);

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      const detail =
        error.error?.message ?? error.message ?? 'Something went wrong while talking to the API.';
      notifications.error('Network error', detail);
      return throwError(() => error);
    })
  );
};

