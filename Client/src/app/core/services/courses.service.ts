import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { RestBaseService } from './rest-base.service';

import { Course } from 'src/app/shared/models/course/course';

@Injectable({
  providedIn: 'root'
})
export class CourseService extends RestBaseService<Course> {
  protected controllerName = "course";

  constructor(httpClient: HttpClient) {
    super(httpClient);
  }
}
