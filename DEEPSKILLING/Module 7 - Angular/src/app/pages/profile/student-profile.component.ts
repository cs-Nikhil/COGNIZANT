import { AsyncPipe, NgFor, NgIf } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { Store } from '@ngrx/store';
import { seedStudent } from '../../data/seed-data';
import { loadEnrollments } from '../../store/enrollment/enrollment.actions';
import { selectAllEnrollments, selectEnrollmentCount } from '../../store/enrollment/enrollment.selectors';

@Component({
  selector: 'app-student-profile',
  standalone: true,
  imports: [NgIf, NgFor, AsyncPipe],
  templateUrl: './student-profile.component.html',
  styleUrl: './student-profile.component.scss'
})
export class StudentProfileComponent implements OnInit {
  private readonly store = inject(Store);
  readonly student = seedStudent;
  readonly enrollments$ = this.store.select(selectAllEnrollments);
  readonly count$ = this.store.select(selectEnrollmentCount);

  ngOnInit(): void {
    this.store.dispatch(loadEnrollments());
  }

  trackByEnrollmentId(_index: number, enrollment: { id: number }): number {
    return enrollment.id;
  }
}
