import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Aluno } from '../models/Aluno';
import { AlunoService } from './aluno.service';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
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
    this.carregarAlunos()
  }

  carregarAlunos(): void {
    this.alunoService.getAll().subscribe(
      (alunos) => { this.alunos = alunos; },
      (error: any) => { console.error(error); }
    );
  }

  salvarAluno(alunoModel: Aluno): void {
    if (alunoModel.id > 0) {
      this.alunoService.put(alunoModel.id, alunoModel).subscribe(
        () => {
          this.carregarAlunos();
          this.alunoSelecionado = null;
        },
        (error: any) => { console.error(error); }
      );
    }
    else {
      this.alunoService.post(alunoModel).subscribe(
        () => {
          this.carregarAlunos();
          this.alunoSelecionado = null;
        },
        (error: any) => { console.error(error); }
      );
    }
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

  selecionaAluno(aluno: Aluno): void {
    this.alunoSelecionado = aluno;
    this.alunoForm.patchValue(aluno);
  }

  voltar(): void {
    this.alunoSelecionado = null;
  }
}