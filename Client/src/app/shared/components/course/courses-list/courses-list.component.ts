import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { Observable } from "rxjs";

import { Course } from "src/app/shared/models/course/course";

@Component({
	selector: "app-courses-list",
	templateUrl: "./courses-list.component.html",
	styleUrls: ["./courses-list.component.scss"],
})
export class CoursesListComponent implements OnInit {
	@Input() courses$: Observable<Course[]>;
	@Input() total$: Observable<number>;
	@Input() pageSize: number;

	@Output() pagingChanged: EventEmitter<{
		pageSize: number;
		pageIndex: number;
	}> = new EventEmitter();

	constructor() {}

	ngOnInit(): void {}
}
