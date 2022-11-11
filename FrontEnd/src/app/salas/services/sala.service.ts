import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map, Observable, throwError } from "rxjs";
import { environment } from "src/environments/environment";
import { ListarSalaViewModel } from "../view-models/listar-sala.view-model";

@Injectable()
export class SalaService {

  private apiUrl: string = environment.apiUrl;

  constructor(
    private http: HttpClient
  ) { }

  public selecionarTodos(): Observable<ListarSalaViewModel[]> {

    const resposta = this.http
      .get<ListarSalaViewModel[]>(this.apiUrl + 'salas')
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
}
