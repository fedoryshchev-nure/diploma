import { Component, OnInit, Input } from "@angular/core";
import { Course } from "src/app/shared/models/course/course";

@Component({
	selector: "app-recommendations-list",
	templateUrl: "./recommendations-list.component.html",
	styleUrls: ["./recommendations-list.component.scss"],
})
export class RecommendationsListComponent implements OnInit {
	@Input() recommendations: Course[] = [];

	constructor() {}

	ngOnInit(): void {}
}
