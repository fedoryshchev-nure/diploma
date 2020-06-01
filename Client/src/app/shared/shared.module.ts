import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CourseComponent } from './components/course/course/course.component';
import { CoursesListItemComponent } from './components/course/courses-list-item/courses-list-item.component';
import { CoursesListComponent } from './components/course/courses-list/courses-list.component';

@NgModule({
  declarations: [CourseComponent, CoursesListItemComponent, CoursesListComponent],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
