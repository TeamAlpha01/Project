import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentDrivesFilterComponent } from './current-drives-filter.component';

describe('CurrentDrivesFilterComponent', () => {
  let component: CurrentDrivesFilterComponent;
  let fixture: ComponentFixture<CurrentDrivesFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CurrentDrivesFilterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentDrivesFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
