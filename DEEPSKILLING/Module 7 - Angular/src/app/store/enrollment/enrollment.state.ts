import { seedEnrollments } from '../../data/seed-data';
import { Enrollment } from '../../models/enrollment.model';

export interface EnrollmentState {
  enrollments: Enrollment[];
  loading: boolean;
  error: string | null;
  selectedEnrollmentId: number | null;
}

export const enrollmentFeatureKey = 'enrollment';

export const initialEnrollmentState: EnrollmentState = {
  enrollments: seedEnrollments,
  loading: false,
  error: null,
  selectedEnrollmentId: null
};

