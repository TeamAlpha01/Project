import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerDeniedDrivesComponent } from './interviewer-denied-drives.component';

describe('InterviewerDeniedDrivesComponent', () => {
  let component: InterviewerDeniedDrivesComponent;
  let fixture: ComponentFixture<InterviewerDeniedDrivesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerDeniedDrivesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerDeniedDrivesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
