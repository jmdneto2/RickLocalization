import { DimensaoModel } from "./dimensao.model";
import { PersonagemModel } from "./personagem.model";

export class HistoricoModel {
  viagemId: number;
  personagem: PersonagemModel;  
  origem: DimensaoModel;  
  destinoId: DimensaoModel;
  data: Date;
}

//export class HistoricoModel {
//  viagemId: number;
//  personagemId: number;
//  personagemNome: string;
//  personagemDimensao: string;
//  origemId: number;
//  origemNome: string;
//  destinoId: number;
//  destinoNome: string
//  data: Date;
//}
