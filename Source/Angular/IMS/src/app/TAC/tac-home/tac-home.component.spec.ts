import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacHomeComponent } from './tac-home.component';

describe('TacHomeComponent', () => {
  let component: TacHomeComponent;
  let fixture: ComponentFixture<TacHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
