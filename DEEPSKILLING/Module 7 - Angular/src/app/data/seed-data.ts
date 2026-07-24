import { Course } from '../models/course.model';
import { Enrollment } from '../models/enrollment.model';
import { Student } from '../models/student.model';

export const seedCourses: Course[] = [
  {
    id: 1,
    code: 'ANG-201',
    title: 'Angular Foundations',
    description: 'Master components, templates, bindings, and the standalone Angular 20 architecture.',
    category: 'Frontend',
    level: 'Beginner',
    credits: 3,
    durationWeeks: 4,
    instructor: 'Priya Kapoor',
    price: 4999,
    rating: 4.8,
    seats: 28,
    featured: true,
    tags: ['Angular', 'Standalone', 'Templates'],
    lessons: ['Project setup', 'Binding syntax', 'Standalone routing', 'Component communication'],
    schedule: 'Mon-Wed-Fri 7:00 PM'
  },
  {
    id: 2,
    code: 'ANG-301',
    title: 'Reactive Angular Applications',
    description: 'Build reactive forms, custom validators, and scalable data flows with RxJS.',
    category: 'Frontend',
    level: 'Intermediate',
    credits: 4,
    durationWeeks: 5,
    instructor: 'Rahul Mehta',
    price: 6499,
    rating: 4.7,
    seats: 20,
    featured: true,
    tags: ['Reactive Forms', 'RxJS', 'Validation'],
    lessons: ['FormBuilder', 'FormArray', 'Async validators', 'State orchestration'],
    schedule: 'Tue-Thu 6:30 PM'
  },
  {
    id: 3,
    code: 'ANG-401',
    title: 'Angular State Management',
    description: 'Organize feature state with NgRx store, effects, selectors, and devtools.',
    category: 'Architecture',
    level: 'Advanced',
    credits: 4,
    durationWeeks: 6,
    instructor: 'Ananya Rao',
    price: 7999,
    rating: 4.9,
    seats: 16,
    featured: false,
    tags: ['NgRx', 'Effects', 'Selectors'],
    lessons: ['Actions', 'Reducers', 'Effects', 'Devtools'],
    schedule: 'Sat 10:00 AM'
  },
  {
    id: 4,
    code: 'ANG-150',
    title: 'TypeScript for Angular Teams',
    description: 'Strengthen typings, interfaces, and reusable utilities for maintainable Angular code.',
    category: 'Core',
    level: 'Beginner',
    credits: 2,
    durationWeeks: 3,
    instructor: 'Sana Khan',
    price: 2999,
    rating: 4.6,
    seats: 34,
    featured: false,
    tags: ['TypeScript', 'Interfaces', 'Typing'],
    lessons: ['Generics', 'Union types', 'Utility types', 'Async patterns'],
    schedule: 'Mon-Thu 8:00 AM'
  },
  {
    id: 5,
    code: 'ANG-220',
    title: 'Angular HTTP and Interceptors',
    description: 'Connect Angular applications to REST APIs with error handling and loading feedback.',
    category: 'Backend Integration',
    level: 'Intermediate',
    credits: 3,
    durationWeeks: 4,
    instructor: 'Vikram Joshi',
    price: 5599,
    rating: 4.7,
    seats: 24,
    featured: true,
    tags: ['HttpClient', 'Interceptors', 'Error Handling'],
    lessons: ['GET/POST/PUT/DELETE', 'Retry', 'catchError', 'Loading UX'],
    schedule: 'Wed-Fri 6:00 PM'
  },
  {
    id: 6,
    code: 'ANG-330',
    title: 'Testing Angular Features',
    description: 'Write Jasmine and Karma tests for components, services, guards, and store logic.',
    category: 'Quality',
    level: 'Advanced',
    credits: 3,
    durationWeeks: 4,
    instructor: 'Neha Sharma',
    price: 5299,
    rating: 4.9,
    seats: 18,
    featured: false,
    tags: ['Testing', 'Karma', 'Jasmine'],
    lessons: ['TestBed', 'MockStore', 'SpyOn', 'Coverage'],
    schedule: 'Tue 7:30 PM'
  }
];

export const seedEnrollments: Enrollment[] = [
  {
    id: 1,
    studentName: 'Aarav Singh',
    email: 'aarav@example.com',
    courseId: 1,
    courseTitle: 'Angular Foundations',
    mode: 'Online',
    status: 'Active',
    enrolledOn: '2026-07-15',
    notes: 'Prefers weekend practice sessions.'
  },
  {
    id: 2,
    studentName: 'Diya Patel',
    email: 'diya@example.com',
    courseId: 2,
    courseTitle: 'Reactive Angular Applications',
    mode: 'Offline',
    status: 'Active',
    enrolledOn: '2026-07-18',
    notes: 'Needs extra guidance on validators.'
  },
  {
    id: 3,
    studentName: 'Kabir Verma',
    email: 'kabir@example.com',
    courseId: 5,
    courseTitle: 'Angular HTTP and Interceptors',
    mode: 'Online',
    status: 'Completed',
    enrolledOn: '2026-06-29',
    notes: 'Built a demo JSON server integration.'
  }
];

export const seedStudent: Student = {
  id: 1,
  name: 'Aarav Singh',
  email: 'aarav@example.com',
  batch: 'Angular 20 Cohort',
  role: 'Student',
  city: 'Bengaluru',
  bio: 'Hands-on learner focused on Angular, RxJS, and strong testing habits.'
};

