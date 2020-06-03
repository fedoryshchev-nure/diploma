import { Component, OnInit } from "@angular/core";
import { Observable, BehaviorSubject, of } from "rxjs";
import { map } from "rxjs/operators";

import { UserService } from "src/app/core/services/user.service";

import { Course } from "src/app/shared/models/course/course";
import { Filter } from "src/app/shared/helpers/defaults/filter";

@Component({
	selector: "app-profile",
	templateUrl: "./profile.component.html",
	styleUrls: ["./profile.component.scss"],
})
export class ProfileComponent implements OnInit {
	public courses$: Observable<Course[]>;
	public total$: Observable<number>;

	public filters = new BehaviorSubject(new Filter());

	constructor(private userService: UserService) {}

	ngOnInit(): void {
		this.filters.subscribe((filters) => {
			this.courses$ = this.userService.user$.pipe(
				map((user) => user.courses.slice(filters.page * filters.pageSize, filters.pageSize)),
				map((courses) => courses.map((course) => Object.assign(new Course(), course))) // Getter is not mapped unless you assign it intentioally
			);
			this.total$ = this.userService.user$.pipe(map((user) => user.courses.length));
		});
	}

	updateFilters(newFilters) {
		this.filters.next({
			...this.filters.getValue(),
			...newFilters,
			page: newFilters.pageIndex,
		});
	}
}
