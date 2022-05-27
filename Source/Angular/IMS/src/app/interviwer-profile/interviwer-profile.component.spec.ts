import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterviwerProfileComponent } from './interviwer-profile.component';

describe('InterviwerProfileComponent', () => {
  let component: InterviwerProfileComponent;
  let fixture: ComponentFixture<InterviwerProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterviwerProfileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterviwerProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
