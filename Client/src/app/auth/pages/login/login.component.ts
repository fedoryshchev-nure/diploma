
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';

import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  email = 'Email';
  password = 'Password';

  errorOccurd = false;

  signInForm = this.fb.group({
    Email: ['admin@admin.admin', [Validators.required, Validators.email]],
    Password: ['123456', [Validators.required, Validators.minLength(6)]]
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
      }, () => {
        this.errorOccurd = true;
      });
    }
  }

}