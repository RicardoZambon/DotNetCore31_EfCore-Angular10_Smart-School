import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit {

  public titulo = 'Alunos';
  public alunoSelecionado: number;

  public alunos = [    
    { id: 1, nome: 'Marta', sobrenome: 'Kent', telefone: '33225555' },
    { id: 2, nome: 'Paula', sobrenome: 'Isabela', telefone: '3354288' },
    { id: 3, nome: 'Laura', sobrenome: 'Antonia', telefone: '55668899' },
    { id: 4, nome: 'Luiza', sobrenome: 'Maria', telefone: '6565659' },
    { id: 5, nome: 'Lucas', sobrenome: 'Machado', telefone: '565685415' },
    { id: 6, nome: 'Pedro', sobrenome: 'Alvares', telefone: '466454545' },
    { id: 7, nome: 'Paulo', sobrenome: 'José', telefone: '9874512' }
  ];

  constructor() { }

  ngOnInit(): void {
  }

  selecionaAluno(aluno: any): void {
    this.alunoSelecionado = aluno.id;
  }

  voltar(): void {
    this.alunoSelecionado = null;
  }

}
