import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './core/guards/auth.guard';
import { AdminGuard } from './core/guards/admin.guard';
import { AnonymousGuard } from './core/guards/anonymous.guard';


const routes: Routes = [
  {
    path: "auth",
    loadChildren: () => import("./auth/auth.module").then(m => m.AuthModule),
    canActivate: [AnonymousGuard]
  },
  {
    path: "course",
    loadChildren: () => import("./course/course.module").then(m => m.CourseModule)
  },
  {
    path: "account",
    loadChildren: () => import("./account/account.module").then(m => m.AccountModule),
    canActivate: [AuthGuard]
  },
  {
    path: "admin",
    loadChildren: () => import("./admin/admin.module").then(m => m.AdminModule),
    canActivate: [AuthGuard, AdminGuard]
  },
  {
    path: '**',
    redirectTo: 'course',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
