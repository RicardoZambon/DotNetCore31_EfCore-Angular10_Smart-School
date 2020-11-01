import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { throwError } from 'rxjs';
import { catchError, delay } from 'rxjs/operators';

import { AccountService } from '../shared/account.service';
import { LoginModel } from '../models/LoginModel';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;

  public showMessage: boolean;
  public loginMessage: string;

  constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router, private cdr: ChangeDetectorRef) {
    this.createForm();
  }

  ngOnInit() {
  }

  createForm() {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  authenticate(model: LoginModel): void {
    this.accountService.authenticate(model)
      .pipe(catchError(this.handleError))
      .subscribe(
        (response) => {
          window.localStorage.setItem('token', response.token);
          this.router.navigate(['']);
        },
        (error: any) => {
          this.loginMessage = error;
          this.showMessage = true;
          console.log(error);
        }
      );
  }

  formSubmit(): void {
    this.showMessage = false;
    setTimeout(() => 
    {
      this.loginMessage = null;
      this.authenticate(this.loginForm.value);
    },
    500);
  }

  private handleError(error: HttpErrorResponse) {
    switch (error.status)
    {
      case 0:
        return throwError('Não foi possível comunicar com a API');
      case 401:
        return throwError('Usuário ou senha inválidos');
      default:
        return throwError(`Ocorreu um erro (${error.status}), se o problema persistir, favor entrar em contato.`);
    }
  }
}
