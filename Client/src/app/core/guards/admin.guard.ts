import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";

import { UserService } from "../services/user.service";

@Injectable({
	providedIn: "root",
})
export class AdminGuard implements CanActivate {
	constructor(private router: Router, private userService: UserService) {}

	canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
		const isAdmin = this.userService.isAdmin();

		if (!isAdmin) {
			this.router.navigate(["auth/login"]);
		}

		return isAdmin;
	}
}
