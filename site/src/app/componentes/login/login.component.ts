import { Component } from '@angular/core';
import { AuthService } from '../../servicos/auth.service';
import { Router } from '@angular/router';
import { UsuarioService } from '../../servicos/usuario.service';
import { Usuario } from '../../modelos/usuario';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  login: string = '';
  senha: string = '';
  validacao: string = '';
  validacaoFixa: string = '000000';
  loginSucesso: boolean = false;
  loginFalha: boolean = false;
  novoUsuarioCadastrado: boolean = false;

  novoUsuario: Usuario = {
    id: uuidv4(),
    login: '',
    senha: ''
  };

  constructor(
    private authService: AuthService,
    private router: Router,
    private usuarioService: UsuarioService
  ) { }

  onSubmit () {
    this.authService.login(this.login, this.senha).subscribe(
      (response) => {
        this.handleLoginSuccess(response.token);
      },
      (error) => {
        this.handleLoginError(error);
      }
    );
  }

  private handleLoginSuccess (token: string): void {
    this.loginSucesso = true;
    this.loginFalha = false;
    this.novoUsuarioCadastrado = false;

    this.authService.setTokenAndScheduleLogout(token);
    this.router.navigate(['/']);
  }

  private handleLoginError (error: any): void {
    if (this.validacao === this.validacaoFixa) {
      this.createUsuarioAndLogin();
    } else {
      this.loginSucesso = false;
      this.loginFalha = true;
      this.novoUsuarioCadastrado = false;
    }
  }

  private createUsuarioAndLogin (): void {
    this.novoUsuario.login = this.login;
    this.novoUsuario.senha = this.senha;
    this.usuarioService.salvarUsuario(this.novoUsuario).subscribe(
      () => {
        this.loginSucesso = false;
        this.loginFalha = false;
        this.novoUsuarioCadastrado = true;
        // Pode adicionar lógica adicional, como fazer login automaticamente após o cadastro.
      },
      (error) => {
        console.error('Erro ao criar usuário:', error);
        // Adicione tratamento de erro adequado aqui.
      }
    );
  }
}
