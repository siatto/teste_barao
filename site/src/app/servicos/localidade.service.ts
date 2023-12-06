import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Localidade } from '../modelos/localidade';
import { AuthService } from '../servicos/auth.service';

import { AppConfig } from '../app.config';

@Injectable({
  providedIn: 'root'
})
export class LocalidadeService {
  private apiUrl = `${this.appConfig.getApiUrl()}/localidade`;
  private apiViaCepUrl = 'https://viacep.com.br/ws';

  constructor(private http: HttpClient, private authService: AuthService, private appConfig: AppConfig) { }

  private getHeaders (): HttpHeaders {
    const token = this.authService.getToken();
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
  }

  listarLocalidades (): Observable<Localidade[]> {
    return this.http.get<Localidade[]>(this.apiUrl);
  }

  obterLocalidadePorId (id: string): Observable<Localidade> {
    return this.http.get<Localidade>(`${this.apiUrl}/${id}`);
  }

  obterLocalidadesPorLogradouro (logradouro: string): Observable<Localidade[]> {
    return this.http.get<Localidade[]>(`${this.apiUrl}/por-logradouro/${logradouro}`);
  }

  salvarLocalidade (localidade: Localidade): Observable<Localidade> {
    return this.http.post<Localidade>(this.apiUrl, localidade, { headers: this.getHeaders() });
  }

  atualizarLocalidade (localidade: Localidade): Observable<any> {
    return this.http.put(`${this.apiUrl}`, localidade, { headers: this.getHeaders() });
  }

  excluirLocalidade (id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`, { headers: this.getHeaders() });
  }

  obterDetalhesCEP (cep: string): Observable<any> {
    const url = `${this.apiViaCepUrl}/${cep}/json`;
    return this.http.get<any>(url);
  }
}
