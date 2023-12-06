import { Routes } from '@angular/router';
import { ListaLocalidadeComponent } from '../componentes/localidade/lista/lista.component';
import { CriarLocalidadeComponent } from '../componentes/localidade/criar/criar.component';
import { DetalhesLocalidadeComponent } from '../componentes/localidade/detalhes/detalhes.component';
import { EditarLocalidadeComponent } from '../componentes/localidade/editar/editar.component';
import { TelaLocalidadeComponent } from '../componentes/localidade/tela/tela.component';

import { AuthGuard } from '../auth.guard';

export const LocalidadeRoutes: Routes = [
  { path: 'localidades', component: ListaLocalidadeComponent, canActivate: [AuthGuard] },
  { path: 'localidades/criar', component: CriarLocalidadeComponent, canActivate: [AuthGuard] },
  { path: 'localidades/detalhe/:id', component: DetalhesLocalidadeComponent, canActivate: [AuthGuard] },
  { path: 'localidades/editar/:id', component: EditarLocalidadeComponent, canActivate: [AuthGuard] },
  { path: 'localidades/tela', component: TelaLocalidadeComponent },
];
