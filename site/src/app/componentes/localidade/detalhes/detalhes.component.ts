import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LocalidadeService } from '../../../servicos/localidade.service';
import { Localidade } from '../../../modelos/localidade';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
  styleUrls: ['./detalhes.component.css']
})
export class DetalhesLocalidadeComponent implements OnInit {
  localidade: Localidade | undefined;

  alertaSucesso: boolean = false;
  alertaErro: boolean = false;
  mensagemAlerta: string = '';

  constructor(private localidadeService: LocalidadeService, private route: ActivatedRoute) { }

  ngOnInit (): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.localidadeService.obterLocalidadePorId(id).subscribe(
        (data: Localidade) => {
          this.localidade = data;
        },
        (error) => {
          this.alertaErro = true;
          this.mensagemAlerta = 'Erro ao obter localidade. Detalhes: ' + error.message;
        }
      );
    }
  }

  fecharAlerta (tipo: string): void {
    if (tipo === 'sucesso') {
      this.alertaSucesso = false;
    } else if (tipo === 'erro') {
      this.alertaErro = false;
    }
  }
}
