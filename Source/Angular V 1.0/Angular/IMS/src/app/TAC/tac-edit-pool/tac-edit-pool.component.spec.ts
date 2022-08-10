import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacEditPoolComponent } from './tac-edit-pool.component';

describe('TacEditPoolComponent', () => {
  let component: TacEditPoolComponent;
  let fixture: ComponentFixture<TacEditPoolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacEditPoolComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacEditPoolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
