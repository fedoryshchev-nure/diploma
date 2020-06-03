import { Component, OnInit, Input, OnDestroy } from "@angular/core";

import { UserService } from "src/app/core/services/user.service";
import { CourseService } from "src/app/core/services/courses.service";

import { Course } from "src/app/shared/models/course/course";
import { Subscription } from "rxjs";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
	selector: "app-course",
	templateUrl: "./course.component.html",
	styleUrls: ["./course.component.scss"],
})
export class CourseComponent implements OnInit, OnDestroy {
	@Input() course: Course = new Course();

	attendSubscription: Subscription;

	constructor(private router: Router, private route: ActivatedRoute, public userService: UserService) {}

	public attendCourse() {
		this.attendSubscription = this.userService.attendCourse(this.course.id).subscribe(() => this.router.navigate(["course", this.course.id, "lesson"]));
	}

	ngOnInit(): void {}

	ngOnDestroy(): void {
		if (this.attendSubscription) this.attendSubscription.unsubscribe();
	}
}
