import { Component, OnInit, Input } from '@angular/core';

import { Course } from 'src/app/shared/models/course/course';

@Component({
  selector: 'app-courses-list-item',
  templateUrl: './courses-list-item.component.html',
  styleUrls: ['./courses-list-item.component.scss']
})
export class CoursesListItemComponent implements OnInit {
  @Input() course: Course;

  constructor() { }

  ngOnInit(): void {
    // Getter is not mapped unless you assign it intentioally 
    this.course = Object.assign(new Course("", "", "", "", []), this.course)
  }

}
