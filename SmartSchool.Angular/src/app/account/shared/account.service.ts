import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { LoginModel } from 'src/app/account/models/LoginModel';
import { LoginResponse } from '../models/LoginResponse';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private baseUrl = `${environment.apiUrl}/api/user`;

  constructor(private http: HttpClient) { }

  authenticate(model: LoginModel): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.baseUrl}/authenticate`, model);
  }
}
