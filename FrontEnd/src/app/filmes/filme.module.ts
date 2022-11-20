import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FilmeRoutingModule } from './filme-routing.module';
import { FilmeAppComponent } from './filme-app.component';
import { ListarFilmeComponent } from './listar/listar-filme.component';
import { FilmeService } from './services/filme.service';
import { InserirFilmeComponent } from './inserir/inserir-filme.component';
import { EditarFilmeComponent } from './editar/editar-filme.component';
import { ExcluirFilmeComponent } from './excluir/excluir-filme.component';
import { VisualizarFilmeResolver } from './services/visualizar-filme.resolver';
import { FormsFilmeResolver } from './services/forms-filme.resolver';
import { VisualizarFilmeComponent } from './visualizar/visualizar-filme.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    FilmeAppComponent,
    ListarFilmeComponent,
    InserirFilmeComponent,
    EditarFilmeComponent,
    ExcluirFilmeComponent,
    VisualizarFilmeComponent
  ],
  imports: [
    CommonModule,
    FilmeRoutingModule,
    ReactiveFormsModule
  ],
  providers: [
    FilmeService,
    VisualizarFilmeResolver,
    FormsFilmeResolver
  ]
})
export class FilmeModule { }
