import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminViewRequestsPageComponent } from './admin-view-requests-page.component';

describe('AdminViewRequestsPageComponent', () => {
  let component: AdminViewRequestsPageComponent;
  let fixture: ComponentFixture<AdminViewRequestsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminViewRequestsPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminViewRequestsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});