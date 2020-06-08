import { IModel } from "../imodel";
import { Lesson } from "./lesson";

import { Placeholders } from "../../helpers/defaults/placeholders";

import { environment } from "src/environments/environment";

export class Course implements IModel {
	constructor(
		public id: string = "",
		public title: string = "",
		public description: string = "",
		// public image: any, // Used to post files
		public imageName: string = "",
		public lessons: Lesson[] = []
	) {}

	public get imageUrl() {
		const imageLink = this.imageName ? `${environment.apiImageUrl}/${this.imageName}` : new Placeholders().imagePlaceholder;
		return imageLink;
	}
}
