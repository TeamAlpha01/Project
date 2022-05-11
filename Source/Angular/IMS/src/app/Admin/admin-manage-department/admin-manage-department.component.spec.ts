import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminManageDepartmentComponent } from './admin-manage-department.component';

describe('AdminManageDepartmentComponent', () => {
  let component: AdminManageDepartmentComponent;
  let fixture: ComponentFixture<AdminManageDepartmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminManageDepartmentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminManageDepartmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
