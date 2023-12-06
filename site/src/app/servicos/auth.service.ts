import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

import { AppConfig } from '../app.config';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private token: string = '';
  private readonly tempoLogin: number = 30;

  constructor(private http: HttpClient, private router: Router, private appConfig: AppConfig) { }

  login (login: string, senha: string): Observable<any> {
    const params = new HttpParams()
      .set('login', login)
      .set('senha', senha);

    return this.http.post<any>(`${this.appConfig.getApiUrl()}/auth/login`, {}, { params });
  }

  setTokenAndScheduleLogout (token: string) {
    this.token = token;

    const expirationTime = new Date().getTime() + (this.tempoLogin * 60 * 1000);

    localStorage.setItem('token', token);
    localStorage.setItem('tokenExpiration', expirationTime.toString());

    setTimeout(() => {
      this.removeToken();
    }, this.tempoLogin * 60 * 1000);
  }

  removeToken () {
    this.token = '';
    localStorage.removeItem('token');
    localStorage.removeItem('tokenExpiration');
    this.router.navigate(['/login']);
  }

  getToken (): string {
    return this.token || localStorage.getItem('token') || '';
  }

  isLoggedIn (): boolean {
    const timestampString = localStorage.getItem('tokenExpiration');
    if (timestampString !== null) {
      const timestamp = parseInt(timestampString, 10);
      if (!isNaN(timestamp)) {
        const dataExpiracao = new Date(timestamp);
        const dataAtual = new Date();
        if (dataExpiracao < dataAtual) {
          this.logout();
        }
      } else {
        this.logout();
      }
    } else {
      this.logout();
    }

    return !!this.getToken();
  }

  logout () {
    this.token = '';
    localStorage.removeItem('token');
  }
}
