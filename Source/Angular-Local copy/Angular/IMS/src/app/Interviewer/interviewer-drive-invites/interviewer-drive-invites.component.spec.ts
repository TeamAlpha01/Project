import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviewerDriveInvitesComponent } from './interviewer-drive-invites.component';

describe('InterviewerDriveInvitesComponent', () => {
  let component: InterviewerDriveInvitesComponent;
  let fixture: ComponentFixture<InterviewerDriveInvitesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviewerDriveInvitesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviewerDriveInvitesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
