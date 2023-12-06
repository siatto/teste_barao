import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalidadeService } from '../../../servicos/localidade.service';
import { Localidade } from '../../../modelos/localidade';
import { AuthService } from '../../../servicos/auth.service';

@Component({
  selector: 'app-lista-localidade',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.css']
})
export class ListaLocalidadeComponent implements OnInit {
  localidades: Localidade[] = [];
  localidadesFiltrados: Localidade[] = [];
  filtroLogradouro: string = '';
  alertaSucesso: boolean = false;
  alertaErro: boolean = false;
  mensagemAlerta: string = '';

  constructor(private localidadeService: LocalidadeService, private router: Router, private authService: AuthService) { }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  ngOnInit (): void {
    this.carregarLocalidades();
  }

  fecharAlerta (tipo: string): void {
    if (tipo === 'sucesso') {
      this.alertaSucesso = false;
    } else if (tipo === 'erro') {
      this.alertaErro = false;
    }
  }

  carregarLocalidades (): void {
    this.localidadeService.listarLocalidades().subscribe(
      (data: Localidade[]) => {
        this.localidades = data;
        this.aplicarFiltro();
      },
      (error) => {
        this.alertaErro = true;
        this.mensagemAlerta = 'Erro ao listar localidades. Detalhes: ' + error.message;
      }
    );
  }

  aplicarFiltro (): void {
    if (this.filtroLogradouro.trim() !== '') {
      this.localidadesFiltrados = this.localidades.filter(localidade =>
        localidade.logradouro.toLowerCase().includes(this.filtroLogradouro.toLowerCase())
      );
    } else {
      this.localidadesFiltrados = this.localidades;
    }
  }

  verDetalhes (id: string): void {
    this.router.navigate([`/localidades/detalhe/${id}`]);
  }

  editarLocalidade (id: string): void {
    this.router.navigate([`/localidades/editar/${id}`]);
  }

  excluirLocalidade (id: string): void {
    this.localidadeService.excluirLocalidade(id).subscribe(() => {
      this.carregarLocalidades();
    },
      (error) => {
        this.alertaErro = true;
        this.mensagemAlerta = 'Erro ao excluir localidade. Detalhes: ' + error.message;
      });
  }
}
