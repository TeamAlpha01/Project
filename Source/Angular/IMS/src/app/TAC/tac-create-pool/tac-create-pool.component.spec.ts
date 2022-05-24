import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacCreatePoolComponent } from './tac-create-pool.component';

describe('TacCreatePoolComponent', () => {
  let component: TacCreatePoolComponent;
  let fixture: ComponentFixture<TacCreatePoolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacCreatePoolComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacCreatePoolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
