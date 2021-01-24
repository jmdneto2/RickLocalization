import { Component, Input, OnInit } from '@angular/core';
import { CardModel } from '../../shared/models/card.model';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { HistoricoService } from './historico.service';
import { HistoricoModel } from '../../shared/models/historico.model';
import { DataSource } from '@angular/cdk/table';

@Component({
  selector: 'app-historico',
  templateUrl: './historico.component.html',
  styleUrls: ['./historico.component.css']
})
export class HistoricoComponent{
  public historicoLista: HistoricoModel[];

  displayedColumns: string[] = ['viagemId', 'personagemNome', 'personagemDimensao','origemNome', 'destinoNome','data'];
  dataSource: any;
  nomeDimensao: string;

  constructor(private activatedRoute: ActivatedRoute,
              private historicoService: HistoricoService) { }

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(params => {
      const idPersonagem = params['idPerson'];
      const nomeDimensao = params['personagemDimensao1'];      
      //console.log(idPersonagem);
      //console.log(nomeDimensao);

      this.getHistorico(idPersonagem, nomeDimensao)    

    });
  }

  getHistorico(idPersonagem: number, nomeDimensao: string) {
    this.nomeDimensao = nomeDimensao;
    this.historicoService.getHistorico(idPersonagem, nomeDimensao)
      .subscribe(
        ((data: HistoricoModel[]) => {          
          this.historicoLista = data;
          this.dataSource = this.historicoLista;
          //let x = this.historicoLista.length;
        })
      );
  }

}
