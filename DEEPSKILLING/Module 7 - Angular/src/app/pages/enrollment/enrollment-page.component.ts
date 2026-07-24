import { AsyncPipe, NgFor, NgIf } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { Store } from '@ngrx/store';
import { loadEnrollments } from '../../store/enrollment/enrollment.actions';
import {
  selectAllEnrollments,
  selectEnrollmentCount,
  selectEnrollmentLoading
} from '../../store/enrollment/enrollment.selectors';

@Component({
  selector: 'app-enrollment-page',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, RouterOutlet, AsyncPipe, NgFor, NgIf],
  templateUrl: './enrollment-page.component.html',
  styleUrl: './enrollment-page.component.scss'
})
export class EnrollmentPageComponent implements OnInit {
  private readonly store = inject(Store);
  readonly enrollments$ = this.store.select(selectAllEnrollments);
  readonly count$ = this.store.select(selectEnrollmentCount);
  readonly loading$ = this.store.select(selectEnrollmentLoading);

  ngOnInit(): void {
    this.store.dispatch(loadEnrollments());
  }

  trackByEnrollmentId(_index: number, enrollment: { id: number }): number {
    return enrollment.id;
  }
}
