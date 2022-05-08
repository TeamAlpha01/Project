import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminViewProjectPageComponent } from './admin-view-project-page.component';

describe('AdminViewProjectPageComponent', () => {
  let component: AdminViewProjectPageComponent;
  let fixture: ComponentFixture<AdminViewProjectPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminViewProjectPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminViewProjectPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
