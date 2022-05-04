import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAdddepartmentComponent } from './admin-adddepartment.component';

describe('AdminAdddepartmentComponent', () => {
  let component: AdminAdddepartmentComponent;
  let fixture: ComponentFixture<AdminAdddepartmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminAdddepartmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminAdddepartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
