import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppConfig {
  private apiUrl = 'http://localhost:5000/api';

  getApiUrl(): string {
    return this.apiUrl;
  }
}