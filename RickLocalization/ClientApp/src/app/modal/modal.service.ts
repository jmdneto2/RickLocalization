import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CardModel } from '../shared/models/card.model';
import { DimensaoModel } from '../shared/models/dimensao.model';
import { PersonagemModel } from '../shared/models/personagem.model';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  dadosCardSelecionado: CardModel
  dimensaoEscolhidaId: number;

  constructor(private _http: HttpClient) { }

  postJSON(dados: CardModel, dimensao: number) {
    this.dadosCardSelecionado = dados;
    this.dimensaoEscolhidaId = dimensao;    

    const json = JSON.stringify({
      id: 0,
      personagem: this.dadosCardSelecionado.personagem1Id,      
      origemId: this.dadosCardSelecionado.personagem1Dimensao.dimensaoId,
      destinoId: this.dimensaoEscolhidaId
    });

    let body = json;
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    this._http.post('http://localhost:5000/viagem', body,
      //this._http.post('http://localhost:3005/postViagens', body,      
      {
       headers: headers
      })
      .subscribe(
        (val) => {
          console.log("POST Response Ok!",
            val);
        },
        response => {
          console.log("POST error", response);
        },
        () => {
          console.log("The POST observable completed.");
        });

  }
}
