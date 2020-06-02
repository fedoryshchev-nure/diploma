import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CoursesComponent } from './pages/courses/courses.component';
import { CourseComponent } from './pages/course/course.component';
import { LessonComponent } from './pages/lesson/lesson.component';


const routes: Routes = [
  {
    path: "",
    component: CoursesComponent
  },
  {
    path: ":courseId",
    component: CourseComponent
  },
  {
    path: ":courseId/lesson/:lessonId",
    component: LessonComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseRoutingModule { }
