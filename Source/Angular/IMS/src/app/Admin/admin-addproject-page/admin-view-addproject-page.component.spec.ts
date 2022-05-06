import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminViewAddprojectPageComponent } from './admin-view-addproject-view.component';

describe('AdminViewAddprojectPageComponent', () => {
  let component: AdminViewAddprojectPageComponent;
  let fixture: ComponentFixture<AdminViewAddprojectPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminViewAddprojectPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminViewAddprojectPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
