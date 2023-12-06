import { Routes } from '@angular/router';
import { ListaEstudanteComponent } from '../componentes/estudante/lista/lista.component';
import { CriarEstudanteComponent } from '../componentes/estudante/criar/criar.component';
import { DetalhesEstudanteComponent } from '../componentes/estudante/detalhes/detalhes.component';
import { EditarEstudanteComponent } from '../componentes/estudante/editar/editar.component';
import { TelaEstudanteComponent } from '../componentes/estudante/tela/tela.component';

import { AuthGuard } from '../auth.guard';

export const EstudanteRoutes: Routes = [
  { path: 'estudantes', component: ListaEstudanteComponent, canActivate: [AuthGuard] },
  { path: 'estudantes/criar', component: CriarEstudanteComponent, canActivate: [AuthGuard] },
  { path: 'estudantes/detalhe/:id', component: DetalhesEstudanteComponent, canActivate: [AuthGuard] },
  { path: 'estudantes/editar/:id', component: EditarEstudanteComponent, canActivate: [AuthGuard] },
  { path: 'estudantes/tela', component: TelaEstudanteComponent },
];
