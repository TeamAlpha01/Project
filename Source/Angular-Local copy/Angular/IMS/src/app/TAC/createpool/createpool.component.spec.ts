import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatepoolComponent } from './createpool.component';

describe('CreatepoolComponent', () => {
  let component: CreatepoolComponent;
  let fixture: ComponentFixture<CreatepoolComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreatepoolComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatepoolComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
