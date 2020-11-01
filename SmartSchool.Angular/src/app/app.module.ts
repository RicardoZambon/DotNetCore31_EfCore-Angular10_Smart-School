import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AlunosComponent } from './alunos/alunos.component';
import { ProfessoresComponent } from './professores/professores.component';
import { PerfilComponent } from './perfil/perfil.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NavComponent } from './nav/nav.component';
import { TituloComponent } from './titulo/titulo.component';
import { DisciplinasComponent } from './disciplinas/disciplinas.component';
import { HomeComponent } from './layout/home/home.component';
import { AuthComponent } from './layout/auth/auth.component';
import { LoginComponent } from './account/login/login.component';
import { AuthInterceptor } from './account/AuthInterceptor';

@NgModule({
  declarations: [			
    AppComponent,
    AlunosComponent,
    ProfessoresComponent,
    PerfilComponent,
    DashboardComponent,
    NavComponent,
    TituloComponent,
    DisciplinasComponent,
    HomeComponent,
    AuthComponent,
    LoginComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    AuthInterceptor, {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }