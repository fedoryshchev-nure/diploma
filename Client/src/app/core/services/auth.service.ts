
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

import { environment } from 'src/environments/environment';

import { User } from 'src/app/shared/models/user';
import { RegisterModel } from 'src/app/shared/models/auth/register-model';
import { LoginModel } from 'src/app/shared/models/auth/login-model';

const currentUser = "currentUser";
const roleClaim = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  constructor(
    private http: HttpClient,
  ) {
    let user = JSON.parse(localStorage.getItem(currentUser));

    if (!user || !user.token) {
      user = null;
    } else {
      const isExpired = new JwtHelperService().isTokenExpired(user.token);
      user = isExpired ? null : user;
    }

    this.currentUserSubject = new BehaviorSubject<User>(user);
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  public register(registerModel: RegisterModel): Observable<User> {
    return this.http.post<User>(
      `${environment.apiUrl}/auth/register`,
      registerModel,
    )
      .pipe(map(user => {
        localStorage.setItem(currentUser, JSON.stringify(user));
        this.currentUserSubject.next(user);
        return user;
      }));
  }

  public login(loginModel: LoginModel): Observable<User> {
    return this.http.post<User>(
      `${environment.apiUrl}/auth/login`,
      loginModel,
    )
      .pipe(map(user => {
        localStorage.setItem(currentUser, JSON.stringify(user));
        this.currentUserSubject.next(user);
        return user;
      }));
  }

  public logout() {
    localStorage.removeItem('currentUser');
    this.currentUserSubject.next(null);
  }

  public isAdmin(): boolean {
    if (this.currentUserValue) {
      const userRoles = new JwtHelperService()
        .decodeToken(this.currentUserValue.token)[roleClaim].split(",");

      if (userRoles.includes("Admin")) {
        return true;
      }
    }

    return false;
  }
}