import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from 'src/app/models/LoginModel';
import { AccountService } from '../shared/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;

  constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router) {
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
    this.accountService.authenticate(model).subscribe(
      (response) => {
        window.localStorage.setItem('token', response.token);
        this.router.navigate(['']);
      },
      (error: any) => { console.error(error); }
    )
  }

  formSubmit(): void {
    this.authenticate(this.loginForm.value);
  }
}
