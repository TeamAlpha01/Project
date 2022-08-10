import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacUpcomingDriveComponent } from './tac-upcoming-drive.component';

describe('TacUpcomingDriveComponent', () => {
  let component: TacUpcomingDriveComponent;
  let fixture: ComponentFixture<TacUpcomingDriveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacUpcomingDriveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacUpcomingDriveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
