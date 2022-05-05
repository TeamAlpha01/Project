import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PoolmembersPerformanceComponent } from './poolmembers-performance.component';

describe('PoolmembersPerformanceComponent', () => {
  let component: PoolmembersPerformanceComponent;
  let fixture: ComponentFixture<PoolmembersPerformanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PoolmembersPerformanceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PoolmembersPerformanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
