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
  "2D" = 0,
  "3D" = 1
}

export enum TipoAudioEnum {
  Original = 0,
  Dublado = 1
}
