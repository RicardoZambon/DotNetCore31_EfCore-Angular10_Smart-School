import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Aluno } from '../models/Aluno';
import { AlunoService } from './aluno.service';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html'
})
export class AlunosComponent implements OnInit {

  public titulo = 'Alunos';
  
  public alunos: Aluno[];
  public alunoSelecionadoId: number;
  public alunoForm: FormGroup;

  constructor(private fb: FormBuilder, private alunoService: AlunoService, private cdr: ChangeDetectorRef) {
    this.criarForm();
  }

  ngOnInit(): void {
    this.carregarAlunos();
  }
  
  criarForm() {
    this.alunoForm = this.fb.group({
      id: [0],
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      telefone: ['', Validators.required]
    });
  }

  mostrarForm(alunoId: number, aluno: Aluno): void {
    this.alunoSelecionadoId = alunoId;
    this.alunoForm.patchValue(aluno);
    this.cdr.detectChanges();
  }
  

  carregarAlunos(): void {
    this.alunoService.getAll().subscribe(
      (alunos) => { this.alunos = alunos; },
      (error: any) => { console.error(error); }
    );
  }

  selecionaAluno(alunoId: number): void {
    this.alunoService.getById(alunoId)
      .subscribe(
        (aluno) => {
          this.mostrarForm(alunoId, aluno);
        },
        (error: any) => { console.error(error); }
      );
  }
  
  novoAluno(): void {
    this.mostrarForm(-1, new Aluno);
  }


  alunoSubmit() {
    this.salvarAluno(this.alunoForm.value);
  }

  salvarAluno(alunoModel: Aluno): void {
    alunoModel.id = this.alunoSelecionadoId;
    this.alunoService[(this.alunoSelecionadoId !== -1) ? 'put' : 'post'](alunoModel)
      .subscribe(
        () => {
          this.carregarAlunos();
          this.voltar();
        },
        (error: any) => { console.error(error); }
      );
  }

  voltar(): void {
    this.alunoSelecionadoId = 0;
    this.alunoForm.patchValue(new Aluno);
  }

  deletarAluno(idAluno: number): void {
    this.alunoService.delete(idAluno).subscribe(
      () => {
        this.carregarAlunos();
        this.voltar();
      },
      (error: any) => { console.error(error); }
    );
  }
}