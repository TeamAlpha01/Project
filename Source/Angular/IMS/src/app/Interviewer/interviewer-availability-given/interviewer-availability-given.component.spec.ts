import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerAvailabilityGivenComponent } from './interviewer-availability-given.component';

describe('InterviewerAvailabilityGivenComponent', () => {
  let component: InterviewerAvailabilityGivenComponent;
  let fixture: ComponentFixture<InterviewerAvailabilityGivenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerAvailabilityGivenComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerAvailabilityGivenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
