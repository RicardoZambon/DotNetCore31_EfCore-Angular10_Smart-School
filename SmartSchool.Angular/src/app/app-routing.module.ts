import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AlunosComponent } from './alunos/alunos.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DisciplinasComponent } from './disciplinas/disciplinas.component';
import { PerfilComponent } from './perfil/perfil.component';
import { ProfessoresComponent } from './professores/professores.component';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'alunos', component: AlunosComponent},
  { path: 'perfil', component: PerfilComponent },
  { path: 'professores', component: ProfessoresComponent },
  { path: 'disciplinas', component: DisciplinasComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
