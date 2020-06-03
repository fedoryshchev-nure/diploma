
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { Observable, of } from 'rxjs';

import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  email = 'Email';
  password = 'Password';

  errors$: Observable<string[]>;

  signInForm = this.fb.group({
    Email: ['', [Validators.required, Validators.email]],
    Password: ['', [Validators.required, Validators.minLength(6)]]
  });

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  public onSubmit(): void {
    if (this.signInForm.valid) {
      this.authService.login(this.signInForm.value).subscribe(() => {
        this.router.navigate(['/']);
      }, err => {
        this.errors$ = of([err.error.Message]);
      });
    }
  }

}