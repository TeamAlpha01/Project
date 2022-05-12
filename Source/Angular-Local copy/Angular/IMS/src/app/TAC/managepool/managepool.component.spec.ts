import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagepoolComponent } from './managepool.component';

describe('ManagepoolComponent', () => {
  let component: ManagepoolComponent;
  let fixture: ComponentFixture<ManagepoolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManagepoolComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagepoolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
