import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddCourseComponent } from './pages/add-course/add-course.component';
import { EditCourseComponent } from './pages/edit-course/edit-course.component';


const routes: Routes = [
  {
    path: "courses/add",
    component: AddCourseComponent
  },
  {
    path: "courses/:courseId/edit",
    component: EditCourseComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
