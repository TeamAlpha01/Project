import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminviewProjectPageComponent } from './admin-view-Project-page.component';

describe('AdminviewProjectPageComponent', () => {
  let component: AdminviewProjectPageComponent;
  let fixture: ComponentFixture<AdminviewProjectPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminviewProjectPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminviewProjectPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
