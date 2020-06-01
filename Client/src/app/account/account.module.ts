import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { EditProfileComponent } from './pages/edit-profile/edit-profile.component';
import { CoursesComponent } from './pages/courses/courses.component';


@NgModule({
  declarations: [EditProfileComponent, CoursesComponent],
  imports: [
    CommonModule,
    AccountRoutingModule
  ]
})
export class AccountModule { }
