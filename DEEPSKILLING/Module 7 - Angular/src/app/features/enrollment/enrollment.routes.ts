import { Routes } from '@angular/router';
import { canDeactivateGuard } from '../../guards/can-deactivate.guard';

export const ENROLLMENT_ROUTES: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('../../pages/enrollment/enrollment-page.component').then((m) => m.EnrollmentPageComponent),
    children: [
      {
        path: '',
        loadComponent: () =>
          import('../../pages/enrollment/enrollment-form.component').then((m) => m.EnrollmentFormComponent)
      },
      {
        path: 'reactive',
        canDeactivate: [canDeactivateGuard],
        loadComponent: () =>
          import('../../pages/enrollment/reactive-enrollment.component').then(
            (m) => m.ReactiveEnrollmentComponent
          )
      }
    ]
  }
];

