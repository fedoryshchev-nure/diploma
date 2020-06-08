import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { AddCourseComponent } from "./pages/add-course/add-course.component";
import { EditCourseComponent } from "./pages/edit-course/edit-course.component";

const routes: Routes = [
	{
		path: "course/add",
		component: AddCourseComponent,
	},
	{
		path: "course/:courseId/edit",
		component: EditCourseComponent,
	},
	{
		path: "**",
		redirectTo: "course/add",
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class AdminRoutingModule {}
