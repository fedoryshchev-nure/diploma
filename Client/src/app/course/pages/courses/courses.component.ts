import { Component, OnInit } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';

import { CoursesService } from 'src/app/core/services/courses.service';

import { Course } from 'src/app/shared/models/course/course';
import { Filter } from 'src/app/shared/helpers/defaults/filter';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss'],
})
export class CoursesComponent implements OnInit {
  public courses$: Observable<Course[]>;
  public total$: Observable<number>;

  public filters = new BehaviorSubject(new Filter());

  constructor(private coursesService: CoursesService) { }

  ngOnInit(): void {
    this.filters.subscribe(filters => {
      const tmp = this.coursesService.getAll(filters);
      this.courses$ = tmp.pipe(map(x => x.items));
      this.total$ = tmp.pipe(map(x => x.total));
    })
  }

  updateFilters(newFilters) {
    this.filters.next({
      ...this.filters.getValue(),
      ...newFilters,
      page: newFilters.pageIndex
    });
  }

}
