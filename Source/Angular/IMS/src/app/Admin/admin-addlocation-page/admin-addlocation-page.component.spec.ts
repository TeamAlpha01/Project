import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAddLocationPageComponent } from './admin-addlocation-page.component';

describe('AdminViewAddprojectPageComponent', () => {
  let component: AdminAddLocationPageComponent;
  let fixture: ComponentFixture<AdminAddLocationPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminAddLocationPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminAddLocationPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
