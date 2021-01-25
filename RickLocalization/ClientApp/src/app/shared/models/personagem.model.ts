import { CDK_CONNECTED_OVERLAY_SCROLL_STRATEGY_FACTORY } from "@angular/cdk/overlay/overlay-directives";
import { DimensaoModel } from "./dimensao.model";

export class PersonagemModel {
  personagemId: number;
  personagemNome: string;
  personagemDimensao: DimensaoModel;
  imagemPersonagem: string;
}


