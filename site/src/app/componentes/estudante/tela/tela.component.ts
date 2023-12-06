import { Component } from '@angular/core';
import { AuthService } from '../../../servicos/auth.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-tela-estudante',
  templateUrl: './tela.component.html',
  styleUrls: ['./tela.component.css']
})
export class TelaEstudanteComponent {
  constructor(private authService: AuthService) { }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }
}
