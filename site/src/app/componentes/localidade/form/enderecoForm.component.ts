import { Component, Input } from '@angular/core';

import { LocalidadeService } from '../../../servicos/localidade.service';

@Component({
  selector: 'app-endereco-form',
  templateUrl: './enderecoForm.component.html',
  styleUrls: ['./enderecoForm.component.css']
})
export class EnderecoFormComponent {
  @Input() endereco: any;

  alertaSucesso: boolean = false;
  alertaErro: boolean = false;
  mensagemAlerta: string = '';

  constructor(
    private localidadeService: LocalidadeService) { }

  buscarDetalhesCEP (): void {
    const cep = this.endereco.cep.replace(/\D/g, '');
    if (cep.length === 8) {
      this.localidadeService.obterDetalhesCEP(cep).subscribe(
        (detalhes: any) => {
          this.endereco.logradouro = detalhes.logradouro;
          this.endereco.cidade = detalhes.localidade;
          this.endereco.estado = detalhes.uf;
        },
        (error) => {
          this.alertaErro = true;
          this.mensagemAlerta = 'Erro ao buscar CEP. Detalhes: ' + error.message;
        }
      );
    }
  }
}
