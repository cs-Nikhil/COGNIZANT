import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CourseCardComponent } from './course-card.component';

describe('CourseCardComponent', () => {
  let fixture: ComponentFixture<CourseCardComponent>;
  let component: CourseCardComponent;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseCardComponent]
    }).compileComponents();

    fixture = TestBed.createComponent(CourseCardComponent);
    component = fixture.componentInstance;
    component.course = {
      id: 1,
      code: 'ANG-201',
      title: 'Angular Foundations',
      description: 'Learn Angular',
      category: 'Frontend',
      level: 'Beginner',
      credits: 3,
      durationWeeks: 4,
      instructor: 'Priya',
      price: 4999,
      rating: 4.8,
      seats: 20,
      featured: true,
      tags: ['Angular'],
      lessons: ['One'],
      schedule: 'Mon'
    };
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should emit details when requested', () => {
    spyOn(component.details, 'emit');
    component.emitDetails();
    expect(component.details.emit).toHaveBeenCalledWith(component.course);
  });
});

