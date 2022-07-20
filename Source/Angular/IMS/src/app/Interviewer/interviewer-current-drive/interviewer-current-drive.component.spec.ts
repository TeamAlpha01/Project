import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerCurrentDriveComponent } from './interviewer-current-drive.component';

describe('InterviewerCurrentDriveComponent', () => {
  let component: InterviewerCurrentDriveComponent;
  let fixture: ComponentFixture<InterviewerCurrentDriveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerCurrentDriveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerCurrentDriveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
