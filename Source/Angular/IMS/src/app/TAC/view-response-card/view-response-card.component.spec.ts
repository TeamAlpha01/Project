import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewResponseCardComponent } from './view-response-card.component';

describe('ViewResponseCardComponent', () => {
  let component: ViewResponseCardComponent;
  let fixture: ComponentFixture<ViewResponseCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewResponseCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewResponseCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
