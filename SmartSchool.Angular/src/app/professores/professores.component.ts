import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Professor } from '../models/Professor';
import { ProfessorService } from './professor.service';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html'
})
export class ProfessoresComponent implements OnInit {

  public professorForm: FormGroup;
  public titulo = 'Professores';
  public professorSelecionado: Professor;

  public professores: Professor[];

  constructor(private fb: FormBuilder, private professorService: ProfessorService) {
    this.criarForm();
  }

  ngOnInit(): void {
    this.carregarProfessores();
  }

  carregarProfessores(): void {
    this.professorService.getAll().subscribe(
      (professores) => { this.professores = professores; },
      (error: any) => { console.error(error); }
    );
  }

  salvarProfessor(professorModel: Professor): void {
    this.professorService[(professorModel.id  != 0) ? 'put' : 'post'](professorModel).subscribe(
      () => {
        this.carregarProfessores();
        this.professorSelecionado = null;
      },
      (error: any) => { console.error(error); }
    );
  }


  criarForm(): void {
    this.professorForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required]//,
      //disciplina: ['', Validators.required]
    });
  }

  professorSubmit() {
    this.salvarProfessor(this.professorForm.value);
  }

  novoProfessor(): void {
    this.professorSelecionado = new Professor();
    this.professorForm.patchValue(this.professorSelecionado);
  }

  selecionaProfessor(professor: Professor): void {
    this.professorSelecionado = professor;
    this.professorForm.patchValue(professor);
  }

  voltar() {
    this.professorSelecionado = null;
  }
}