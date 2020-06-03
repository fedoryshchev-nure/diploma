import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { SharedModule } from "../shared/shared.module";
import { CourseRoutingModule } from "./course-routing.module";

import { CoursesComponent } from "./pages/courses/courses.component";
import { CourseComponent } from "./pages/course/course.component";
import { CourseInfoComponent } from "./pages/course-info/course-info.component";
import { LessonsComponent } from './pages/lessons/lessons.component';

@NgModule({
	declarations: [CoursesComponent, CourseComponent, CourseInfoComponent, LessonsComponent],
	imports: [CommonModule, SharedModule, CourseRoutingModule],
})
export class CourseModule {}
