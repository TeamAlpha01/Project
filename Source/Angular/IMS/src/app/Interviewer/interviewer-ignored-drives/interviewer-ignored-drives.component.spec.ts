import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerIgnoredDrivesComponent } from './interviewer-ignored-drives.component';

describe('InterviewerIgnoredDrivesComponent', () => {
  let component: InterviewerIgnoredDrivesComponent;
  let fixture: ComponentFixture<InterviewerIgnoredDrivesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerIgnoredDrivesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerIgnoredDrivesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
