import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacCancelledDriveHistoryComponent } from './tac-cancelled-drive-history.component';

describe('TacCancelledDriveHistoryComponent', () => {
  let component: TacCancelledDriveHistoryComponent;
  let fixture: ComponentFixture<TacCancelledDriveHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacCancelledDriveHistoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacCancelledDriveHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
