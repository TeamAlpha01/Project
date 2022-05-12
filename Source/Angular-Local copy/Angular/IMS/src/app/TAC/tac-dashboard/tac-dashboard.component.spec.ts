import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacDashboardComponent } from './tac-dashboard.component';

describe('TacDashboardComponent', () => {
  let component: TacDashboardComponent;
  let fixture: ComponentFixture<TacDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
