import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerCancelInvitePageComponent } from './interviewer-cancel-invite-page.component';

describe('InterviewerCancelInvitePageComponent', () => {
  let component: InterviewerCancelInvitePageComponent;
  let fixture: ComponentFixture<InterviewerCancelInvitePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerCancelInvitePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerCancelInvitePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
