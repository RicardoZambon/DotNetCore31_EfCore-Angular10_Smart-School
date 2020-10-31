import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DisciplinaFormModel, DisciplinaListModel } from '../models/Disciplina';
import { Professor } from '../models/Professor';
import { ProfessorService } from '../professores/professor.service';
import { DisciplinaService } from './disciplina.service';

@Component({
  selector: 'app-disciplinas',
  templateUrl: './disciplinas.component.html'
})
export class DisciplinasComponent implements OnInit {

  public titulo = 'Disciplinas';
  
  public disciplinas: DisciplinaListModel[];
  public disciplinaSelecionadaId: number;
  public disciplinaForm: FormGroup;

  public professoresList: Professor[];

  constructor(private fb: FormBuilder, private cdr: ChangeDetectorRef, private disciplinaService: DisciplinaService, private professorService: ProfessorService) {
    this.criarForm();
  }

  ngOnInit() {
    this.carregarDisciplinas();
  }
  
  criarForm() {
    this.disciplinaForm = this.fb.group({
      id: [0],
      nome: ['', Validators.required],
      professorId: [0, Validators.min(1)],
    });
  }

  mostrarForm(disciplinaId: number, disciplina: DisciplinaFormModel): void {

    this.professorService.getAll().subscribe(
      (professores) => { this.professoresList = professores; },
      (error: any) => { console.error(error); }
    );

    this.disciplinaSelecionadaId = disciplinaId;
    this.disciplinaForm.patchValue(disciplina);
    this.cdr.detectChanges();
  }
  

  carregarDisciplinas(): void {
    this.disciplinaService.getAll().subscribe(
      (disciplinas) => { this.disciplinas = disciplinas; },
      (error: any) => { console.error(error); }
    );
  }

  selecionaDisciplina(disciplinaId: number): void {
    this.disciplinaService.getById(disciplinaId)
      .subscribe(
        (disciplina) => { this.mostrarForm(disciplinaId, disciplina); },
        (error: any) => { console.error(error); }
      );
  }
  
  novaDisciplina(): void {
    this.mostrarForm(-1, new DisciplinaFormModel);
  }


  disciplinaSubmit() {
    this.salvarDisciplina(this.disciplinaForm.value);
  }

  salvarDisciplina(disciplinaModel: DisciplinaFormModel): void {
    disciplinaModel.id = this.disciplinaSelecionadaId;
    this.disciplinaService[(this.disciplinaSelecionadaId !== -1) ? 'put' : 'post'](disciplinaModel)
      .subscribe(
        () => {
          this.carregarDisciplinas();
          this.voltar();
        },
        (error: any) => { console.error(error); }
      );
  }

  voltar(): void {
    this.disciplinaSelecionadaId = 0;
    this.disciplinaForm.patchValue(new DisciplinaFormModel);
  }

  deletarDisciplina(idAluno: number): void {
    this.disciplinaService.delete(idAluno).subscribe(
      () => {
        this.carregarDisciplinas();
        this.voltar();
      },
      (error: any) => { console.error(error); }
    );
  }

}
