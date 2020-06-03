import { Component, OnInit } from "@angular/core";

import { UserService } from "src/app/core/services/user.service";

@Component({
	selector: "app-course-page",
	templateUrl: "./course.component.html",
	styleUrls: ["./course.component.scss"],
})
export class CourseComponent implements OnInit {
	constructor(public userService: UserService) {}

	ngOnInit(): void {}
}
