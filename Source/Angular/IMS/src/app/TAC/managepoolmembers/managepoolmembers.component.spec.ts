import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagepoolmembersComponent } from './managepoolmembers.component';

describe('ManagepoolmembersComponent', () => {
  let component: ManagepoolmembersComponent;
  let fixture: ComponentFixture<ManagepoolmembersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManagepoolmembersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagepoolmembersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
