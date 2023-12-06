import { Localidade } from './localidade';

export interface Estudante {
  id: string;
  nomeCompleto: string;
  dataNascimento: Date;
  localidade?: Localidade;
}