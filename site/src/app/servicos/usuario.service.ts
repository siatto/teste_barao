import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../modelos/usuario';
import { AuthService } from '../servicos/auth.service';

import { AppConfig } from '../app.config';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  private apiUrl = `${this.appConfig.getApiUrl()}/usuario`;

  constructor(private http: HttpClient, private authService: AuthService, private appConfig: AppConfig) { }

  private getHeaders (): HttpHeaders {
    const token = this.authService.getToken();
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
  }

  listarUsuarios (): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.apiUrl);
  }

  obterUsuarioPorId (id: string): Observable<Usuario> {
    return this.http.get<Usuario>(`${this.apiUrl}/${id}`);
  }

  salvarUsuario (usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.apiUrl, usuario, { headers: this.getHeaders() });
  }

  atualizarUsuario (usuario: Usuario): Observable<any> {
    return this.http.put(`${this.apiUrl}`, usuario, { headers: this.getHeaders() });
  }

  excluirUsuario (id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`, { headers: this.getHeaders() });
  }
}
