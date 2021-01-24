import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardModel } from './card.model';

describe('Card.ModelComponent', () => {
  let component: CardModel;
  let fixture: ComponentFixture<CardModel>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardModel ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardModel);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
