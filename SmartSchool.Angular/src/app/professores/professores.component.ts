import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Professor } from '../models/Professor';
import { ProfessorService } from './professor.service';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html'
})
export class ProfessoresComponent implements OnInit {

  public titulo = 'Professores';
  public tituloForm = 'Novo professor';

  public professores: Professor[];
  public professorSelecionadoId: number;
  public professorForm: FormGroup;

  constructor(private fb: FormBuilder, private professorService: ProfessorService, private cdr: ChangeDetectorRef) {
    this.criarForm();
  }

  ngOnInit(): void {
    this.carregarProfessores();
  }
  
  criarForm(): void {
    this.professorForm = this.fb.group({
      nome: ['', Validators.required],
      disciplina: [0, Validators.required]
    });
  }

  mostrarForm(professorId: number, professor: Professor): void {
    this.professorSelecionadoId = professorId;
    this.professorForm.patchValue(professor);
    this.cdr.detectChanges();
  }
  

  carregarProfessores(): void {
    this.professorService.getAll().subscribe(
      (professores) => { this.professores = professores; },
      (error: any) => { console.error(error); }
    );
  }
  
  selecionaProfessor(professorId: number): void {
    this.professorService.getById(professorId)
      .subscribe(
        (professor) => { this.mostrarForm(professorId, professor); },
        (error: any) => { console.error(error); }
      );
  }

  novoProfessor(): void {
    this.mostrarForm(-1, new Professor);
  }


  professorSubmit() {
    this.salvarProfessor(this.professorForm.value);
  }

  salvarProfessor(professorModel: Professor): void {
    professorModel.id = this.professorSelecionadoId;
    this.professorService[(professorModel.id !== -1) ? 'put' : 'post'](professorModel).subscribe(
      () => {
        this.carregarProfessores();
        this.voltar();
      },
      (error: any) => { console.error(error); }
    );
  }

  voltar() {
    this.professorSelecionadoId = 0;
    this.professorForm.patchValue(new Professor);
  }

  deletarProfessor(idProfessor: number): void {
    this.professorService.delete(idProfessor).subscribe(
      () => {
        this.carregarProfessores();
        this.voltar();
      },
      (error: any) => { console.error(error); }
    );
  }
}