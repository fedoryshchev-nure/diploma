import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

import { AuthService } from '../services/auth.service';

const roleClaim = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(
    private router: Router,
    private authenticationService: AuthService
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const currentUser = this.authenticationService.currentUserValue;

    if (currentUser) {
      const userRoles = new JwtHelperService()
        .decodeToken(currentUser.token)[roleClaim].split(",");

      if (userRoles.includes("Admin")) {
        return true;
      }
    }

    this.router.navigate(['auth/login']);
    return false;
  }
}
