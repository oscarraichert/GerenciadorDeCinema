import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { Observable } from "rxjs";
import { VisualizarFilmeViewModel } from "../view-models/visualizar-filme.view-model";
import { FilmeService } from "./filme.service";

@Injectable()
export class VisualizarFilmeResolver implements Resolve<VisualizarFilmeViewModel> {

  constructor(
    private filmeService: FilmeService
  ) { }

  resolve(route: ActivatedRouteSnapshot): Observable<VisualizarFilmeViewModel> {
    return this.filmeService.selecionarFilmeCompletoPorId(route.params['id']);
  }
}
