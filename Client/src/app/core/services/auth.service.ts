import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Observable, BehaviorSubject } from "rxjs";
import { tap } from "rxjs/operators";

import { environment } from "src/environments/environment";

import { User } from "src/app/shared/models/user";
import { RegisterModel } from "src/app/shared/models/auth/register-model";
import { LoginModel } from "src/app/shared/models/auth/login-model";

const currentUser = "currentUser";

@Injectable({
	providedIn: "root",
})
export class AuthService {
	private currentUserSubject: BehaviorSubject<User>;
	public currentUser: Observable<User>;

	constructor(private http: HttpClient, private router: Router) {
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
		return this.http.post<User>(`${environment.apiUrl}/auth/register`, registerModel).pipe(tap((user) => this.rewriteCache(user)));
	}

	public login(loginModel: LoginModel): Observable<User> {
		return this.http.post<User>(`${environment.apiUrl}/auth/login`, loginModel).pipe(tap((user) => this.rewriteCache(user)));
	}

	public rewriteCache(user: User) {
		localStorage.setItem(currentUser, JSON.stringify(user));
		this.currentUserSubject.next(user);
	}

	public logout() {
		localStorage.removeItem("currentUser");
		this.currentUserSubject.next(null);
		this.router.navigate(["/auth/login"]);
	}
}
