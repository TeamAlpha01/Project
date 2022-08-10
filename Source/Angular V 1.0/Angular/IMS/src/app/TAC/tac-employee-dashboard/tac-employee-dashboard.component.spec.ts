import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacEmployeeDashboardComponent } from './tac-employee-dashboard.component';

describe('TacEmployeeDashboardComponent', () => {
  let component: TacEmployeeDashboardComponent;
  let fixture: ComponentFixture<TacEmployeeDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacEmployeeDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacEmployeeDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
