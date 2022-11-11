import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SessaoRoutingModule } from './sessao-routing.module';
import { SessaoAppComponent } from './sessao-app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ListarSessaoComponent } from './listar/listar-sessao.component';
import { SessaoService } from './services/sessao.service';
import { FilmeService } from '../filmes/services/filme.service';
import { ExcluirSessaoComponent } from './excluir/excluir-sessao.component';
import { VisualizarSessaoResolver } from './services/visualizar-sessao.resolver';
import { VisualizarSessaoComponent } from './visualizar/visualizar-sessao.component';
import { InserirSessaoComponent } from './inserir/inserir-sessao.component';
import { NgSelectModule } from '@ng-select/ng-select';
import { SalaService } from '../salas/services/sala.service';


@NgModule({
  declarations: [
    SessaoAppComponent,
    ListarSessaoComponent,
    ExcluirSessaoComponent,
    VisualizarSessaoComponent,
    InserirSessaoComponent
  ],
  imports: [
    CommonModule,
    SessaoRoutingModule,
    NgSelectModule,
    ReactiveFormsModule,
  ],
  providers: [
    SessaoService,
    FilmeService,
    VisualizarSessaoResolver,
    SalaService
  ]
})
export class SessaoModule { }
