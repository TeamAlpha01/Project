import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacCancelDriveComponent } from './tac-cancel-drive.component';

describe('TacCancelDriveComponent', () => {
  let component: TacCancelDriveComponent;
  let fixture: ComponentFixture<TacCancelDriveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacCancelDriveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacCancelDriveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
