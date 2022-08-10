import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAddprojectComponent } from './admin-addproject.component';

describe('AdminAddprojectComponent', () => {
  let component: AdminAddprojectComponent;
  let fixture: ComponentFixture<AdminAddprojectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminAddprojectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminAddprojectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
