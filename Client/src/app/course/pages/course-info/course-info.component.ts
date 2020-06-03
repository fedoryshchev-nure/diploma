import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";

import { CourseService } from "src/app/core/services/courses.service";
import { UserService } from "src/app/core/services/user.service";

import { Course } from "src/app/shared/models/course/course";

@Component({
	selector: "app-course-info",
	templateUrl: "./course-info.component.html",
	styleUrls: ["./course-info.component.scss"],
})
export class CourseInfoComponent implements OnInit {
	public course$: Observable<Course>;

	constructor(private route: ActivatedRoute, private courseService: CourseService, public userService: UserService) {}

	ngOnInit(): void {
		const courseId = this.route.snapshot.paramMap.get("courseId");
		this.course$ = this.courseService.get(courseId).pipe(map((course) => Object.assign(new Course(), course)));
		// Getter is not mapped unless you assign it intentioally
	}
}
