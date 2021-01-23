import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
//import 'rxjs/add/operator/map';
//import { Observable } from "rxjs/Observable";

import { CardModel } from '.././shared/models/card.model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CardDeckService {

  constructor(private http: HttpClient) { }

  public cardsDisplayed: CardModel[];

  getCards(): Observable<CardModel[]> {
    const dados = this.http.get<CardModel[]>('http://localhost:3004/personagens', { params: {}, responseType: 'json' })

    return dados;
  

    // 'http://localhost:5000/api/cliente/',

    //{observe:'response'}

    //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //  http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
    //    this.forecasts = result;
    //  }, error => console.error(error));
    //}

    
  }
}
