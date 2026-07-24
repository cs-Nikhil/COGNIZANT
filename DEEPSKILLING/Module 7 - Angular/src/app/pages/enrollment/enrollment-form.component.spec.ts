import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideRouter } from '@angular/router';
import { provideMockStore } from '@ngrx/store/testing';
import { of } from 'rxjs';
import { CourseService } from '../../services/course.service';
import { EnrollmentService } from '../../services/enrollment.service';
import { NotificationService } from '../../services/notification.service';
import { EnrollmentFormComponent } from './enrollment-form.component';

describe('EnrollmentFormComponent', () => {
  let fixture: ComponentFixture<EnrollmentFormComponent>;
  let component: EnrollmentFormComponent;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EnrollmentFormComponent],
      providers: [
        provideRouter([]),
        provideMockStore({
          initialState: {
            enrollment: {
              enrollments: [],
              loading: false,
              error: null,
              selectedEnrollmentId: null
            }
          }
        }),
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
        },
        {
          provide: EnrollmentService,
          useValue: {
            createEnrollment: () =>
              of({
                id: 10,
                studentName: 'Test User',
                email: 'test@example.com',
                courseId: 1,
                courseTitle: 'Angular Foundations',
                mode: 'Online',
                status: 'Active',
                enrolledOn: '2026-07-24',
                notes: ''
              })
          }
        },
        {
          provide: NotificationService,
          useValue: {
            warning: jasmine.createSpy('warning'),
            success: jasmine.createSpy('success')
          }
        }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(EnrollmentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
