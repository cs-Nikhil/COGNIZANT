import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';
import { of } from 'rxjs';
import { CourseService } from '../../services/course.service';
import { CourseDetailComponent } from './course-detail.component';

describe('CourseDetailComponent', () => {
  let fixture: ComponentFixture<CourseDetailComponent>;
  let component: CourseDetailComponent;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseDetailComponent],
      providers: [
        provideRouter([{ path: 'courses/:id', component: CourseDetailComponent }]),
        {
          provide: CourseService,
          useValue: {
            getCourseById: () =>
              of({
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
              })
          }
        }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(CourseDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

