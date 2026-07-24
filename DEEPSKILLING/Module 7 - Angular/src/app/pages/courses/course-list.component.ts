import { NgFor, NgIf } from '@angular/common';
import { Component, DestroyRef, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Course } from '../../models/course.model';
import { CourseService } from '../../services/course.service';
import { CourseCardComponent } from './course-card.component';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-course-list',
  standalone: true,
  imports: [NgIf, NgFor, FormsModule, RouterLink, CourseCardComponent],
  templateUrl: './course-list.component.html',
  styleUrl: './course-list.component.scss'
})
export class CourseListComponent implements OnInit {
  private readonly destroyRef = inject(DestroyRef);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);
  protected readonly courseService = inject(CourseService);

  searchTerm = '';
  levelFilter = 'All';
  courses: Course[] = [];
  filteredCourses: Course[] = [];
  readonly levelOptions = ['All', 'Beginner', 'Intermediate', 'Advanced'];

  ngOnInit(): void {
    this.route.queryParamMap.pipe(takeUntilDestroyed(this.destroyRef)).subscribe((params) => {
      const search = params.get('search');
      if (search !== null) {
        this.searchTerm = search;
      }
      this.applyFilters();
    });

    this.courseService.loadCourses().pipe(takeUntilDestroyed(this.destroyRef)).subscribe((courses) => {
      this.courses = courses;
      this.applyFilters();
    });
  }

  applyFilters(): void {
    const term = this.searchTerm.trim().toLowerCase();
    this.filteredCourses = this.courses.filter((course) => {
      const matchesSearch =
        !term ||
        course.title.toLowerCase().includes(term) ||
        course.code.toLowerCase().includes(term) ||
        course.category.toLowerCase().includes(term) ||
        course.tags.some((tag) => tag.toLowerCase().includes(term));
      const matchesLevel = this.levelFilter === 'All' || course.level === this.levelFilter;
      return matchesSearch && matchesLevel;
    });
  }

  trackByCourseId(_index: number, course: Course): number {
    return course.id;
  }

  openCourse(course: Course): void {
    void this.router.navigate(['/courses', course.id], { queryParams: { tab: 'overview' } });
  }

  enrollCourse(course: Course): void {
    void this.router.navigate(['/enrollment'], {
      queryParams: { courseId: course.id, title: course.title }
    });
  }

  clearFilters(): void {
    this.searchTerm = '';
    this.levelFilter = 'All';
    this.applyFilters();
    void this.router.navigate([], { relativeTo: this.route, queryParams: {} });
  }
}
