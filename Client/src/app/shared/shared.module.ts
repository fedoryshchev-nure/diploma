import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatPaginatorModule } from "@angular/material/paginator";
import { DragDropModule } from "@angular/cdk/drag-drop";

import { NgxFileDropModule } from "ngx-file-drop";

import { ErrorsComponent } from "./components/alerts/errors/errors.component";

import { ImageComponent } from "./components/controls/image/image.component";

import { CoursesListComponent } from "./components/course/courses-list/courses-list.component";
import { CourseComponent } from "./components/course/course/course.component";
import { CoursesListItemComponent } from "./components/course/courses-list-item/courses-list-item.component";
import { LessonsListComponent } from "./components/course/lesson/lessons-list/lessons-list.component";
import { LessonsListItemComponent } from "./components/course/lesson/lessons-list-item/lessons-list-item.component";
import { RecommendationsListItemComponent } from "./components/recommendations/recommendations-list-item/recommendations-list-item.component";
import { RecommendationsListComponent } from "./components/recommendations/recommendations-list/recommendations-list.component";
import { EditCourseComponent } from "./components/course/edit-course/edit-course.component";
import { EditLessonComponent } from "./components/course/lesson/edit-lesson/edit-lesson.component";

@NgModule({
	declarations: [
		CoursesListComponent,
		CoursesListItemComponent,
		CourseComponent,
		LessonsListComponent,
		LessonsListItemComponent,
		ImageComponent,
		ErrorsComponent,
		RecommendationsListItemComponent,
		RecommendationsListComponent,
		EditCourseComponent,
		EditLessonComponent,
	],
	imports: [CommonModule, RouterModule, MatPaginatorModule, DragDropModule, FormsModule, ReactiveFormsModule, NgxFileDropModule],
	exports: [ImageComponent, ErrorsComponent, CoursesListComponent, CourseComponent, LessonsListComponent, RecommendationsListComponent, EditCourseComponent],
})
export class SharedModule {}
