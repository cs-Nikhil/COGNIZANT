import { inject, Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, of, switchMap } from 'rxjs';
import { EnrollmentService } from '../../services/enrollment.service';
import {
  createEnrollment,
  createEnrollmentFailure,
  createEnrollmentSuccess,
  deleteEnrollment,
  deleteEnrollmentFailure,
  deleteEnrollmentSuccess,
  loadEnrollments,
  loadEnrollmentsFailure,
  loadEnrollmentsSuccess
} from './enrollment.actions';

@Injectable()
export class EnrollmentEffects {
  private readonly actions$ = inject(Actions);
  private readonly enrollmentService = inject(EnrollmentService);

  readonly loadEnrollments$ = createEffect(() =>
    this.actions$.pipe(
      ofType(loadEnrollments),
      switchMap(() =>
        this.enrollmentService.loadEnrollments().pipe(
          map((enrollments) => loadEnrollmentsSuccess({ enrollments })),
          catchError((error: Error) =>
            of(loadEnrollmentsFailure({ error: error.message || 'Failed to load enrollments.' }))
          )
        )
      )
    )
  );

  readonly createEnrollment$ = createEffect(() =>
    this.actions$.pipe(
      ofType(createEnrollment),
      switchMap(({ enrollment }) =>
        this.enrollmentService.createEnrollment(enrollment).pipe(
          map((created) => createEnrollmentSuccess({ enrollment: created })),
          catchError((error: Error) =>
            of(createEnrollmentFailure({ error: error.message || 'Failed to create enrollment.' }))
          )
        )
      )
    )
  );

  readonly deleteEnrollment$ = createEffect(() =>
    this.actions$.pipe(
      ofType(deleteEnrollment),
      switchMap(({ enrollmentId }) =>
        this.enrollmentService.deleteEnrollment(enrollmentId).pipe(
          map(() => deleteEnrollmentSuccess({ enrollmentId })),
          catchError((error: Error) =>
            of(deleteEnrollmentFailure({ error: error.message || 'Failed to delete enrollment.' }))
          )
        )
      )
    )
  );
}

