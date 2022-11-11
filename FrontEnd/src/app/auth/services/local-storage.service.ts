import { Injectable } from "@angular/core";
import { TokenViewModel, UsuarioTokenViewModel } from "../view-models/token.view-model";

@Injectable()
export class LocalStorageService {

  public salvarDadosLocaisUsuario(resposta: TokenViewModel): void {
    this.salvarTokenUsuario(resposta.chave);
    this.salvarUsuario(resposta.usuarioToken);
  }

  public salvarTokenUsuario(token: string) {
    localStorage.setItem('GerenciadorDeCinema.token', token);
  }

  public salvarUsuario(usuario: UsuarioTokenViewModel) {
    const jsonString = JSON.stringify(usuario);

    localStorage.setItem('GerenciadorDeCinema.usuario', jsonString);
  }

  public obterUsuarioLogado() {
    const usuarioJson = localStorage.getItem('GerenciadorDeCinema.usuario');

    if (usuarioJson) {
      return JSON.parse(usuarioJson) as UsuarioTokenViewModel;
    }

    return null;
  }

  public obterTokenUsuario(): string {
    return localStorage.getItem('GerenciadorDeCinema.token') ?? '';
  }

  public limparDadosLocais() {
    localStorage.removeItem('GerenciadorDeCinema.token');
    localStorage.removeItem('GerenciadorDeCinema.usuario');
  }
}
