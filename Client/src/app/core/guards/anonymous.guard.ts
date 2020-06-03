import { Injectable } from "@angular/core";
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";

import { AuthService } from "../services/auth.service";

@Injectable({
	providedIn: "root",
})
export class AnonymousGuard implements CanActivate {
	constructor(private router: Router, private authenticationService: AuthService) {}

	canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
		const currentUser = this.authenticationService.currentUserValue;
		if (!currentUser) {
			return true;
		}

		this.router.navigate(["/"]);
		return false;
	}
}
