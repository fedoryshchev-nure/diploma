import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";

import { CourseService } from "src/app/core/services/courses.service";

import { Lesson } from "src/app/shared/models/course/lesson";

@Component({
	selector: "app-lessons",
	templateUrl: "./lessons.component.html",
	styleUrls: ["./lessons.component.scss"],
})
export class LessonsComponent implements OnInit {
	public lessons$: Observable<Lesson[]>;
	public courseId = "";

	constructor(private route: ActivatedRoute, private courseService: CourseService) {}

	ngOnInit(): void {
		this.courseId = this.route.parent.snapshot.paramMap.get("courseId");
		this.lessons$ = this.courseService.get(this.courseId).pipe(
			map((course) => course.lessons),
			map((lessons) => lessons.map((lesson) => Object.assign(new Lesson(), lesson))) // Getter is not mapped unless you assign it intentioally
		);
	}
}
