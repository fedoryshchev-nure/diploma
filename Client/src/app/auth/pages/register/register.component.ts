import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Validators, FormBuilder } from '@angular/forms';

import { AuthService } from 'src/app/core/services/auth.service';
import { ConfirmPassValdiator } from 'src/app/auth/validators/confirm-password';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  email = 'Email';
  password = 'Password';
  confirmPassword = 'ConfirmPassword';

  errorOccurd = false;

  signUpForm = this.fb.group({
    Email: ['', [Validators.required, Validators.email]],
    Password: ['', [Validators.required, Validators.minLength(6)]],
    ConfirmPassword: ['', [Validators.required, Validators.minLength(6)]],
  });

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.signUpForm.controls[this.confirmPassword].setAsyncValidators(
      ConfirmPassValdiator(this.signUpForm));
  }

  onSubmit(): void {
    if (this.signUpForm.valid) {
      this.authService.register(this.signUpForm.value).subscribe(x => {
        this.router.navigate(['/account/signin']);
      }, error => {
        this.errorOccurd = true;
      });
    }
  }

}
