import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminViewRolePageComponent } from './admin-view-role-page.component';

describe('AdminViewRolePageComponent', () => {
  let component: AdminViewRolePageComponent;
  let fixture: ComponentFixture<AdminViewRolePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminViewRolePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminViewRolePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
