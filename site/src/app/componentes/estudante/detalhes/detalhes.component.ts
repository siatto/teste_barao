import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EstudanteService } from '../../../servicos/estudante.service';
import { Estudante } from '../../../modelos/estudante';
import { EstudanteLocalidadeService } from '../../../servicos/estudanteLocalidade.service';
import { EstudanteLocalidade } from '../../../modelos/estudanteLocalidade';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
  styleUrls: ['./detalhes.component.css']
})
export class DetalhesEstudanteComponent implements OnInit {
  estudante: Estudante | undefined;
  estudanteLocalidade: EstudanteLocalidade | undefined;

  alertaSucesso: boolean = false;
  alertaErro: boolean = false;
  mensagemAlerta: string = '';

  constructor(
    private estudanteService: EstudanteService,
    private estudanteLocalidadeService: EstudanteLocalidadeService,
    private route: ActivatedRoute) { }

  ngOnInit (): void {
    this.carregarDetalhesEstudante();
  }

  fecharAlerta (tipo: string): void {
    if (tipo === 'sucesso') {
      this.alertaSucesso = false;
    } else if (tipo === 'erro') {
      this.alertaErro = false;
    }
  }

  carregarDetalhesEstudante () {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.estudanteService.obterEstudanteById(id).subscribe(
        (data: Estudante) => {
          this.estudante = data;
          this.estudanteLocalidadeService.obterEstudanteLocalidadePorEstudante(id).subscribe(
            (localidadeData: EstudanteLocalidade) => {
              this.estudanteLocalidade = localidadeData;

            },
            (error) => {
              this.alertaErro = true;
              this.mensagemAlerta = 'Erro ao obter (estudante x localidade) por estudante. Detalhes: ' + error.message;
            }
          );
        },
        (error) => {
          this.alertaErro = true;
          this.mensagemAlerta = 'Erro ao obter estudante. Detalhes: ' + error.message;
        }
      );
    }
  }

  excluirEstudanteLocalidade () {
    if (this.estudanteLocalidade && this.estudanteLocalidade.id) {
      this.estudanteLocalidadeService.excluirEstudanteLocalidade(this.estudanteLocalidade.id).subscribe(
        () => {
          this.alertaSucesso = true;
          this.mensagemAlerta = 'Estudante localidade excluído com sucesso.';
          this.carregarDetalhesEstudante();
        },
        (error) => {
          this.alertaErro = true;
          this.mensagemAlerta = 'Erro ao excluir Estudante Localidade. Detalhes: ' + error.message;
        }
      );
    }
  }
}
