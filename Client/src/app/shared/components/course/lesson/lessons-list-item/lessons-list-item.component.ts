import { Component, OnInit, Input } from "@angular/core";

import { Lesson } from "src/app/shared/models/course/lesson";

@Component({
	selector: "app-lessons-list-item",
	templateUrl: "./lessons-list-item.component.html",
	styleUrls: ["./lessons-list-item.component.scss"],
})
export class LessonsListItemComponent implements OnInit {
	@Input() lesson: Lesson;

	constructor() {}

	ngOnInit(): void {}
}
