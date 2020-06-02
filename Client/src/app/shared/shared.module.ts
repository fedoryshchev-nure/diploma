import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatPaginatorModule } from '@angular/material/paginator';

import { CoursesListComponent } from './components/course/courses-list/courses-list.component';
import { CourseComponent } from './components/course/course/course.component';
import { CoursesListItemComponent } from './components/course/courses-list-item/courses-list-item.component';

@NgModule({
  declarations: [CoursesListComponent, CoursesListItemComponent, CourseComponent],
  imports: [
    CommonModule,
    MatPaginatorModule
  ],
  exports: [CoursesListComponent]
})
export class SharedModule { }
