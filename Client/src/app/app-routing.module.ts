import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { AnonymousGuard } from "./core/guards/anonymous.guard";
import { AuthGuard } from "./core/guards/auth.guard";
import { AdminGuard } from "./core/guards/admin.guard";

const routes: Routes = [
	{
		path: "auth",
		loadChildren: () => import("./auth/auth.module").then((m) => m.AuthModule),
		canActivate: [AnonymousGuard],
	},
	{
		path: "course",
		loadChildren: () => import("./course/course.module").then((m) => m.CourseModule),
		runGuardsAndResolvers: "always",
	},
	{
		path: "account",
		loadChildren: () => import("./account/account.module").then((m) => m.AccountModule),
		runGuardsAndResolvers: "always",
		canActivate: [AuthGuard],
	},
	{
		path: "admin",
		loadChildren: () => import("./admin/admin.module").then((m) => m.AdminModule),
		runGuardsAndResolvers: "always",
		canActivate: [AuthGuard, AdminGuard],
	},
	{
		path: "**",
		redirectTo: "course",
	},
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
})
export class AppRoutingModule {}
