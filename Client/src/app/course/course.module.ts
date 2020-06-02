import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '../shared/shared.module';
import { CourseRoutingModule } from './course-routing.module';

import { CoursesComponent } from './pages/courses/courses.component';
import { CourseComponent } from './pages/course/course.component';

@NgModule({
  declarations: [CoursesComponent, CourseComponent],
  imports: [
    CommonModule,
    SharedModule,
    CourseRoutingModule
  ]
})
export class CourseModule { }
