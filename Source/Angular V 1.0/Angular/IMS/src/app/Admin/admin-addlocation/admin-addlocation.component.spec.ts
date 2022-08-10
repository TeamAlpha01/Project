import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAddlocationComponent } from './admin-addlocation.component';

describe('AdminAddlocationComponent', () => {
  let component: AdminAddlocationComponent;
  let fixture: ComponentFixture<AdminAddlocationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminAddlocationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminAddlocationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
