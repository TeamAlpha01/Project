import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminViewDepartmentPageComponent } from './admin-view-department-page.component';

describe('AdminViewDepartmentPageComponent', () => {
  let component: AdminViewDepartmentPageComponent;
  let fixture: ComponentFixture<AdminViewDepartmentPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminViewDepartmentPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminViewDepartmentPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
