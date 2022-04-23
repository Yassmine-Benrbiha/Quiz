import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseQuizzesComponent } from './course-quizzes.component';

describe('CourseQuizzesComponent', () => {
  let component: CourseQuizzesComponent;
  let fixture: ComponentFixture<CourseQuizzesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CourseQuizzesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseQuizzesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
