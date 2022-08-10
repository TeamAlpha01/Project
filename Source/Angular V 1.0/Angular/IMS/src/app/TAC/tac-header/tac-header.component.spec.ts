import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacHeaderComponent } from './tac-header.component';

describe('TacHeaderComponent', () => {
  let component: TacHeaderComponent;
  let fixture: ComponentFixture<TacHeaderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacHeaderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
