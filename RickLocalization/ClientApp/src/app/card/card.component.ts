import { Component, Input, OnInit } from '@angular/core';
import { CardModel } from '../shared/models/card.model';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit { 
  @Input() dataCard: CardModel;
  card: CardModel;

  constructor() {
    
  }

  ngOnInit(): void {
    this.card = this.dataCard;
    //console.log(this.card);
  }

  showHistorico(): void {
    console.log("Passou Aqui");
  }

  addViagem(): void {
    console.log("Passou Aqui");
  }

}
