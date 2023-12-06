import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LocalidadeService } from '../../../servicos/localidade.service';
import { Localidade } from '../../../modelos/localidade';
import { ValidationErrorHandlerService } from '../../../servicos/validationErrorHandler.service';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-criar-localidade',
  templateUrl: './criar.component.html',
  styleUrls: ['./criar.component.css']
})
export class CriarLocalidadeComponent {
  novaLocalidade: Localidade = {
    id: uuidv4(),
    cidade: '',
    estado: '',
    logradouro: '',
    cep: ''
  };
  alertaSucesso: boolean = false;
  alertaErro: boolean = false;
  mensagemAlerta: string = '';

  constructor(
    private localidadeService: LocalidadeService,
    private validationErrorHandlerService: ValidationErrorHandlerService,
    private router: Router
  ) { }

  fecharAlerta (tipo: string): void {
    if (tipo === 'sucesso') {
      this.alertaSucesso = false;
    } else if (tipo === 'erro') {
      this.alertaErro = false;
    }
  }

  criarLocalidade (): void {
    this.localidadeService.salvarLocalidade(this.novaLocalidade).subscribe(() => {
      this.router.navigate(['/localidades']);
    },
      (error) => {
        const validationErrors = this.validationErrorHandlerService.validationErrors(error);
        this.alertaErro = true;
        this.mensagemAlerta = 'Erro ao salvar localidade. Detalhes: ' + validationErrors.join(', ');
      });
  }
}
