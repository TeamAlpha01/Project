import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminViewLocationPageComponent } from './admin-view-location-page.component';

describe('AdminViewLocationPageComponent', () => {
  let component: AdminViewLocationPageComponent;
  let fixture: ComponentFixture<AdminViewLocationPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminViewLocationPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminViewLocationPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
