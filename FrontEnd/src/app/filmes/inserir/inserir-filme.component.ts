import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FilmeService } from '../services/filme.service';
import { FormsFilmeViewModel } from '../view-models/forms-filme.view-model';

@Component({
  selector: 'app-inserir-filme',
  templateUrl: './inserir-filme.component.html',
  styles: [
  ]
})
export class InserirFilmeComponent implements OnInit {

  public formFilme: FormGroup;

  public imagemArquivo: any;

  public filmeFormVM: FormsFilmeViewModel = new FormsFilmeViewModel();

  constructor(
    titulo: Title,
    private formBuilder: FormBuilder,
    private filmeService: FilmeService,
    private router: Router,
    private toastr: ToastrService
  ) {
    titulo.setTitle('Inserir Filme');
  }

  ngOnInit(): void {

    this.formFilme = this.formBuilder.group({
      imagemInput: ['', [Validators.required]],
      titulo: ['', [Validators.required]],
      descricao: ['', [Validators.required]],
      duracao: ['', [Validators.required]],
    });
  }

  get imagemInput() {
    return this.formFilme.get('imagemInput');
  }

  get titulo() {
    return this.formFilme.get('titulo');
  }

  get descricao() {
    return this.formFilme.get('descricao');
  }

  get duracao() {
    return this.formFilme.get('duracao');
  }

  public imagemSelecionada(imageInput: HTMLInputElement) {

    const reader = new FileReader();
    const files = imageInput.files as FileList;

    reader.addEventListener('load', (event: any) => {

      var element = event.target as FileReader;

      this.imagemArquivo = element.result;

      this.filmeFormVM.imagem = this.imagemArquivo;
    });

    reader.readAsDataURL(files[0]);
  }

  public gravar() {

    if (this.formFilme.invalid) {
      this.toastr.toastrConfig.positionClass = 'toast-bottom-right';
      this.toastr.error('Os dados não estão corretamente preenchidos.', 'Erro ao cadastrar!');

      return;
    }

    this.filmeFormVM = Object.assign({}, this.filmeFormVM, this.formFilme.value);

    this.filmeService.inserir(this.filmeFormVM)
      .subscribe({
        next: (filmeInserido) => this.processarSucesso(filmeInserido),
        error: (erro) => this.processarFalha(erro)
      })
  }

  private processarSucesso(tarefa: FormsFilmeViewModel): void {
    this.router.navigate(['/filmes/listar']);
    this.toastr.success('Filme inserido com sucesso!', 'Inserir Filme');
  }

  private processarFalha(erro: any) {
    if (erro) {
      console.error(erro);
    }
  }
}
