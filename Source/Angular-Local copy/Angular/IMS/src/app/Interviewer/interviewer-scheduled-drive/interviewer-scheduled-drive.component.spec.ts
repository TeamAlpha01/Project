import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerScheduledDriveComponent } from './interviewer-scheduled-drive.component';

describe('InterviewerScheduledDriveComponent', () => {
  let component: InterviewerScheduledDriveComponent;
  let fixture: ComponentFixture<InterviewerScheduledDriveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerScheduledDriveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerScheduledDriveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
