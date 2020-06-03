import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatPaginatorModule } from '@angular/material/paginator';

import { ErrorsComponent } from './components/alerts/errors/errors.component';

import { ImageComponent } from './components/controls/image/image.component';

import { CoursesListComponent } from './components/course/courses-list/courses-list.component';
import { CourseComponent } from './components/course/course/course.component';
import { CoursesListItemComponent } from './components/course/courses-list-item/courses-list-item.component';
import { LessonsListComponent } from './components/course/lesson/lessons-list/lessons-list.component';
import { LessonsListItemComponent } from './components/course/lesson/lessons-list-item/lessons-list-item.component';

@NgModule({
  declarations: [CoursesListComponent, CoursesListItemComponent, CourseComponent, LessonsListComponent, LessonsListItemComponent, ImageComponent, ErrorsComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatPaginatorModule
  ],
  exports: [ImageComponent, ErrorsComponent, CoursesListComponent, CourseComponent, LessonsListComponent]
})
export class SharedModule { }
