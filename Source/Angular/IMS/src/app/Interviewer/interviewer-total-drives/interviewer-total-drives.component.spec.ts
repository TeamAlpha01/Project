import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerTotalDrivesComponent } from './interviewer-total-drives.component';

describe('InterviewerTotalDrivesComponent', () => {
  let component: InterviewerTotalDrivesComponent;
  let fixture: ComponentFixture<InterviewerTotalDrivesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerTotalDrivesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerTotalDrivesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
