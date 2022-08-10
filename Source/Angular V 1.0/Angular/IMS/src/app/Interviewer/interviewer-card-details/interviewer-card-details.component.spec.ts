import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerCardDetailsComponent } from './interviewer-card-details.component';

describe('InterviewerCardDetailsComponent', () => {
  let component: InterviewerCardDetailsComponent;
  let fixture: ComponentFixture<InterviewerCardDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerCardDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerCardDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
