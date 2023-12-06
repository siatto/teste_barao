import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EstudanteLocalidade } from '../modelos/estudanteLocalidade';
import { AuthService } from './auth.service';

import { AppConfig } from '../app.config';

@Injectable({
  providedIn: 'root'
})
export class EstudanteLocalidadeService {
  private apiUrl = `${this.appConfig.getApiUrl()}/estudanteLocalidade`;

  constructor(private http: HttpClient, private authService: AuthService, private appConfig: AppConfig) { }

  private getHeaders (): HttpHeaders {
    const token = this.authService.getToken();
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
  }

  listarEstudanteLocalidades (): Observable<EstudanteLocalidade[]> {
    return this.http.get<EstudanteLocalidade[]>(this.apiUrl);
  }

  obterEstudanteLocalidadePorId (id: string): Observable<EstudanteLocalidade> {
    return this.http.get<EstudanteLocalidade>(`${this.apiUrl}/${id}`);
  }

  obterEstudanteLocalidadePorEstudante (estudanteId: string): Observable<EstudanteLocalidade> {
    return this.http.get<EstudanteLocalidade>(`${this.apiUrl}/por-estudante/${estudanteId}`);
  }

  salvarEstudanteLocalidade (estudanteLocalidade: EstudanteLocalidade): Observable<EstudanteLocalidade> {
    const { id, estudanteId, localidadeId } = estudanteLocalidade;
    return this.http.post<EstudanteLocalidade>(this.apiUrl, { id, estudanteId, localidadeId }, { headers: this.getHeaders() });
  }

  atualizarEstudanteLocalidade (estudanteLocalidade: EstudanteLocalidade): Observable<any> {
    return this.http.put(`${this.apiUrl}`, estudanteLocalidade, { headers: this.getHeaders() });
  }

  excluirEstudanteLocalidade (id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`, { headers: this.getHeaders() });
  }
}
