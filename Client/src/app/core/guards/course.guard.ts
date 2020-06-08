import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";

import { UserService } from "../services/user.service";

@Injectable({
	providedIn: "root",
})
export class CourseGuard implements CanActivate {
	constructor(private userService: UserService, private router: Router) {}

	canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
		const courseId = route.parent.paramMap.get("courseId");
		const attendingOrNewUrlTree = this.userService.isAttendingCourse(courseId).pipe(map((val) => val || this.router.parseUrl(`/course/${courseId}`)));
		return attendingOrNewUrlTree;
	}
}
