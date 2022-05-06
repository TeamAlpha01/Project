import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAdddepartmentPageComponent } from './admin-adddepartment-page.component';

describe('AdminAddprojectPageComponent', () => {
  let component: AdminAdddepartmentPageComponent;
  let fixture: ComponentFixture<AdminAdddepartmentPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminAdddepartmentPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminAdddepartmentPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
