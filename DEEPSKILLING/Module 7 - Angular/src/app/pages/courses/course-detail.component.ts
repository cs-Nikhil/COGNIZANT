import { AsyncPipe, CurrencyPipe, NgFor, NgIf, NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';
import { Component, DestroyRef, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Observable, map, switchMap } from 'rxjs';
import { Course } from '../../models/course.model';
import { CourseService } from '../../services/course.service';
import { CreditLabelPipe } from '../../shared/pipes/credit-label.pipe';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

type DetailTab = 'overview' | 'lessons' | 'schedule';

@Component({
  selector: 'app-course-detail',
  standalone: true,
  imports: [AsyncPipe, CurrencyPipe, NgFor, NgIf, NgSwitch, NgSwitchCase, NgSwitchDefault, RouterLink, CreditLabelPipe],
  templateUrl: './course-detail.component.html',
  styleUrl: './course-detail.component.scss'
})
export class CourseDetailComponent implements OnInit {
  private readonly destroyRef = inject(DestroyRef);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);
  protected readonly courseService = inject(CourseService);

  course$!: Observable<Course | undefined>;
  activeTab: DetailTab = 'overview';

  ngOnInit(): void {
    this.course$ = this.route.paramMap.pipe(
      map((params) => Number(params.get('id'))),
      switchMap((id) => this.courseService.getCourseById(id))
    );

    this.route.queryParamMap.pipe(takeUntilDestroyed(this.destroyRef)).subscribe((params) => {
      const tab = params.get('tab');
      this.activeTab = tab === 'lessons' || tab === 'schedule' ? tab : 'overview';
    });
  }

  setTab(tab: DetailTab): void {
    void this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { tab },
      queryParamsHandling: 'merge'
    });
  }

  enroll(course: Course): void {
    void this.router.navigate(['/enrollment'], {
      queryParams: { courseId: course.id, title: course.title }
    });
  }

  trackByTag(_index: number, tag: string): string {
    return tag;
  }

  trackByLesson(_index: number, lesson: string): string {
    return lesson;
  }
}
