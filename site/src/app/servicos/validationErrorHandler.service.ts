import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ValidationErrorHandlerService {
  validationErrors (error: any): string[] {
    const validationErrors: string[] = [];
    if (error.status === 400 && error.error.errors) {
      const messages = error.error.errors;

      for (const message of messages) {
        validationErrors.push(message.trim().replace(/\.$/, '').toLowerCase());
      }
    } else {
      validationErrors.push('Erro desconhecido.');
    }

    return validationErrors;
  }
}
