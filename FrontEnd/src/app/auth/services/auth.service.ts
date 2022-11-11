import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http"
import { catchError, map, Observable, throwError } from "rxjs";
import { environment } from "src/environments/environment";
import { TokenViewModel } from "../view-models/token.view-model";
import { AutenticarUsuarioViewModel } from "../view-models/autenticar-usuario.view-model";

@Injectable()
export class AuthService {

  private apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public login(usuario: AutenticarUsuarioViewModel): Observable<TokenViewModel> {
    const response = this.http
      .post(this.apiUrl + 'conta/autenticar', usuario, this.obterHeaderJson())
      .pipe(map(this.processarDados), catchError(this.processarFalha));

    return response;
  }

  public logout() {
    const resposta = this.http.post(this.apiUrl + 'conta/sair', this.obterHeaderJson());

    return resposta;
  }

  private processarDados(response: any) {
    if (response.sucesso) {
      return response.dados;
    }
  }

  private processarFalha(response: any) {
    return throwError(() => new Error(response.error.erros[0]));
  }

  private obterHeaderJson() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    }
  }
}
