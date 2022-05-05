import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminViewRoleComponent } from './admin-view-role.component';

describe('AdminViewRoleComponent', () => {
  let component: AdminViewRoleComponent;
  let fixture: ComponentFixture<AdminViewRoleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminViewRoleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminViewRoleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
