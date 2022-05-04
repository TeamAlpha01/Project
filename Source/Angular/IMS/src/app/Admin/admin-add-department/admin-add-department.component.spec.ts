import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAddDepartmentComponent } from './admin-add-department.component';

describe('AdminAddDepartmentComponent', () => {
  let component: AdminAddDepartmentComponent;
  let fixture: ComponentFixture<AdminAddDepartmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminAddDepartmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminAddDepartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
