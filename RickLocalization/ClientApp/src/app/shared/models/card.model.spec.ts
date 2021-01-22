import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Card.ModelComponent } from './card.model.component';

describe('Card.ModelComponent', () => {
  let component: Card.ModelComponent;
  let fixture: ComponentFixture<Card.ModelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Card.ModelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Card.ModelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
