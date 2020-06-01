import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { EditCourseComponent } from './pages/edit-course/edit-course.component';
import { EditComponent } from './pages/courses/edit/edit.component';
import { AddCourseComponent } from './pages/add-course/add-course.component';


@NgModule({
  declarations: [EditCourseComponent, EditComponent, AddCourseComponent],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
