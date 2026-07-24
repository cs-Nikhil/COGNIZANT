import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { seedEnrollments } from '../data/seed-data';
import { EnrollmentDraft, Enrollment } from '../models/enrollment.model';
import { EnrollmentService } from './enrollment.service';

describe('EnrollmentService', () => {
  let service: EnrollmentService;
  let httpClient: {
    get: jasmine.Spy;
    post: jasmine.Spy;
    put: jasmine.Spy;
    delete: jasmine.Spy;
  };

  beforeEach(() => {
    httpClient = {
      get: jasmine.createSpy('get').and.returnValue(of(seedEnrollments)),
      post: jasmine.createSpy('post').and.callFake((_url: string, body: Omit<Enrollment, 'id'>) =>
        of({ ...body, id: 20 })
      ),
      put: jasmine.createSpy('put').and.callFake((_url: string, body: Enrollment) => of(body)),
      delete: jasmine.createSpy('delete').and.returnValue(of(void 0))
    };

    TestBed.configureTestingModule({
      providers: [EnrollmentService, { provide: HttpClient, useValue: httpClient }]
    });

    service = TestBed.inject(EnrollmentService);
  });

  it('should detect taken emails', (done) => {
    service.isEmailTaken('aarav@example.com').subscribe((taken) => {
      expect(taken).toBeTrue();
      done();
    });
  });

  it('should create an enrollment', (done) => {
    const draft: EnrollmentDraft = {
      studentName: 'New Student',
      email: 'new@example.com',
      courseId: 1,
      courseTitle: 'Angular Foundations',
      mode: 'Online',
      notes: 'Testing'
    };

    service.createEnrollment(draft).subscribe((created) => {
      expect(created.id).toBe(20);
      expect(httpClient.post).toHaveBeenCalled();
      done();
    });
  });
});
