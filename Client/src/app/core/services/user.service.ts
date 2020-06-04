import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { map, tap } from "rxjs/operators";
import { JwtHelperService } from "@auth0/angular-jwt";

import { AuthService } from "./auth.service";

import { User } from "src/app/shared/models/user";
import { Course } from "src/app/shared/models/course/course";
import { Lesson } from "src/app/shared/models/course/lesson";

import { environment } from "src/environments/environment";

const roleClaim = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

@Injectable({
	providedIn: "root",
})
export class UserService {
	public user$: Observable<User>;

	constructor(private authService: AuthService, private http: HttpClient) {
		this.user$ = authService.currentUser;
	}

	public isAttendingCourse(id: string) {
		return this.user$.pipe(map((user) => user && user.courses && user.courses.some((course) => course.id === id)));
	}

	public attendCourse(id: string): Observable<Course> {
		return this.http.get<Course>(`${environment.apiUrl}/course/${id}/attend`).pipe(
			tap((course) => {
				const user = this.authService.currentUserValue;
				user.courses.push(course);
				this.authService.rewriteCache(user);
			})
		);
	}

	public completeLesson(courseId: string, lesson: Lesson) {
		return this.http.get(`${environment.apiUrl}/lesson/${lesson.id}/complete`).pipe(
			tap(() => {
				const user = this.authService.currentUserValue;
				const userLessons = user.courses.find((x) => x.id === courseId).lessons;
				const lsn = userLessons.find((x) => x.id === lesson.id);
				if (lsn) lsn.isCompleted = true;
				else {
					lesson.isCompleted = true;
					userLessons.push(lesson);
				}
				userLessons.sort((x) => x.order);
				this.authService.rewriteCache(user);
			})
		);
	}

	public isAdmin(): boolean {
		if (this.authService.currentUserValue) {
			const userRoles = new JwtHelperService().decodeToken(this.authService.currentUserValue.token)[roleClaim].split(",");

			if (userRoles.includes("Admin")) {
				return true;
			}
		}

		return false;
	}
}
