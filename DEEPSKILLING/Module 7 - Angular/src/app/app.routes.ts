import { Routes } from '@angular/router';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'home'
  },
  {
    path: 'home',
    loadComponent: () => import('./pages/home/home.component').then((m) => m.HomeComponent)
  },
  {
    path: 'courses',
    loadChildren: () =>
      import('./features/courses/courses.routes').then((m) => m.COURSES_ROUTES)
  },
  {
    path: 'enrollment',
    loadChildren: () =>
      import('./features/enrollment/enrollment.routes').then((m) => m.ENROLLMENT_ROUTES)
  },
  {
    path: 'profile',
    canActivate: [authGuard],
    loadComponent: () =>
      import('./pages/profile/student-profile.component').then((m) => m.StudentProfileComponent)
  },
  {
    path: 'login',
    loadComponent: () => import('./pages/auth/login.component').then((m) => m.LoginComponent)
  },
  {
    path: '**',
    loadComponent: () => import('./pages/not-found/not-found.component').then((m) => m.NotFoundComponent)
  }
];

