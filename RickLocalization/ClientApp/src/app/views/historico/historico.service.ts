import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HistoricoModel } from '../../shared/models/historico.model';

@Injectable({
  providedIn: 'root'
})
export class HistoricoService {  

  constructor(private http: HttpClient) { }

  public historicoLista: HistoricoModel[];

  getHistorico(idPersonagem: number, nomeDimensao: string): Observable<HistoricoModel[]>  {
    
    const dados = this.http.get<HistoricoModel[]>(`http://localhost:5000/viagem?idPerson=${idPersonagem}&personagemDimensao1=${nomeDimensao}`, { params: {} , responseType: 'json' })

  //getHistorico(idPersonagem: number, nomeDimensao: string): Observable < HistoricoModel[] > {
  // const dados = this.http.get<HistoricoModel[]>('http://localhost:3000/viagens', { params: {}, responseType: 'json' })

    return dados;
  }


}
