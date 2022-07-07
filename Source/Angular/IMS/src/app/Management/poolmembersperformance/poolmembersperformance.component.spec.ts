import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PoolmembersperformanceComponent } from './poolmembersperformance.component';

describe('PoolmembersperformanceComponent', () => {
  let component: PoolmembersperformanceComponent;
  let fixture: ComponentFixture<PoolmembersperformanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PoolmembersperformanceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PoolmembersperformanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
