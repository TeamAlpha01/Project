import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TacEditPoolMemberComponent } from './tac-edit-pool-member.component';

describe('TacEditPoolMemberComponent', () => {
  let component: TacEditPoolMemberComponent;
  let fixture: ComponentFixture<TacEditPoolMemberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TacEditPoolMemberComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TacEditPoolMemberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
