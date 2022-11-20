import { TipoAnimacaoEnum, TipoAudioEnum } from "./forms-sessao.view-model";

export class VisualizarSessaoViewModel {
  id: string;
  data: Date;
  horarioInicio: string;
  valorIngresso: string;
  tipoAnimacao: TipoAnimacaoEnum;
  tipoAudio: TipoAudioEnum;
  filmeId: string;
  salaId: string;
  horarioFim: string;
  tituloFilme: string;
  nomeSala: string;
}
