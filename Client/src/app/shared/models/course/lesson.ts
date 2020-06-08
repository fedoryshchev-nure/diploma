import { IModel } from "../imodel";

import { environment } from "src/environments/environment";

export class Lesson implements IModel {
	constructor(
		public id: string = "",
		public title: string = "",
		public text: string = "",
		// public image: any, // Used to post files
		public imageName: string = "",
		public isCompleted: boolean = false,
		public order?: number
	) {}

	public get imageUrl() {
		const imageLink = this.imageName ? `${environment.apiImageUrl}/${this.imageName}` : "";
		return imageLink;
	}
}
