import { NgFor, NgIf } from '@angular/common';
import { Component, DestroyRef, OnInit, inject } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { Store } from '@ngrx/store';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { Course } from '../../models/course.model';
import { EnrollmentDraft } from '../../models/enrollment.model';
import { allowedCourseCodeValidator, emailTakenAsyncValidator, minWordCountValidator } from '../../validators/enrollment.validators';
import { CourseService } from '../../services/course.service';
import { EnrollmentService } from '../../services/enrollment.service';
import { NotificationService } from '../../services/notification.service';
import { createEnrollment } from '../../store/enrollment/enrollment.actions';
import { CanComponentDeactivate } from '../../models/can-deactivate.model';

@Component({
  selector: 'app-reactive-enrollment',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf, NgFor, RouterLink],
  templateUrl: './reactive-enrollment.component.html',
  styleUrl: './reactive-enrollment.component.scss'
})
export class ReactiveEnrollmentComponent implements OnInit, CanComponentDeactivate {
  private readonly fb = inject(FormBuilder);
  private readonly destroyRef = inject(DestroyRef);
  private readonly store = inject(Store);
  protected readonly courseService = inject(CourseService);
  protected readonly enrollmentService = inject(EnrollmentService);
  protected readonly notificationService = inject(NotificationService);

  courses: Course[] = [];
  submittedMessage = '';

  readonly form = this.fb.group({
    studentName: ['', [Validators.required, minWordCountValidator(2)]],
    email: ['', [Validators.required, Validators.email], [emailTakenAsyncValidator(this.enrollmentService)]],
    courseId: [1, [Validators.required]],
    courseCode: ['', [Validators.required, allowedCourseCodeValidator(['ANG-'])]],
    mode: ['Online', [Validators.required]],
    notes: [''],
    goals: this.fb.array([
      this.fb.control('Finish the exercises'),
      this.fb.control('Build a demo')
    ])
  });

  ngOnInit(): void {
    this.courseService.loadCourses().pipe(takeUntilDestroyed(this.destroyRef)).subscribe((courses) => {
      this.courses = courses;
    });
  }

  get goals(): FormArray {
    return this.form.get('goals') as FormArray;
  }

  addGoal(): void {
    this.goals.push(this.fb.control(''));
  }

  removeGoal(index: number): void {
    if (this.goals.length > 1) {
      this.goals.removeAt(index);
    }
  }

  submit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      this.notificationService.warning('Please review the form', 'Reactive enrollment validation failed.');
      return;
    }

    const course = this.courses.find((item) => item.id === Number(this.form.value.courseId));
    const payload: EnrollmentDraft = {
      studentName: this.form.value.studentName ?? '',
      email: this.form.value.email ?? '',
      courseId: Number(this.form.value.courseId),
      courseTitle: course?.title ?? 'Selected course',
      mode: (this.form.value.mode as 'Online' | 'Offline') ?? 'Online',
      notes: this.form.value.notes ?? ''
    };

    this.store.dispatch(createEnrollment({ enrollment: payload }));
    this.submittedMessage = `${payload.studentName} submitted for ${payload.courseTitle}.`;
    this.notificationService.success('Reactive enrollment queued', this.submittedMessage);
    this.form.markAsPristine();
  }

  canDeactivate(): boolean {
    return this.form.pristine || confirm('You have unsaved changes. Leave this form?');
  }

  trackByGoalIndex(index: number): number {
    return index;
  }

  trackByCourseId(_index: number, course: Course): number {
    return course.id;
  }
}
