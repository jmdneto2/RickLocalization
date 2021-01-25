import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { CardModel } from '.././shared/models/card.model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CardDeckService {

  constructor(private http: HttpClient) { }

  public cardsDisplayed: CardModel[];

  getCards(): Observable<CardModel[]> {
    const dados = this.http.get<CardModel[]>('http://localhost:3004/personagens', { params: {}, responseType: 'json' })//TODO: IMPLEMENTAR PARA PUXAR DA API.

    return dados; 

    
  }
}
