import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { timeout } from 'rxjs';
import { SessaoService } from '../services/sessao.service';
import { TipoAnimacaoEnum } from '../view-models/forms-sessao.view-model';
import { VisualizarSessaoViewModel } from '../view-models/visualizar-sessao.view-model';

@Component({
  selector: 'app-visualizar-sessao',
  templateUrl: './visualizar-sessao.component.html',
  styles: [
  ]
})
export class VisualizarSessaoComponent implements OnInit {

  public sessaoFormVM: VisualizarSessaoViewModel = new VisualizarSessaoViewModel();

  constructor(
    titulo: Title,
    private route: ActivatedRoute,
    private router: Router,
    private sessaoService: SessaoService
  ) {
    titulo.setTitle('Visualizar sessão')
  }

  ngOnInit(): void {
    this.sessaoFormVM = this.route.snapshot.data['sessao'];
  }
}