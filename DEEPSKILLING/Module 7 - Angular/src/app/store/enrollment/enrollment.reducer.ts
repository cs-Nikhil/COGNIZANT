import { createReducer, on } from '@ngrx/store';
import {
  createEnrollment,
  createEnrollmentFailure,
  createEnrollmentSuccess,
  deleteEnrollment,
  deleteEnrollmentFailure,
  deleteEnrollmentSuccess,
  loadEnrollments,
  loadEnrollmentsFailure,
  loadEnrollmentsSuccess,
  selectEnrollment
} from './enrollment.actions';
import { EnrollmentState, initialEnrollmentState } from './enrollment.state';

export const enrollmentReducer = createReducer(
  initialEnrollmentState,
  on(loadEnrollments, (state) => ({
    ...state,
    loading: true,
    error: null
  })),
  on(loadEnrollmentsSuccess, (state, { enrollments }) => ({
    ...state,
    enrollments,
    loading: false
  })),
  on(loadEnrollmentsFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error
  })),
  on(createEnrollment, (state) => ({
    ...state,
    loading: true,
    error: null
  })),
  on(createEnrollmentSuccess, (state, { enrollment }) => ({
    ...state,
    loading: false,
    enrollments: [enrollment, ...state.enrollments]
  })),
  on(createEnrollmentFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error
  })),
  on(deleteEnrollment, (state) => ({
    ...state,
    loading: true,
    error: null
  })),
  on(deleteEnrollmentSuccess, (state, { enrollmentId }) => ({
    ...state,
    loading: false,
    enrollments: state.enrollments.filter((item) => item.id !== enrollmentId)
  })),
  on(deleteEnrollmentFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error
  })),
  on(selectEnrollment, (state, { enrollmentId }) => ({
    ...state,
    selectedEnrollmentId: enrollmentId
  }))
);

export const selectEnrollmentStateReducer = (state: EnrollmentState) => state;

