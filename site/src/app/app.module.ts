import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from '../app/app-routing.module';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';

import { LoginComponent } from './componentes/login/login.component';

import { ListaEstudanteComponent } from './componentes/estudante/lista/lista.component';
import { CriarEstudanteComponent } from './componentes/estudante/criar/criar.component';
import { EditarEstudanteComponent } from './componentes/estudante/editar/editar.component';
import { DetalhesEstudanteComponent } from './componentes/estudante/detalhes/detalhes.component';
import { TelaEstudanteComponent } from './componentes/estudante/tela/tela.component';

import { ListaLocalidadeComponent } from './componentes/localidade/lista/lista.component';
import { CriarLocalidadeComponent } from './componentes/localidade/criar/criar.component';
import { EditarLocalidadeComponent } from './componentes/localidade/editar/editar.component';
import { DetalhesLocalidadeComponent } from './componentes/localidade/detalhes/detalhes.component';
import { TelaLocalidadeComponent } from './componentes/localidade/tela/tela.component';

import { EnderecoFormComponent } from './componentes/localidade/form/enderecoForm.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ListaEstudanteComponent,
    CriarEstudanteComponent,
    EditarEstudanteComponent,
    DetalhesEstudanteComponent,
    TelaEstudanteComponent,
    ListaLocalidadeComponent,
    CriarLocalidadeComponent,
    EditarLocalidadeComponent,
    DetalhesLocalidadeComponent,
    TelaLocalidadeComponent,
    EnderecoFormComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
