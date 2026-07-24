import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { BehaviorSubject, catchError, map, Observable, of, retry, tap } from 'rxjs';
import { seedCourses } from '../data/seed-data';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  private readonly http = inject(HttpClient);
  private readonly coursesUrl = 'http://localhost:3000/courses';
  private readonly coursesSubject = new BehaviorSubject<Course[]>(seedCourses);

  readonly courses$ = this.coursesSubject.asObservable();

  loadCourses(): Observable<Course[]> {
    return this.http.get<Course[]>(this.coursesUrl).pipe(
      retry(2),
      map((courses) => this.sortCourses(courses)),
      tap((courses) => this.coursesSubject.next(courses)),
      catchError(() => of(this.sortCourses(this.coursesSubject.value.length ? this.coursesSubject.value : seedCourses)))
    );
  }

  searchCourses(searchTerm: string): Observable<Course[]> {
    const normalized = searchTerm.trim().toLowerCase();
    return this.loadCourses().pipe(
      map((courses) =>
        normalized
          ? courses.filter(
              (course) =>
                course.title.toLowerCase().includes(normalized) ||
                course.code.toLowerCase().includes(normalized) ||
                course.category.toLowerCase().includes(normalized) ||
                course.tags.some((tag) => tag.toLowerCase().includes(normalized))
            )
          : courses
      )
    );
  }

  getCourseById(id: number): Observable<Course | undefined> {
    return this.loadCourses().pipe(map((courses) => courses.find((course) => course.id === id)));
  }

  createCourse(course: Omit<Course, 'id'>): Observable<Course> {
    const payload = this.normalizeCourse(course);
    return this.http.post<Course>(this.coursesUrl, payload).pipe(
      tap((created) =>
        this.coursesSubject.next(this.sortCourses([...this.coursesSubject.value, created]))
      ),
      catchError(() => {
        const created: Course = { ...payload, id: this.nextId() };
        this.coursesSubject.next(this.sortCourses([...this.coursesSubject.value, created]));
        return of(created);
      })
    );
  }

  updateCourse(course: Course): Observable<Course> {
    return this.http.put<Course>(`${this.coursesUrl}/${course.id}`, course).pipe(
      tap((updated) => this.replaceCourse(updated)),
      catchError(() => {
        this.replaceCourse(course);
        return of(course);
      })
    );
  }

  deleteCourse(id: number): Observable<void> {
    return this.http.delete<void>(`${this.coursesUrl}/${id}`).pipe(
      tap(() => this.coursesSubject.next(this.coursesSubject.value.filter((course) => course.id !== id))),
      catchError(() => {
        this.coursesSubject.next(this.coursesSubject.value.filter((course) => course.id !== id));
        return of(void 0);
      })
    );
  }

  private replaceCourse(course: Course): void {
    const nextCourses = this.coursesSubject.value.filter((item) => item.id !== course.id);
    this.coursesSubject.next(this.sortCourses([...nextCourses, course]));
  }

  private normalizeCourse(course: Omit<Course, 'id'>): Omit<Course, 'id'> {
    return {
      ...course,
      tags: [...course.tags],
      lessons: [...course.lessons]
    };
  }

  private sortCourses(courses: Course[]): Course[] {
    return [...courses].sort((left, right) => {
      if (left.featured !== right.featured) {
        return left.featured ? -1 : 1;
      }

      return left.title.localeCompare(right.title);
    });
  }

  private nextId(): number {
    return Math.max(0, ...this.coursesSubject.value.map((course) => course.id)) + 1;
  }
}

