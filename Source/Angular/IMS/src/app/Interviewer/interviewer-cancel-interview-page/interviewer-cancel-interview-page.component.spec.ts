import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerCancelInterviewPageComponent } from './interviewer-cancel-interview-page.component';

describe('InterviewerCancelInterviewPageComponent', () => {
  let component: InterviewerCancelInterviewPageComponent;
  let fixture: ComponentFixture<InterviewerCancelInterviewPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerCancelInterviewPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerCancelInterviewPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
