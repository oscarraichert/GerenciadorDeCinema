import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditarFilmeComponent } from './editar/editar-filme.component';
import { ExcluirFilmeComponent } from './excluir/excluir-filme.component';
import { FilmeAppComponent } from './filme-app.component';
import { InserirFilmeComponent } from './inserir/inserir-filme.component';
import { ListarFilmeComponent } from './listar/listar-filme.component';
import { FormsFilmeResolver } from './services/forms-filme.resolver';
import { VisualizarFilmeResolver } from './services/visualizar-filme.resolver';
import { VisualizarFilmeComponent } from './visualizar/visualizar-filme.component';

const routes: Routes = [
  {
    path: '', component: FilmeAppComponent,
    children: [
      { path: '', redirectTo: 'listar', pathMatch: 'full' },
      { path: 'listar', component: ListarFilmeComponent },
      { path: 'inserir', component: InserirFilmeComponent },
      { path: 'excluir/:id', component: ExcluirFilmeComponent, resolve: { filme: VisualizarFilmeResolver } },
      { path: 'editar/:id', component: EditarFilmeComponent, resolve: { filme: FormsFilmeResolver } },
      { path: 'visualizar/:id', component: VisualizarFilmeComponent, resolve: { filme: VisualizarFilmeResolver } },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FilmeRoutingModule { }
