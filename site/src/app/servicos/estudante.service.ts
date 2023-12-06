import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Estudante } from '../modelos/estudante';
import { AuthService } from '../servicos/auth.service';

import { AppConfig } from '../app.config';

@Injectable({
  providedIn: 'root'
})
export class EstudanteService {
  private apiUrl = `${this.appConfig.getApiUrl()}/estudante`;

  constructor(private http: HttpClient, private authService: AuthService, private appConfig: AppConfig) { }

  private getHeaders (): HttpHeaders {
    const token = this.authService.getToken();
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
  }

  listarEstudantes (): Observable<Estudante[]> {
    return this.http.get<Estudante[]>(this.apiUrl);
  }

  obterEstudanteById (id: string): Observable<Estudante> {
    return this.http.get<Estudante>(`${this.apiUrl}/${id}`);
  }

  obterEstudantesByName (nome: string): Observable<Estudante[]> {
    return this.http.get<Estudante[]>(`${this.apiUrl}/por-nome/${nome}`);
  }

  salvarEstudante (estudante: Estudante): Observable<Estudante> {
    return this.http.post<Estudante>(this.apiUrl, estudante, { headers: this.getHeaders() });
  }

  atualizarEstudante (estudante: Estudante): Observable<any> {
    console.log(estudante);
    return this.http.put(`${this.apiUrl}`, estudante, { headers: this.getHeaders() });
  }

  excluirEstudante (id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`, { headers: this.getHeaders() });
  }
}
