import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { EstudanteService } from '../../../servicos/estudante.service';
import { Estudante } from '../../../modelos/estudante';
import { LocalidadeService } from '../../../servicos/localidade.service';
import { Localidade } from '../../../modelos/localidade';
import { EstudanteLocalidade } from '../../../modelos/estudanteLocalidade';
import { EstudanteLocalidadeService } from '../../../servicos/estudanteLocalidade.service';
import { ValidationErrorHandlerService } from '../../../servicos/validationErrorHandler.service';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-criar-estudante',
  templateUrl: './criar.component.html',
  styleUrls: ['./criar.component.css']
})
export class CriarEstudanteComponent {
  novoEstudante: Estudante = {
    id: uuidv4(),
    nomeCompleto: '',
    dataNascimento: new Date(),
    localidade: {
      id: '',
      cidade: '',
      estado: '',
      logradouro: '',
      cep: '',
    }
  };
  novaLocalidade: Localidade = {
    id: uuidv4(),
    cidade: '',
    estado: '',
    logradouro: '',
    cep: ''
  };
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
  alertaSucesso: boolean = false;
  alertaErro: boolean = false;
  mensagemAlerta: string = '';

  opcaoLocalidade: 'criar' | 'utilizar' | 'semCadastro' = 'semCadastro';

  constructor(
    private estudanteService: EstudanteService,
    private estudanteLocalidadeService: EstudanteLocalidadeService,
    private localidadeService: LocalidadeService,
    private validationErrorHandlerService: ValidationErrorHandlerService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit (): void {
    this.localidadeService.listarLocalidades().subscribe(
      (data: Localidade[]) => {
        this.localidades = data;
      },
      (error) => {
        console.error(error);
        // Trate o erro de forma apropriada, como exibindo uma mensagem para o usuário.
      }
    );
  }

  fecharAlerta (tipo: string): void {
    if (tipo === 'sucesso') {
      this.alertaSucesso = false;
    } else if (tipo === 'erro') {
      this.alertaErro = false;
    }
  }

  criarEstudante (): void {
    if (this.opcaoLocalidade === 'criar') {
      this.novoEstudante.localidade = this.novaLocalidade;
    } else {
      this.novoEstudante.localidade = undefined;
    }
    this.estudanteService.salvarEstudante(this.novoEstudante).subscribe(() => {
      if (this.localidadeId && this.novoEstudante) {
        if (this.opcaoLocalidade === 'utilizar') {
          this.novoEstudanteLocalidade.localidadeId = this.localidadeId;
          this.novoEstudanteLocalidade.estudanteId = this.novoEstudante.id;
          this.estudanteLocalidadeService.salvarEstudanteLocalidade(this.novoEstudanteLocalidade).subscribe(() => {
            this.alertaSucesso = true;
            this.mensagemAlerta = 'Estudante criado com sucesso!';
            this.router.navigate(['/estudantes']);
          }, (erro) => {
            this.alertaErro = true;
            this.mensagemAlerta = 'Erro ao associar localidade ao estudante. Detalhes: ' + erro.message;
          });
        }
      }
      this.alertaSucesso = true;
      this.mensagemAlerta = 'Estudante criado com sucesso!';
      this.router.navigate(['/estudantes']);
    }, (erro) => {
      const validationErrors = this.validationErrorHandlerService.validationErrors(erro);
      this.alertaErro = true;
      this.mensagemAlerta = 'Erro ao criar estudante. Detalhes: ' + validationErrors.join(', ');
    });
  }
}
