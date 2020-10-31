import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Aluno } from '../models/Aluno';

@Injectable({
  providedIn: 'root'
})
export class AlunoService {

  private baseUrl = `${environment.apiUrl}/api/aluno`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Aluno[]> {
    return this.http.get<Aluno[]>(this.baseUrl);
  }

  getById(alunoId: number): Observable<Aluno> {
    return this.http.get<Aluno>(`${this.baseUrl}/${alunoId}`);
  }

  post(aluno: Aluno): Observable<Aluno> {
    return this.http.post<Aluno>(this.baseUrl, aluno);
  }

  put(aluno: Aluno): Observable<Aluno> {
    return this.http.put<Aluno>(`${this.baseUrl}/${aluno.id}`, aluno);
  }

  delete(alunoId: number): Observable<Aluno> {
    return this.http.delete<Aluno>(`${this.baseUrl}/${alunoId}`);
  }
}