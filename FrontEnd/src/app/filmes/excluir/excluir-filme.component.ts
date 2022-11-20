import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FilmeService } from '../services/filme.service';
import { VisualizarFilmeViewModel } from '../view-models/visualizar-filme.view-model';

@Component({
  selector: 'app-excluir-filme',
  templateUrl: './excluir-filme.component.html',
  styles: [
  ]
})
export class ExcluirFilmeComponent implements OnInit {

  public filmeFormVM: VisualizarFilmeViewModel = new VisualizarFilmeViewModel();

  constructor(
    titulo: Title,
    private route: ActivatedRoute,
    private router: Router,
    private filmeService: FilmeService,
    private toastr: ToastrService
  ) {
    titulo.setTitle('Excluir filme');
  }

  ngOnInit(): void {
    this.filmeFormVM = this.route.snapshot.data['filme'];

    this.toastr.toastrConfig.positionClass = 'toast-bottom-right';
  }

  public gravar() {
    this.filmeService.excluir(this.filmeFormVM.id)
      .subscribe({
        next: () => this.processarSucesso(),
        error: (erro) => this.processarFalha(erro)
      })
  }

  private processarSucesso(): void {
    this.router.navigate(['/filmes/listar']);
    this.toastr.success('Filme exlcuído com sucesso!', 'Excluir Filme');
  }

  private processarFalha(erro: any) {
    if (erro) {
      console.error(erro);
    }
    this.toastr.error(erro, 'Excluir Filme');
  }
}
