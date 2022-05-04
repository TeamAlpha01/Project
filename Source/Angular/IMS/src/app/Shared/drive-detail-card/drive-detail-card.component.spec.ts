import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DriveDetailCardComponent } from './drive-detail-card.component';

describe('DriveDetailCardComponent', () => {
  let component: DriveDetailCardComponent;
  let fixture: ComponentFixture<DriveDetailCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DriveDetailCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DriveDetailCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
