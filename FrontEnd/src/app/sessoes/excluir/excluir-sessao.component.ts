import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SessaoService } from '../services/sessao.service';
import { TipoAnimacaoEnum, TipoAudioEnum } from '../view-models/forms-sessao.view-model';
import { VisualizarSessaoViewModel } from '../view-models/visualizar-sessao.view-model';

@Component({
  selector: 'app-excluir-sessao',
  templateUrl: './excluir-sessao.component.html',
  styles: [
  ]
})
export class ExcluirSessaoComponent implements OnInit {

  public sessaoFormVM: VisualizarSessaoViewModel = new VisualizarSessaoViewModel();

  public tipoAnimacaoEnum = Object.values(TipoAnimacaoEnum);

  public tipoAudioEnum = Object.values(TipoAudioEnum);

  constructor(
    titulo: Title,
    private route: ActivatedRoute,
    private router: Router,
    private sessaoService: SessaoService,
    private toastr: ToastrService
  ) {
    titulo.setTitle('Excluir sessão')
  }

  ngOnInit(): void {
    this.sessaoFormVM = this.route.snapshot.data['sessao'];
  }

  public gravar() {

    this.sessaoService.excluir(this.sessaoFormVM.id)
      .subscribe({
        next: () => this.processarSucesso(),
        error: (erro) => this.processarFalha(erro)
      })
  }

  private processarSucesso(): void {
    this.router.navigate(['/sessoes/listar']);
    this.toastr.success('Sessão exlcuída com sucesso!', 'Excluir Sessão');
  }

  private processarFalha(erro: any) {
    if (erro) {
      console.error(erro);
    }
    this.toastr.error(erro, 'Erro');
  }
}
