import { Component } from '@angular/core';
import { AuthService } from '../app/servicos/auth.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'site';

  constructor(private authService: AuthService, private router: Router) { }

  isLoggedIn (): boolean {
    return this.authService.isLoggedIn();
  }

  logout (): void {
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
