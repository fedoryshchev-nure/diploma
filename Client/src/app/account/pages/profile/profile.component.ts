import { Component, OnInit } from '@angular/core';
import { Observable, BehaviorSubject, of } from 'rxjs';

import { AuthService } from 'src/app/core/services/auth.service';

import { Course } from 'src/app/shared/models/course/course';
import { Filter } from 'src/app/shared/helpers/defaults/filter';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  public courses$: Observable<Course[]>;
  public total$: Observable<number>;

  public filters = new BehaviorSubject(new Filter());

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.filters.subscribe(filters => {
      const courses = this.authService.currentUserValue.courses
        .slice(filters.page * filters.pageSize, filters.pageSize);
      this.courses$ = of(courses);
      this.total$ = of(this.authService.currentUserValue.courses.length)
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
