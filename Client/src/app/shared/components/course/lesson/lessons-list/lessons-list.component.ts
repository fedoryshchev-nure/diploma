import { Component, OnInit, Input, OnChanges } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";

import { Lesson } from "src/app/shared/models/course/lesson";

@Component({
	selector: "app-lessons-list",
	templateUrl: "./lessons-list.component.html",
	styleUrls: ["./lessons-list.component.scss"],
})
export class LessonsListComponent implements OnInit, OnChanges {
	@Input() lessons: Lesson[] = [];

	constructor(private router: Router, private route: ActivatedRoute) {}

	ngOnInit(): void {}

	ngOnChanges() {
		if (this.lessons && this.lessons.length && !this.route.snapshot.paramMap.get("lessonId"))
			this.router.navigate([this.lessons[0].id], { relativeTo: this.route });
	}
}
