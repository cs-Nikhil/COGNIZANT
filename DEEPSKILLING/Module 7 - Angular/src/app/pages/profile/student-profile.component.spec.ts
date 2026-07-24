import { ComponentFixture, TestBed } from '@angular/core/testing';
import { provideMockStore, MockStore } from '@ngrx/store/testing';
import { StudentProfileComponent } from './student-profile.component';

describe('StudentProfileComponent', () => {
  let fixture: ComponentFixture<StudentProfileComponent>;
  let store: MockStore;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StudentProfileComponent],
      providers: [
        provideMockStore({
          initialState: {
            enrollment: {
              enrollments: [],
              loading: false,
              error: null,
              selectedEnrollmentId: null
            }
          }
        })
      ]
    }).compileComponents();

    store = TestBed.inject(MockStore);
    fixture = TestBed.createComponent(StudentProfileComponent);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(fixture.componentInstance).toBeTruthy();
    expect(store).toBeTruthy();
  });
});

