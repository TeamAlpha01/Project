import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAddlocationPageComponent } from './admin-addlocation-page.component';

describe('AdminViewAddprojectPageComponent', () => {
  let component: AdminAddlocationPageComponent;
  let fixture: ComponentFixture<AdminAddlocationPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminAddlocationPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminAddlocationPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
