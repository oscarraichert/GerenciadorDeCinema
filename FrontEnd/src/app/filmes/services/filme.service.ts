import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map, Observable, throwError } from "rxjs";
import { LocalStorageService } from "src/app/auth/services/local-storage.service";
import { environment } from "src/environments/environment";
import { FormsFilmeViewModel } from "../view-models/forms-filme.view-model";
import { ListarFilmeViewModel } from "../view-models/listar-filme.view-model";
import { VisualizarFilmeViewModel } from "../view-models/visualizar-filme.view-model";

@Injectable()
export class FilmeService {

  private apiUrl: string = environment.apiUrl;

  constructor(
    private http: HttpClient,
    private localStorageService: LocalStorageService
  ) { }

  public selecionarTodos(): Observable<ListarFilmeViewModel[]> {
    const resposta = this.http
      .get<ListarFilmeViewModel[]>(this.apiUrl + 'filmes', this.obterHeadersAutorizacao())
      .pipe(map(this.processarDados), catchError(this.processarFalha));

    return resposta
  }

  public inserir(filme: FormsFilmeViewModel): Observable<FormsFilmeViewModel> {
    const resposta = this.http
      .post<FormsFilmeViewModel>(this.apiUrl + 'filmes', filme, this.obterHeadersAutorizacao())
      .pipe(map(this.processarDados), catchError(this.processarFalha));

    return resposta
  }

  public editar(filme: FormsFilmeViewModel): Observable<FormsFilmeViewModel> {
    const resposta = this.http
      .put<FormsFilmeViewModel>(this.apiUrl + 'filmes/' + filme.id, filme, this.obterHeadersAutorizacao())
      .pipe(map(this.processarDados), catchError(this.processarFalha));

    return resposta;
  }

  public excluir(id: string): Observable<string> {
    const resposta = this.http
      .delete<string>(this.apiUrl + 'filmes/' + id, this.obterHeadersAutorizacao())
      .pipe(map(this.processarDados), catchError(this.processarFalha));

    return resposta;
  }

  public selecionarFilmeCompletoPorId(id: string): Observable<VisualizarFilmeViewModel> {
    const resposta = this.http
      .get<VisualizarFilmeViewModel>(this.apiUrl + 'filmes/' + id, this.obterHeadersAutorizacao())
      .pipe(map(this.processarDados), catchError(this.processarFalha));

    return resposta
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
