import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './componentes/home/home.component';
import { LoginComponent } from './componentes/login/login.component';
import { AuthGuard } from './auth.guard';

import { LocalidadeRoutes } from './rotas/localidade.routes';
import { EstudanteRoutes } from './rotas/estudante.routes';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  ...LocalidadeRoutes,
  ...EstudanteRoutes,
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
