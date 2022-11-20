export class FormsSessaoViewModel {
  id: string;
  data: Date;
  horarioInicio: string;
  valorIngresso: string;
  tipoAnimacao: TipoAnimacaoEnum;
  tipoAudio: TipoAudioEnum;
  filmeId: string;
  salaId: string;
}

export enum TipoAnimacaoEnum {
  "2D",
  "3D"
}

export enum TipoAudioEnum {
  Original = 0,
  Dublado = 1
}
