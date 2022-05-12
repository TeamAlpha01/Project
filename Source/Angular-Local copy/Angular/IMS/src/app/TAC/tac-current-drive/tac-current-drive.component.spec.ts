import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacCurrentDriveComponent } from './tac-current-drive.component';

describe('TacCurrentDriveComponent', () => {
  let component: TacCurrentDriveComponent;
  let fixture: ComponentFixture<TacCurrentDriveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacCurrentDriveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacCurrentDriveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
