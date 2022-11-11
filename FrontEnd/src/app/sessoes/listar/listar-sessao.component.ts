import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { map, Observable, toArray } from 'rxjs';
import { FilmeService } from 'src/app/filmes/services/filme.service';
import { ListarFilmeViewModel } from 'src/app/filmes/view-models/listar-filme.view-model';
import { VisualizarFilmeViewModel } from 'src/app/filmes/view-models/visualizar-filme.view-model';
import { SessaoService } from '../services/sessao.service';
import { ListarSessaoViewModel } from '../view-models/listar-sessao.view-model';

@Component({
  selector: 'app-listar-sessao',
  templateUrl: './listar-sessao.component.html',
  styles: [
  ]
})
export class ListarSessaoComponent implements OnInit {

  public sessoes$: Observable<ListarSessaoViewModel[]>;

  constructor(
    titulo: Title,
    private sessaoService: SessaoService
  ) {
    titulo.setTitle('Sessões');
  }

  ngOnInit(): void {
    this.sessoes$ = this.sessaoService.selecionarTodos();
  }
}
