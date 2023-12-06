import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EstudanteService } from '../../../servicos/estudante.service';
import { Estudante } from '../../../modelos/estudante';
import { AuthService } from '../../../servicos/auth.service';

@Component({
  selector: 'app-lista-estudante',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.css']
})
export class ListaEstudanteComponent implements OnInit {
  estudantes: Estudante[] = [];
  estudantesFiltrados: Estudante[] = [];
  filtroNome: string = '';
  alertaSucesso: boolean = false;
  alertaErro: boolean = false;
  mensagemAlerta: string = '';

  constructor(private estudanteService: EstudanteService, private router: Router, private authService: AuthService) { }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  ngOnInit (): void {
    this.carregarEstudantes();
  }

  fecharAlerta (tipo: string): void {
    if (tipo === 'sucesso') {
      this.alertaSucesso = false;
    } else if (tipo === 'erro') {
      this.alertaErro = false;
    }
  }

  carregarEstudantes (): void {
    this.estudanteService.listarEstudantes()
      .subscribe(
        (data: Estudante[]) => {
          this.estudantes = data;
          this.aplicarFiltro();
        },
        (error) => {
          this.alertaErro = true;
          this.mensagemAlerta = 'Erro ao listar estudantes. Detalhes: ' + error.message;
        }
      );
  }

  aplicarFiltro (): void {
    if (this.filtroNome.trim() !== '') {
      this.estudantesFiltrados = this.estudantes.filter(estudante =>
        estudante.nomeCompleto.toLowerCase().includes(this.filtroNome.toLowerCase())
      );
    } else {
      this.estudantesFiltrados = this.estudantes;
    }
  }

  verDetalhes (id: string): void {
    this.router.navigate([`/estudantes/detalhe/${id}`]);
  }

  editarEstudante (id: string): void {
    this.router.navigate([`/estudantes/editar/${id}`]);
  }

  excluirEstudante (id: string): void {
    this.estudanteService.excluirEstudante(id).subscribe(() => {
      this.carregarEstudantes();
    },
      (error) => {
        this.alertaErro = true;
        this.mensagemAlerta = 'Erro ao excluir estudante. Detalhes: ' + error.message;
      });
  }
}
