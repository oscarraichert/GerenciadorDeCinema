import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExcluirSessaoComponent } from './excluir/excluir-sessao.component';
import { InserirSessaoComponent } from './inserir/inserir-sessao.component';
import { ListarSessaoComponent } from './listar/listar-sessao.component';
import { VisualizarSessaoResolver } from './services/visualizar-sessao.resolver';
import { SessaoAppComponent } from './sessao-app.component';
import { VisualizarSessaoComponent } from './visualizar/visualizar-sessao.component';

const routes: Routes = [
  {
    path: '', component: SessaoAppComponent,
    children: [
      { path: '', redirectTo: 'listar', pathMatch: 'full' },
      { path: 'listar', component: ListarSessaoComponent },
      { path: 'excluir/:id', component: ExcluirSessaoComponent, resolve: { sessao: VisualizarSessaoResolver } },
      { path: 'visualizar/:id', component: VisualizarSessaoComponent, resolve: { sessao: VisualizarSessaoResolver } },
      { path: 'inserir', component: InserirSessaoComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SessaoRoutingModule { }
