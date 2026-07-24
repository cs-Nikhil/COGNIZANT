import { NgFor, NgIf } from '@angular/common';
import { Component, DestroyRef, OnInit, ViewChild, inject } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { filter, take } from 'rxjs';
import { Course } from '../../models/course.model';
import { EnrollmentDraft } from '../../models/enrollment.model';
import { CourseService } from '../../services/course.service';
import { EnrollmentService } from '../../services/enrollment.service';
import { NotificationService } from '../../services/notification.service';
import { loadEnrollments } from '../../store/enrollment/enrollment.actions';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-enrollment-form',
  standalone: true,
  imports: [FormsModule, NgIf, NgFor],
  templateUrl: './enrollment-form.component.html',
  styleUrl: './enrollment-form.component.scss'
})
export class EnrollmentFormComponent implements OnInit {
  @ViewChild('enrollmentForm') enrollmentForm?: NgForm;

  private readonly destroyRef = inject(DestroyRef);
  private readonly route = inject(ActivatedRoute);
  private readonly store = inject(Store);
  protected readonly courseService = inject(CourseService);
  protected readonly enrollmentService = inject(EnrollmentService);
  protected readonly notificationService = inject(NotificationService);

  readonly courseOptions$ = this.courseService.courses$;
  courses: Course[] = [];
  successMessage = '';

  draft: EnrollmentDraft = {
    studentName: '',
    email: '',
    courseId: 1,
    courseTitle: '',
    mode: 'Online',
    notes: ''
  };

  ngOnInit(): void {
    this.courseService.loadCourses().pipe(takeUntilDestroyed(this.destroyRef)).subscribe((courses) => {
      this.courses = courses;
      this.syncCourseTitle();
    });

    this.route.queryParamMap.pipe(takeUntilDestroyed(this.destroyRef)).subscribe((params) => {
      const courseId = Number(params.get('courseId') ?? this.draft.courseId);
      if (!Number.isNaN(courseId) && courseId > 0) {
        this.draft.courseId = courseId;
      }
      this.syncCourseTitle();

      const title = params.get('title');
      if (title) {
        this.draft.courseTitle = title;
      }
    });
  }

  submit(form: NgForm): void {
    if (form.invalid) {
      form.control.markAllAsTouched();
      this.notificationService.warning('Validation required', 'Please complete the required enrollment fields.');
      return;
    }

    const selectedCourse = this.courses.find((course) => course.id === Number(this.draft.courseId));
    const payload: EnrollmentDraft = {
      ...this.draft,
      courseTitle: selectedCourse?.title ?? this.draft.courseTitle
    };

    this.enrollmentService
      .createEnrollment(payload)
      .pipe(take(1))
      .subscribe((created) => {
        this.successMessage = `${created.studentName} enrolled in ${created.courseTitle}.`;
        this.notificationService.success('Enrollment saved', this.successMessage);
        this.store.dispatch(loadEnrollments());
        form.resetForm({
          studentName: '',
          email: '',
          courseId: this.draft.courseId,
          courseTitle: payload.courseTitle,
          mode: 'Online',
          notes: ''
        });
        this.syncCourseTitle();
    });
  }

  reset(form: NgForm): void {
    form.resetForm({
      studentName: '',
      email: '',
      courseId: this.draft.courseId,
      courseTitle: this.draft.courseTitle,
      mode: 'Online',
      notes: ''
    });
    this.successMessage = '';
  }

  onCourseChanged(courseId: string | number): void {
    this.draft.courseId = Number(courseId);
    this.syncCourseTitle();
  }

  trackByCourseId(_index: number, course: Course): number {
    return course.id;
  }

  private syncCourseTitle(): void {
    const selectedCourse = this.courses.find((course) => course.id === Number(this.draft.courseId));
    if (selectedCourse) {
      this.draft.courseTitle = selectedCourse.title;
    }
  }
}
