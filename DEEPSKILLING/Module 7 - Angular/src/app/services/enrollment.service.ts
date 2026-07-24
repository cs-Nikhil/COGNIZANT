import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { BehaviorSubject, catchError, map, Observable, of, retry, tap } from 'rxjs';
import { seedEnrollments } from '../data/seed-data';
import { Enrollment, EnrollmentDraft } from '../models/enrollment.model';

@Injectable({
  providedIn: 'root'
})
export class EnrollmentService {
  private readonly http = inject(HttpClient);
  private readonly enrollmentsUrl = 'http://localhost:3000/enrollments';
  private readonly enrollmentsSubject = new BehaviorSubject<Enrollment[]>(seedEnrollments);

  readonly enrollments$ = this.enrollmentsSubject.asObservable();

  loadEnrollments(): Observable<Enrollment[]> {
    return this.http.get<Enrollment[]>(this.enrollmentsUrl).pipe(
      retry(2),
      map((enrollments) => this.sortEnrollments(enrollments)),
      tap((enrollments) => this.enrollmentsSubject.next(enrollments)),
      catchError(() => of(this.sortEnrollments(this.enrollmentsSubject.value.length ? this.enrollmentsSubject.value : seedEnrollments)))
    );
  }

  getEnrollmentById(id: number): Observable<Enrollment | undefined> {
    return this.loadEnrollments().pipe(map((enrollments) => enrollments.find((enrollment) => enrollment.id === id)));
  }

  getEnrollmentsByCourseId(courseId: number): Observable<Enrollment[]> {
    return this.loadEnrollments().pipe(map((enrollments) => enrollments.filter((enrollment) => enrollment.courseId === courseId)));
  }

  isEmailTaken(email: string): Observable<boolean> {
    const normalized = email.trim().toLowerCase();
    return this.loadEnrollments().pipe(
      map((enrollments) => enrollments.some((enrollment) => enrollment.email.toLowerCase() === normalized))
    );
  }

  createEnrollment(draft: EnrollmentDraft): Observable<Enrollment> {
    const payload: Omit<Enrollment, 'id'> = {
      ...draft,
      status: 'Active',
      enrolledOn: new Date().toISOString().slice(0, 10)
    };

    return this.http.post<Enrollment>(this.enrollmentsUrl, payload).pipe(
      tap((created) =>
        this.enrollmentsSubject.next(this.sortEnrollments([...this.enrollmentsSubject.value, created]))
      ),
      catchError(() => {
        const created: Enrollment = { ...payload, id: this.nextId() };
        this.enrollmentsSubject.next(this.sortEnrollments([...this.enrollmentsSubject.value, created]));
        return of(created);
      })
    );
  }

  updateEnrollment(enrollment: Enrollment): Observable<Enrollment> {
    return this.http.put<Enrollment>(`${this.enrollmentsUrl}/${enrollment.id}`, enrollment).pipe(
      tap((updated) => this.replaceEnrollment(updated)),
      catchError(() => {
        this.replaceEnrollment(enrollment);
        return of(enrollment);
      })
    );
  }

  deleteEnrollment(id: number): Observable<void> {
    return this.http.delete<void>(`${this.enrollmentsUrl}/${id}`).pipe(
      tap(() => this.enrollmentsSubject.next(this.enrollmentsSubject.value.filter((item) => item.id !== id))),
      catchError(() => {
        this.enrollmentsSubject.next(this.enrollmentsSubject.value.filter((item) => item.id !== id));
        return of(void 0);
      })
    );
  }

  private replaceEnrollment(enrollment: Enrollment): void {
    const nextEnrollments = this.enrollmentsSubject.value.filter((item) => item.id !== enrollment.id);
    this.enrollmentsSubject.next(this.sortEnrollments([...nextEnrollments, enrollment]));
  }

  private sortEnrollments(enrollments: Enrollment[]): Enrollment[] {
    return [...enrollments].sort((left, right) => right.enrolledOn.localeCompare(left.enrolledOn));
  }

  private nextId(): number {
    return Math.max(0, ...this.enrollmentsSubject.value.map((item) => item.id)) + 1;
  }
}

