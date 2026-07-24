import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';
import { of } from 'rxjs';
import { CourseService } from '../../services/course.service';
import { CourseListComponent } from './course-list.component';

describe('CourseListComponent', () => {
  let fixture: ComponentFixture<CourseListComponent>;
  let component: CourseListComponent;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseListComponent],
      providers: [
        provideRouter([]),
        {
          provide: CourseService,
          useValue: {
            loadCourses: () =>
              of([
                {
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
                }
              ]),
            courses$: of([])
          }
        }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(CourseListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

