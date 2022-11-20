import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map, Observable, throwError } from "rxjs";
import { LocalStorageService } from "src/app/auth/services/local-storage.service";
import { environment } from "src/environments/environment";
import { FormsSessaoViewModel } from "../view-models/forms-sessao.view-model";
import { ListarSessaoViewModel } from "../view-models/listar-sessao.view-model";
import { VisualizarSessaoViewModel } from "../view-models/visualizar-sessao.view-model";

@Injectable()
export class SessaoService {

  private apiUrl: string = environment.apiUrl;

  constructor(
    private http: HttpClient,
    private localStorageService: LocalStorageService
  ) { }

  public selecionarTodos(): Observable<ListarSessaoViewModel[]> {
    const resposta = this.http
      .get<ListarSessaoViewModel[]>(this.apiUrl + 'sessoes', this.obterHeadersAutorizacao())
      .pipe(map(this.processarDados), catchError(this.processarFalha));

    return resposta
  }

  public inserir(sessao: FormsSessaoViewModel): Observable<FormsSessaoViewModel> {
    const resposta = this.http
      .post<FormsSessaoViewModel>(this.apiUrl + 'sessoes', sessao, this.obterHeadersAutorizacao())
      .pipe(map(this.processarDados), catchError(this.processarFalha));

    return resposta
  }

  public selecionarSessaoCompletaPorId(id: string): Observable<VisualizarSessaoViewModel> {
    const resposta = this.http
      .get<VisualizarSessaoViewModel>(this.apiUrl + 'sessoes/' + id, this.obterHeadersAutorizacao())
      .pipe(map(this.processarDados), catchError(this.processarFalha));

    return resposta;
  }

  public excluir(id: string): Observable<string> {

    const resposta = this.http
      .delete<string>(this.apiUrl + 'sessoes/' + id, this.obterHeadersAutorizacao())
      .pipe(map(this.processarDados), catchError(this.processarFalha));

    return resposta;
  }

  private processarDados(resposta: any) {
    if (resposta?.sucesso) {
      return resposta.dados;
    }

    else {
      return resposta;
    }
  }

  private processarFalha(resposta: any) {
    return throwError(() => new Error(resposta.error.erros[0]));
  }

  private obterHeadersAutorizacao() {
    const token = this.localStorageService.obterTokenUsuario();

    return {
      headers: new HttpHeaders({
        'Content-type': 'application/json',
        'Authorization': `Bearer ${token}`
      })
    }
  }
}
