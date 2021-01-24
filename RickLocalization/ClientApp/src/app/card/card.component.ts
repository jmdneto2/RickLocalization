import { Component, Input, OnInit } from '@angular/core';
import { CardModel } from '../shared/models/card.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit { 
  @Input() dataCard: CardModel;
  card: CardModel;

  constructor(private router: Router) {
    
  }

  ngOnInit(): void {
    this.card = this.dataCard;
    //console.log(this.card);
  }

  showHistorico(cardEscolhido): void {
    //console.log("Passou Aqui");
    this.router.navigate(['./historico'], { queryParams: { idPerson: this.card.personagemId1, personagemDimensao: this.card.personagemDimensao1}});
  }

  addViagem(): void {
    console.log("Passou Aqui");
  }

}
