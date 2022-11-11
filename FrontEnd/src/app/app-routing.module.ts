import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { AuthGuard } from './auth/services/auth.guard';
import { LoginGuard } from './auth/services/login.guard';

const routes: Routes = [
  { path: '', redirectTo: 'conta/autenticar', pathMatch: 'full' },
  { path: 'conta/autenticar', component: LoginComponent, canActivate: [LoginGuard] },
  { path: 'filmes', loadChildren: () => import('./filmes/filme.module').then(m => m.FilmeModule), canActivate: [AuthGuard] },
  { path: 'sessoes', loadChildren: () => import('./sessoes/sessao.module').then(m => m.SessaoModule), canActivate: [AuthGuard] },
  { path: 'salas', loadChildren: () => import('./salas/sala.module').then(m => m.SalaModule), canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
