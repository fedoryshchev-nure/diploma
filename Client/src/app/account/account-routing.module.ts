import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditProfileComponent } from './pages/edit-profile/edit-profile.component';
import { CoursesComponent } from './pages/courses/courses.component';

const routes: Routes = [
  {
    path: "edit-profile",
    component: EditProfileComponent
  },
  {
    path: "courses",
    component: CoursesComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
