import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminViewAdddepartmentPageComponent } from './admin-view-adddepartment-page.component';

describe('AdminViewAddprojectPageComponent', () => {
  let component: AdminViewAdddepartmentPageComponent;
  let fixture: ComponentFixture<AdminViewAdddepartmentPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminViewAdddepartmentPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminViewAdddepartmentPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
