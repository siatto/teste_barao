import { Component } from '@angular/core';
import { AuthService } from '../../../servicos/auth.service';

@Component({
  selector: 'app-tela-localidade',
  templateUrl: './tela.component.html',
  styleUrls: ['./tela.component.css']
})
export class TelaLocalidadeComponent {
  constructor(private authService: AuthService) { }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }
}
