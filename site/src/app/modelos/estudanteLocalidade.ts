import { Estudante } from './estudante';
import { Localidade } from './localidade';

export interface EstudanteLocalidade {
  id: string;
  estudanteId: string;
  estudante: Estudante;
  localidadeId: string;
  localidade: Localidade;
}