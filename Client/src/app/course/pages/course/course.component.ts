import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

import { CourseService } from 'src/app/core/services/courses.service';

import { Course } from 'src/app/shared/models/course/course';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-course-page',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {
  public course$: Observable<Course>;

  constructor(
    private route: ActivatedRoute,
    private courseService: CourseService) { }

  ngOnInit(): void {
    const courseId = this.route.snapshot.paramMap.get("courseId");
    this.course$ = this.courseService.get(courseId).pipe(
      map(course => Object.assign(new Course(), course))
    ); // Getter is not mapped unless you assign it intentioally 
  }

}
