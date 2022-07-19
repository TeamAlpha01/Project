import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerAcceptedDrivesComponent } from './interviewer-accepted-drives.component';

describe('InterviewerAcceptedDrivesComponent', () => {
  let component: InterviewerAcceptedDrivesComponent;
  let fixture: ComponentFixture<InterviewerAcceptedDrivesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerAcceptedDrivesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerAcceptedDrivesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
