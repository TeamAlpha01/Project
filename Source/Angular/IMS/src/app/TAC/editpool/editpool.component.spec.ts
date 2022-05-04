import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditpoolComponent } from './editpool.component';

describe('EditpoolComponent', () => {
  let component: EditpoolComponent;
  let fixture: ComponentFixture<EditpoolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditpoolComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditpoolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
