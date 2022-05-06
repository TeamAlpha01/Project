import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminViewAddlocationPageComponent } from './admin-view-addlocation-page.component';

describe('AdminViewAddprojectPageComponent', () => {
  let component: AdminViewAddlocationPageComponent;
  let fixture: ComponentFixture<AdminViewAddlocationPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminViewAddlocationPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminViewAddlocationPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
