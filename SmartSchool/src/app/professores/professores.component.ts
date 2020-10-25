import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.css']
})
export class ProfessoresComponent implements OnInit {

  public titulo = "Professores";
  public professorSelecionado: number;

  public professores = [
    { id: 1, nome: 'Lauro', disciplina: 'Matemática' },
    { id: 2, nome: 'Roberto', disciplina: 'Física' },
    { id: 3, nome: 'Ronaldo', disciplina: 'Português' },
    { id: 4, nome: 'Rodrigo', disciplina: 'Inglês' },
    { id: 5, nome: 'Alexandre', disciplina: 'Programação' }
  ]

  constructor() { }

  ngOnInit(): void {
  }

  selecionaProfessor(professor: any): void {
    this.professorSelecionado = professor.id;
  }

  voltar() {
    this.professorSelecionado = null;
  }

}
