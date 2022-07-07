import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewDefaultersComponent } from './view-defaulters.component';

describe('ViewDefaultersComponent', () => {
  let component: ViewDefaultersComponent;
  let fixture: ComponentFixture<ViewDefaultersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewDefaultersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewDefaultersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
