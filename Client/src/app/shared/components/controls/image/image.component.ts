import { Component, OnInit, Input } from "@angular/core";

import { Placeholders } from "src/app/shared/helpers/defaults/placeholders";

@Component({
	selector: "app-img",
	templateUrl: "./image.component.html",
	styleUrls: ["./image.component.scss"],
})
export class ImageComponent implements OnInit {
	@Input() src: string;

	constructor() {}

	ngOnInit(): void {}

	getSrcOrDefault(): string {
		return this.src || new Placeholders().imagePlaceholder;
	}
}
