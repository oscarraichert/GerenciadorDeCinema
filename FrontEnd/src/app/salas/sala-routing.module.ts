import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarSalaComponent } from './listar/listar-sala.component';
import { SalaAppComponent } from './sala-app.component';

const routes: Routes = [
  {
    path: '', component: SalaAppComponent,
    children: [
      { path: '', redirectTo: 'listar', pathMatch: 'full' },
      { path: 'listar', component: ListarSalaComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SalaRoutingModule { }
