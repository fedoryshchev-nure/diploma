import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { CoursesComponent } from "./pages/courses/courses.component";
import { CourseComponent } from "./pages/course/course.component";
import { CourseInfoComponent } from "./pages/course-info/course-info.component";
import { LessonsComponent } from "./pages/lessons/lessons.component";
import { CourseGuard } from "../core/guards/course.guard";

const routes: Routes = [
	{
		path: "",
		component: CoursesComponent,
	},
	{
		path: ":courseId",
		component: CourseComponent,
		children: [
			{
				path: "",
				component: CourseInfoComponent,
			},
			{
				path: "lesson",
				component: LessonsComponent,
				canActivate: [CourseGuard],
			},
			{
				path: "lesson/:lessonId",
				component: LessonsComponent,
				canActivate: [CourseGuard],
			},
		],
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class CourseRoutingModule {}
