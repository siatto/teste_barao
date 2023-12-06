import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LocalidadeService } from '../../../servicos/localidade.service';
import { Localidade } from '../../../modelos/localidade';
import { ValidationErrorHandlerService } from '../../../servicos/validationErrorHandler.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarLocalidadeComponent implements OnInit {
  localidade: Localidade | undefined;

  alertaSucesso: boolean = false;
  alertaErro: boolean = false;
  mensagemAlerta: string = '';

  constructor(
    private localidadeService: LocalidadeService,
    private validationErrorHandlerService: ValidationErrorHandlerService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

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

  atualizarLocalidade (): void {
    if (this.localidade) {
      this.localidadeService.atualizarLocalidade(this.localidade).subscribe(() => {
        this.router.navigate(['/localidades']);
      },
        (error) => {
          const validationErrors = this.validationErrorHandlerService.validationErrors(error);
          this.alertaErro = true;
          this.mensagemAlerta = 'Erro ao salvar localidade. Detalhes: ' + validationErrors.join(', ');
        });
    }
  }
}

function uuidv4 (): string {
  throw new Error('Function not implemented.');
}
