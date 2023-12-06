import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EstudanteService } from '../../../servicos/estudante.service';
import { Estudante } from '../../../modelos/estudante';
import { LocalidadeService } from '../../../servicos/localidade.service';
import { Localidade } from '../../../modelos/localidade';
import { EstudanteLocalidade } from '../../../modelos/estudanteLocalidade';
import { EstudanteLocalidadeService } from '../../../servicos/estudanteLocalidade.service';
import { ValidationErrorHandlerService } from '../../../servicos/validationErrorHandler.service';
import { Router } from '@angular/router';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarEstudanteComponent implements OnInit {
  estudante: Estudante | undefined;
  dataNascimento: string | undefined;
  localidades: Localidade[] = [];
  localidadeId: string | undefined;
  novoEstudanteLocalidade: EstudanteLocalidade = {
    id: uuidv4(),
    estudanteId: '',
    estudante: {
      id: '',
      nomeCompleto: '',
      dataNascimento: new Date(),
    },
    localidadeId: '',
    localidade: {
      id: '',
      cidade: '',
      estado: '',
      logradouro: '',
      cep: '',
    }
  };
  localidadesFiltradas: Localidade[] = [];
  termoPesquisa: string = '';
  alertaSucesso: boolean = false;
  alertaErro: boolean = false;
  mensagemAlerta: string = '';

  constructor(
    private estudanteService: EstudanteService,
    private estudanteLocalidadeService: EstudanteLocalidadeService,
    private localidadeService: LocalidadeService,
    private validationErrorHandlerService: ValidationErrorHandlerService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit (): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.estudanteService.obterEstudanteById(id).subscribe(
        (data: Estudante) => {
          this.estudante = data;
          this.estudanteLocalidadeService.obterEstudanteLocalidadePorEstudante(id).subscribe(
            (data: EstudanteLocalidade) => {
              if (data) {
                this.localidadeId = data.localidadeId;
              }
            },
            (error) => {
              console.error(error);
            }
          );
        },
        (error) => {
          console.error(error);
        }
      );
      this.localidadeService.listarLocalidades().subscribe(
        (data: Localidade[]) => {
          this.localidades = data;
        },
        (error) => {
          console.error(error);
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

  atualizarEstudante (): void {
    if (this.estudante) {
      this.estudanteService.atualizarEstudante(this.estudante).subscribe(() => {
        if (this.localidadeId && this.estudante) {
          this.novoEstudanteLocalidade.localidadeId = this.localidadeId;
          this.novoEstudanteLocalidade.estudanteId = this.estudante.id;
          this.estudanteLocalidadeService.salvarEstudanteLocalidade(this.novoEstudanteLocalidade).subscribe(() => {
            this.router.navigate(['/estudantes']);
          },
            (error) => {
              this.alertaErro = true;
              this.mensagemAlerta = 'Erro ao salvar (estudante x localidade). Detalhes: ' + error.message;
            });
        }
        this.router.navigate(['/estudantes']);
      },
        (error) => {
          const validationErrors = this.validationErrorHandlerService.validationErrors(error);
          this.alertaErro = true;
          this.mensagemAlerta = 'Erro ao atualizar estudante. Detalhes: ' + validationErrors.join(', ');
        });
    }
  }
}
