import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacScheduledDriveHistoryComponent } from './tac-scheduled-drive-history.component';

describe('TacScheduledDriveHistoryComponent', () => {
  let component: TacScheduledDriveHistoryComponent;
  let fixture: ComponentFixture<TacScheduledDriveHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacScheduledDriveHistoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacScheduledDriveHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
