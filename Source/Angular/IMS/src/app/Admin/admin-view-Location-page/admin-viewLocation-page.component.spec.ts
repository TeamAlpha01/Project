import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminviewLocationPageComponent } from './admin-viewLocation-page.component';

describe('AdminViewAddprojectPageComponent', () => {
  let component: AdminviewLocationPageComponent;
  let fixture: ComponentFixture<AdminviewLocationPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminviewLocationPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminviewLocationPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
