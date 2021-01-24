import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CardModel } from '../shared/models/card.model';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  dadosCardSelecionado: CardModel
  dimensaoEscolhida: number;

  constructor(private _http: HttpClient) { }

  postJSON(dados: CardModel, dimensao: number) {
    this.dadosCardSelecionado = dados;
    this.dimensaoEscolhida = dimensao;

    //var json = JSON.stringify(form.value);
    let json = JSON.stringify({
      id:1,
      personagemId: this.dadosCardSelecionado.personagemId1,
      personagemDimensao: this.dadosCardSelecionado.personagemDimensaoId1,
      origemId: this.dadosCardSelecionado.personagemDimensaoId1,
      destinoId: this.dimensaoEscolhida
    });
    //let json = JSON.stringify({ ClienteId: 1, Nome: "teste", Email: "teste2", Celular1: "11232323", Celular2: "113333333" });
    let params = json;
    //var cabe = new Headers();
    //cabe.append('Content-Type', 'application/json');

    this._http.post('http://localhost:3005/postViagens',      
      {
        params
      })
      .subscribe(
        (val) => {
          console.log("POST call successful value returned in body",
            val);
        },
        response => {
          console.log("POST call in error", response);
        },
        () => {
          console.log("The POST observable is now completed.");
        });

  }
}
