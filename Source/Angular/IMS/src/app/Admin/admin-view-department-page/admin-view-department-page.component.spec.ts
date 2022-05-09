import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminviewDepartmentPageComponent } from './admin-view-Department-page.component';

describe('AdminAddDepartmentPageComponent', () => {
  let component: AdminviewDepartmentPageComponent;
  let fixture: ComponentFixture<AdminviewDepartmentPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminviewDepartmentPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminviewDepartmentPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
