import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerNotUtilizedDrivesComponent } from './interviewer-not-utilized-drives.component';

describe('InterviewerNotUtilizedDrivesComponent', () => {
  let component: InterviewerNotUtilizedDrivesComponent;
  let fixture: ComponentFixture<InterviewerNotUtilizedDrivesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerNotUtilizedDrivesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerNotUtilizedDrivesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
