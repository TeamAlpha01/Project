import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacScheduledDriveComponent } from './tac-scheduled-drive.component';

describe('TacScheduledDriveComponent', () => {
  let component: TacScheduledDriveComponent;
  let fixture: ComponentFixture<TacScheduledDriveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacScheduledDriveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacScheduledDriveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
