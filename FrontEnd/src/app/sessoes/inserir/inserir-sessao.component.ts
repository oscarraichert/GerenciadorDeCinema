import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { FilmeService } from 'src/app/filmes/services/filme.service';
import { ListarFilmeViewModel } from 'src/app/filmes/view-models/listar-filme.view-model';
import { SalaService } from 'src/app/salas/services/sala.service';
import { ListarSalaViewModel } from 'src/app/salas/view-models/listar-sala.view-model';
import { environment } from 'src/environments/environment';
import { SessaoService } from '../services/sessao.service';
import { FormsSessaoViewModel, TipoAnimacaoEnum, TipoAudioEnum } from '../view-models/forms-sessao.view-model';

@Component({
  selector: 'app-inserir-sessao',
  templateUrl: './inserir-sessao.component.html',
  styles: [
  ]
})
export class InserirSessaoComponent implements OnInit {

  public formSessao: FormGroup;
  public tipoAnimacaoEnum = Object.values(TipoAnimacaoEnum).filter(v => !Number.isFinite(v));
  public tipoAudioEnum = Object.values(TipoAudioEnum).filter(v => !Number.isFinite(v));

  public filmes: ListarFilmeViewModel[] = [];

  public salas: ListarSalaViewModel[] = [];

  public sessaoFormVM: FormsSessaoViewModel = new FormsSessaoViewModel();

  constructor(
    titulo: Title,
    private formBuilder: FormBuilder,
    private sessaoService: SessaoService,
    private filmeService: FilmeService,
    private salaService: SalaService,
    private router: Router,
    private toastr: ToastrService

  ) {
    titulo.setTitle('Inserir Sessão');
  }

  ngOnInit(): void {

    this.toastr.toastrConfig.positionClass = "toast-bottom-right";

    this.obterSalas();

    this.obterFilmes();

    this.formSessao = this.formBuilder.group({
      data: ['', [Validators.required]],
      horarioInicio: ['', [Validators.required]],
      valorIngresso: ['', [Validators.required]],
      tipoAnimacao: ['', [Validators.required]],
      tipoAudio: ['', [Validators.required]],
      filmeId: ['', [Validators.required]],
      salaId: ['', [Validators.required]],
    })
  }

  get data() {
    return this.formSessao.get('data')
  }

  get horarioInicio() {
    return this.formSessao.get('horarioInicio')
  }

  get valorIngresso() {
    return this.formSessao.get('valorIngresso')
  }

  get tipoAnimacao() {
    return this.formSessao.get('tipoAnimacao')
  }

  get tipoAudio() {
    return this.formSessao.get('tipoAudio')
  }

  get filmeId() {
    return this.formSessao.get('filmeId')
  }

  get salaId() {
    return this.formSessao.get('salaId')
  }

  public obterSalas() {

    var salas$ = this.salaService.selecionarTodos();

    salas$.forEach(a => {
      a.forEach(s => {
        this.salas.push(s);
      })
    });
  }

  public obterFilmes() {

    var filmes$ = this.filmeService.selecionarTodos();

    filmes$.forEach(a => {
      a.forEach(f => {
        this.filmes.push(f);
      })
    });
  }

  public gravar() {

    if (this.formSessao.invalid) {
      this.toastr.error('Os dados não estão corretamente preenchidos.', 'Erro ao cadastrar!');
      return;
    }

    this.sessaoFormVM = Object.assign({}, this.sessaoFormVM, this.formSessao.value);

    this.sessaoService.inserir(this.sessaoFormVM)
      .subscribe({
        next: (sessaoInserida) => this.processarSucesso(sessaoInserida),
        error: (erro) => this.processarFalha(erro)
      });
  }

  private processarSucesso(sessao: FormsSessaoViewModel): void {
    this.router.navigate(['/sessoes/listar']);
    this.toastr.success('Sessão inserida com sucesso!', 'Inserir Sessão');
  }

  private processarFalha(erro: any) {
    if (erro) {
      console.error(erro);
    }
    this.toastr.error(erro, 'Erro');
  }
}
