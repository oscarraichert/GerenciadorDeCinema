import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { VisualizarFilmeViewModel } from '../view-models/visualizar-filme.view-model';

@Component({
  selector: 'app-visualizar-filme',
  templateUrl: './visualizar-filme.component.html',
  styles: [
  ]
})
export class VisualizarFilmeComponent implements OnInit {

  public filmeFormVM: VisualizarFilmeViewModel = new VisualizarFilmeViewModel();

  constructor(
    titulo: Title,
    private route: ActivatedRoute,
    private router: Router
  ) {
  }

  ngOnInit(): void {
    this.filmeFormVM = this.route.snapshot.data['filme'];
  }
}
