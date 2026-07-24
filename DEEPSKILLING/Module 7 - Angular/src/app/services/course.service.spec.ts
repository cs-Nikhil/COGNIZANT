import { HttpClient } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { seedCourses } from '../data/seed-data';
import { Course } from '../models/course.model';
import { CourseService } from './course.service';

describe('CourseService', () => {
  let service: CourseService;
  let httpClient: {
    get: jasmine.Spy;
    post: jasmine.Spy;
    put: jasmine.Spy;
    delete: jasmine.Spy;
  };

  beforeEach(() => {
    httpClient = {
      get: jasmine.createSpy('get').and.returnValue(of(seedCourses)),
      post: jasmine.createSpy('post').and.callFake((_url: string, body: Course) => of({ ...body, id: 99 })),
      put: jasmine.createSpy('put').and.callFake((_url: string, body: Course) => of(body)),
      delete: jasmine.createSpy('delete').and.returnValue(of(void 0))
    };

    TestBed.configureTestingModule({
      providers: [
        CourseService,
        { provide: HttpClient, useValue: httpClient }
      ]
    });
    service = TestBed.inject(CourseService);
  });

  it('should load courses', (done) => {
    service.loadCourses().subscribe((courses) => {
      expect(courses.length).toBeGreaterThan(0);
      expect(httpClient.get).toHaveBeenCalled();
      done();
    });
  });

  it('should filter courses by search term', (done) => {
    service.searchCourses('angular').subscribe((courses) => {
      expect(courses.length).toBeGreaterThan(0);
      done();
    });
  });
});
