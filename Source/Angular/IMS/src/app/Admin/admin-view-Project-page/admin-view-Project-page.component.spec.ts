import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAddprojectPageComponent } from './admin-view-Project-view.component';

describe('AdminAddProjectPageComponent', () => {
  let component: AdminAddprojectPageComponent;
  let fixture: ComponentFixture<AdminAddprojectPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminAddprojectPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminAddprojectPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
