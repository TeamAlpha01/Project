import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerUtilizedDrivesComponent } from './interviewer-utilized-drives.component';

describe('InterviewerUtilizedDrivesComponent', () => {
  let component: InterviewerUtilizedDrivesComponent;
  let fixture: ComponentFixture<InterviewerUtilizedDrivesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerUtilizedDrivesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerUtilizedDrivesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
