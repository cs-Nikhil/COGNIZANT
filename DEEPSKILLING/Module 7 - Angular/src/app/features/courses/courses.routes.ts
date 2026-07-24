import { Routes } from '@angular/router';

export const COURSES_ROUTES: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('../../pages/courses/courses-page.component').then((m) => m.CoursesPageComponent),
    children: [
      {
        path: '',
        loadComponent: () =>
          import('../../pages/courses/course-list.component').then((m) => m.CourseListComponent)
      },
      {
        path: ':id',
        loadComponent: () =>
          import('../../pages/courses/course-detail.component').then((m) => m.CourseDetailComponent)
      }
    ]
  }
];

