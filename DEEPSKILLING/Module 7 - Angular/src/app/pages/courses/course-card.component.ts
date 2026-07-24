import { NgClass, NgFor, NgStyle } from '@angular/common';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Course } from '../../models/course.model';
import { HighlightDirective } from '../../shared/directives/highlight.directive';
import { CreditLabelPipe } from '../../shared/pipes/credit-label.pipe';

@Component({
  selector: 'app-course-card',
  standalone: true,
  imports: [NgClass, NgFor, NgStyle, HighlightDirective, CreditLabelPipe],
  templateUrl: './course-card.component.html',
  styleUrl: './course-card.component.scss'
})
export class CourseCardComponent implements OnInit, OnChanges {
  @Input({ required: true }) course!: Course;
  @Output() enrolled = new EventEmitter<Course>();
  @Output() details = new EventEmitter<Course>();

  protected accentColor = '#7c5cff';
  protected levelBadgeClass = 'level-badge--beginner';
  protected ratingWidth = '0%';

  ngOnInit(): void {
    this.refreshPresentation();
  }

  ngOnChanges(_changes: SimpleChanges): void {
    this.refreshPresentation();
  }

  emitEnroll(): void {
    this.enrolled.emit(this.course);
  }

  emitDetails(): void {
    this.details.emit(this.course);
  }

  trackByTag(_index: number, tag: string): string {
    return tag;
  }

  private refreshPresentation(): void {
    if (!this.course) {
      return;
    }

    this.ratingWidth = `${Math.round((this.course.rating / 5) * 100)}%`;
    switch (this.course.level) {
      case 'Beginner':
        this.accentColor = '#6dd3ff';
        this.levelBadgeClass = 'level-badge--beginner';
        break;
      case 'Intermediate':
        this.accentColor = '#ffb86c';
        this.levelBadgeClass = 'level-badge--intermediate';
        break;
      case 'Advanced':
        this.accentColor = '#a78bfa';
        this.levelBadgeClass = 'level-badge--advanced';
        break;
    }
  }
}
