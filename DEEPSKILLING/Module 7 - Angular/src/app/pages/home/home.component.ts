import { AsyncPipe, CurrencyPipe, NgFor, NgIf } from '@angular/common';
import { Component, DestroyRef, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { combineLatest, map } from 'rxjs';
import { Course } from '../../models/course.model';
import { CourseService } from '../../services/course.service';
import { EnrollmentService } from '../../services/enrollment.service';
import { NotificationService } from '../../services/notification.service';
import { CreditLabelPipe } from '../../shared/pipes/credit-label.pipe';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NgIf, NgFor, AsyncPipe, FormsModule, CurrencyPipe, CreditLabelPipe, RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  private readonly destroyRef = inject(DestroyRef);
  private readonly router = inject(Router);
  private readonly notificationService = inject(NotificationService);
  protected readonly courseService = inject(CourseService);
  protected readonly enrollmentService = inject(EnrollmentService);

  quickSearch = '';

  readonly dashboard$ = combineLatest([
    this.courseService.courses$,
    this.enrollmentService.enrollments$
  ]).pipe(
    map(([courses, enrollments]) => ({
      courseCount: courses.length,
      enrollmentCount: enrollments.length,
      featuredCount: courses.filter((course) => course.featured).length,
      nextIntake: 'August 4, 2026'
    }))
  );

  readonly featuredCourses$ = this.courseService.courses$.pipe(
    map((courses) => courses.filter((course) => course.featured).slice(0, 3))
  );

  ngOnInit(): void {
    this.courseService.loadCourses().pipe(takeUntilDestroyed(this.destroyRef)).subscribe();
    this.enrollmentService.loadEnrollments().pipe(takeUntilDestroyed(this.destroyRef)).subscribe();
  }

  explore(): void {
    const term = this.quickSearch.trim();
    if (!term) {
      this.notificationService.info('Search tip', 'Type a course, code, or topic before browsing.');
      return;
    }

    void this.router.navigate(['/courses'], { queryParams: { search: term } });
  }

  trackByCourseId(_index: number, course: Course): number {
    return course.id;
  }
}
