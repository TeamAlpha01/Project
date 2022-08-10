import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacViewResponseComponent } from './tac-view-response.component';

describe('TacViewResponseComponent', () => {
  let component: TacViewResponseComponent;
  let fixture: ComponentFixture<TacViewResponseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacViewResponseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacViewResponseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
