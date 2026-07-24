export type EnrollmentMode = 'Online' | 'Offline';
export type EnrollmentStatus = 'Active' | 'Completed' | 'Paused';

export interface Enrollment {
  id: number;
  studentName: string;
  email: string;
  courseId: number;
  courseTitle: string;
  mode: EnrollmentMode;
  status: EnrollmentStatus;
  enrolledOn: string;
  notes: string;
}

export interface EnrollmentDraft {
  studentName: string;
  email: string;
  courseId: number;
  courseTitle: string;
  mode: EnrollmentMode;
  notes: string;
}

