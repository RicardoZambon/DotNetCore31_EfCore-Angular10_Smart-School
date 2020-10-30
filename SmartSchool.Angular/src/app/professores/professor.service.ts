import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Professor } from '../models/Professor';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService {

  private baseUrl = `${environment.apiUrl}/api/professor`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Professor[]> {
    return this.http.get<Professor[]>(this.baseUrl);
  }

  getById(professorId: number): Observable<Professor> {
    return this.http.get<Professor>(`${this.baseUrl}/${professorId}`);
  }

  post(professor: Professor): Observable<Professor> {
    return this.http.post<Professor>(this.baseUrl, professor);
  }

  put(professorId: number, professor: Professor): Observable<Professor> {
    return this.http.put<Professor>(`${this.baseUrl}/${professorId}`, professor);
  }

  delete(professorId: number): Observable<Professor> {
    return this.http.delete<Professor>(`${this.baseUrl}/${professorId}`);
  }
}
