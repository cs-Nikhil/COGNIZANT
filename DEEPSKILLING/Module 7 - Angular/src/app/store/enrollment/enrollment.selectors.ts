import { createFeatureSelector, createSelector } from '@ngrx/store';
import { Enrollment } from '../../models/enrollment.model';
import { enrollmentFeatureKey, EnrollmentState } from './enrollment.state';

export const selectEnrollmentFeature = createFeatureSelector<EnrollmentState>(enrollmentFeatureKey);

export const selectAllEnrollments = createSelector(
  selectEnrollmentFeature,
  (state) => state.enrollments
);

export const selectEnrollmentLoading = createSelector(
  selectEnrollmentFeature,
  (state) => state.loading
);

export const selectEnrollmentError = createSelector(
  selectEnrollmentFeature,
  (state) => state.error
);

export const selectEnrollmentCount = createSelector(
  selectAllEnrollments,
  (enrollments) => enrollments.length
);

export const selectSelectedEnrollmentId = createSelector(
  selectEnrollmentFeature,
  (state) => state.selectedEnrollmentId
);

export const selectSelectedEnrollment = createSelector(
  selectAllEnrollments,
  selectSelectedEnrollmentId,
  (enrollments, selectedId): Enrollment | undefined =>
    enrollments.find((enrollment) => enrollment.id === selectedId)
);

