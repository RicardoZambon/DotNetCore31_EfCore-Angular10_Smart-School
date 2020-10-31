import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Aluno } from '../models/Aluno';
import { AlunoService } from './aluno.service';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html'
})
export class AlunosComponent implements OnInit {

  public alunoForm: FormGroup;
  public titulo = 'Alunos';
  public alunoSelecionado: Aluno;

  public alunos: Aluno[];

  constructor(private fb: FormBuilder, private alunoService: AlunoService) {
    this.criarForm();
  }

  ngOnInit(): void {
    this.carregarAlunos();
  }

  carregarAlunos(): void {
    this.alunoService.getAll().subscribe(
      (alunos) => { this.alunos = alunos; },
      (error: any) => { console.error(error); }
    );
  }

  salvarAluno(alunoModel: Aluno): void {
    this.alunoService[(alunoModel.id  !== 0) ? 'put' : 'post'](alunoModel)
      .subscribe(
        () => {
          this.carregarAlunos();
          this.alunoSelecionado = null;
        },
        (error: any) => { console.error(error); }
      );
  }


  criarForm() {
    this.alunoForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      telefone: ['', Validators.required]
    });
  }

  alunoSubmit() {
    this.salvarAluno(this.alunoForm.value);
  }

  novoAluno(): void {
    this.alunoSelecionado = new Aluno;
    this.alunoForm.patchValue(this.alunoSelecionado);
  }

  selecionaAluno(aluno: Aluno): void {
    this.alunoSelecionado = aluno;
    this.alunoForm.patchValue(aluno);
  }

  voltar(): void {
    this.alunoSelecionado = null;
  }

  deletarAluno(idAluno: number): void {
    this.alunoService.delete(idAluno).subscribe(
      () => {
        this.carregarAlunos();
        this.alunoSelecionado = null;
      },
      (error: any) => { console.error(error); }
    );
  }
}