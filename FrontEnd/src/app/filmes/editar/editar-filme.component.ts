import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FilmeService } from '../services/filme.service';
import { FormsFilmeViewModel } from '../view-models/forms-filme.view-model';

@Component({
  selector: 'app-editar-filme',
  templateUrl: './editar-filme.component.html',
  styles: [
  ]
})
export class EditarFilmeComponent implements OnInit {

  public formFilme: FormGroup;

  public imagemArquivo: any;

  public filmeFormVM: FormsFilmeViewModel = new FormsFilmeViewModel();

  constructor(
    titulo: Title,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private filmeService: FilmeService,
    private toastr: ToastrService
  ) {
    titulo.setTitle('Editar Filme')
  }

  ngOnInit(): void {
    this.filmeFormVM = this.route.snapshot.data['filme'];

    this.formFilme = this.formBuilder.group({
      imagemInput: ['', [Validators.required]],
      titulo: ['', [Validators.required]],
      descricao: ['', [Validators.required]],
      duracao: ['', [Validators.required]],
    });

    this.formFilme.patchValue({
      id: this.filmeFormVM.id,
      imagem: this.filmeFormVM.imagem,
      titulo: this.filmeFormVM.titulo,
      descricao: this.filmeFormVM.descricao,
      duracao: this.filmeFormVM.duracao
    })
  }

  get imagem() {
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
      this.toastr.error('Os dados  não estão corretamente preenchidos.', 'Erro ao editar!');

      return;
    }

    this.filmeFormVM = Object.assign({}, this.filmeFormVM, this.formFilme.value);

    this.filmeService.editar(this.filmeFormVM)
      .subscribe({
        next: (filmeEditado) => this.processarSucesso(filmeEditado),
        error: (erro) => this.processarFalha(erro)
      })
  }

  private processarSucesso(tarefa: FormsFilmeViewModel): void {
    this.router.navigate(['/filmes/listar']);
    this.toastr.success('Filme editado com sucesso', 'Editar Filme');
  }

  private processarFalha(erro: any) {
    if (erro) {
      console.error(erro);
    }
  }
}
