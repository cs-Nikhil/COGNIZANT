import { createAction, props } from '@ngrx/store';
import { Enrollment, EnrollmentDraft } from '../../models/enrollment.model';

export const loadEnrollments = createAction('[Enrollment Page] Load Enrollments');
export const loadEnrollmentsSuccess = createAction(
  '[Enrollment API] Load Enrollments Success',
  props<{ enrollments: Enrollment[] }>()
);
export const loadEnrollmentsFailure = createAction(
  '[Enrollment API] Load Enrollments Failure',
  props<{ error: string }>()
);

export const createEnrollment = createAction(
  '[Enrollment Form] Create Enrollment',
  props<{ enrollment: EnrollmentDraft }>()
);
export const createEnrollmentSuccess = createAction(
  '[Enrollment API] Create Enrollment Success',
  props<{ enrollment: Enrollment }>()
);
export const createEnrollmentFailure = createAction(
  '[Enrollment API] Create Enrollment Failure',
  props<{ error: string }>()
);

export const deleteEnrollment = createAction(
  '[Enrollment List] Delete Enrollment',
  props<{ enrollmentId: number }>()
);
export const deleteEnrollmentSuccess = createAction(
  '[Enrollment API] Delete Enrollment Success',
  props<{ enrollmentId: number }>()
);
export const deleteEnrollmentFailure = createAction(
  '[Enrollment API] Delete Enrollment Failure',
  props<{ error: string }>()
);

export const selectEnrollment = createAction(
  '[Enrollment Page] Select Enrollment',
  props<{ enrollmentId: number | null }>()
);

