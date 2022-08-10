import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacProfileComponent } from './tac-profile.component';

describe('TacProfileComponent', () => {
  let component: TacProfileComponent;
  let fixture: ComponentFixture<TacProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacProfileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
