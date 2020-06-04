import { Component, OnInit, OnDestroy } from "@angular/core";
import { Observable, BehaviorSubject, Subscription } from "rxjs";
import { map } from "rxjs/operators";

import { CourseService } from "src/app/core/services/courses.service";

import { Course } from "src/app/shared/models/course/course";
import { Filter } from "src/app/shared/helpers/defaults/filter";

@Component({
	selector: "app-courses",
	templateUrl: "./courses.component.html",
	styleUrls: ["./courses.component.scss"],
})
export class CoursesComponent implements OnInit, OnDestroy {
	public courses$: Observable<Course[]>;
	public total$: Observable<number>;
	public recommendations$: Observable<Course[]>;

	public filters = new BehaviorSubject(new Filter());

	private filtersSubscription: Subscription;

	constructor(private courseService: CourseService) {}

	ngOnInit(): void {
		this.filtersSubscription = this.filters.subscribe((filters) => {
			const tmp = this.courseService.getAll(filters);
			this.courses$ = tmp.pipe(map((x) => x.items.map((course) => Object.assign(new Course(), course)))); // Getter is not mapped unless you assign it intentioally
			this.total$ = tmp.pipe(map((x) => x.total));
		});
		this.recommendations$ = this.courseService.getRecommendations().pipe(
			map((x) => x.map((course) => Object.assign(new Course(), course))) // Getter is not mapped unless you assign it intentioally
		);
	}

	ngOnDestroy() {
		this.filtersSubscription && this.filtersSubscription.unsubscribe();
	}

	updateFilters(newFilters) {
		this.filters.next({
			...this.filters.getValue(),
			...newFilters,
		});
	}
}
