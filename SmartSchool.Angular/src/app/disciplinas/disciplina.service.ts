import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DisciplinaFormModel, DisciplinaListModel } from '../models/Disciplina';

@Injectable({
  providedIn: 'root'
})
export class DisciplinaService {
  private baseUrl = `${environment.apiUrl}/api/disciplina`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<DisciplinaListModel[]> {
    return this.http.get<DisciplinaListModel[]>(this.baseUrl);
  }

  getById(disciplinaId: number): Observable<DisciplinaFormModel> {
    return this.http.get<DisciplinaFormModel>(`${this.baseUrl}/${disciplinaId}`);
  }

  post(disciplina: DisciplinaFormModel): Observable<DisciplinaFormModel> {
    return this.http.post<DisciplinaFormModel>(this.baseUrl, disciplina);
  }

  put(disciplina: DisciplinaFormModel): Observable<DisciplinaFormModel> {
    return this.http.put<DisciplinaFormModel>(`${this.baseUrl}/${disciplina.id}`, disciplina);
  }

  delete(disciplinaId: number): Observable<Object> {
    return this.http.delete(`${this.baseUrl}/${disciplinaId}`);
  }
}
