import { Component, OnInit, Input } from "@angular/core";

@Component({
	selector: "app-recommendations-list-item",
	templateUrl: "./recommendations-list-item.component.html",
	styleUrls: ["./recommendations-list-item.component.scss"],
})
export class RecommendationsListItemComponent implements OnInit {
	@Input() course;

	constructor() {}

	ngOnInit(): void {}
}
