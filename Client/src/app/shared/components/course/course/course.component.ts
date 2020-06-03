import { Component, OnInit, Input } from '@angular/core';

import { AuthService } from 'src/app/core/services/auth.service';

import { Course } from 'src/app/shared/models/course/course';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {
  @Input() course: Course = new Course();

  constructor(public authService: AuthService) { }

  ngOnInit(): void {
  }

}
