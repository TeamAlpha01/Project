import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerCancelledDrivesComponent } from './interviewer-cancelled-drives.component';

describe('InterviewerCancelledDrivesComponent', () => {
  let component: InterviewerCancelledDrivesComponent;
  let fixture: ComponentFixture<InterviewerCancelledDrivesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerCancelledDrivesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerCancelledDrivesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
