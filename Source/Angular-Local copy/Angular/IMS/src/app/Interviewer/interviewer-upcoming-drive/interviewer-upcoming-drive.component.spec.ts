import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerUpcomingDriveComponent } from './interviewer-upcoming-drive.component';

describe('InterviewerUpcomingDriveComponent', () => {
  let component: InterviewerUpcomingDriveComponent;
  let fixture: ComponentFixture<InterviewerUpcomingDriveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerUpcomingDriveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerUpcomingDriveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
