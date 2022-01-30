import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeskmatComponent } from './deskmat.component';

describe('DeskmatComponent', () => {
  let component: DeskmatComponent;
  let fixture: ComponentFixture<DeskmatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeskmatComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeskmatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
