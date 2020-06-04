import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

import { RestBaseService } from "./rest-base.service";

import { Lesson } from "src/app/shared/models/course/lesson";

@Injectable({
	providedIn: "root",
})
export class LessonService extends RestBaseService<Lesson> {
	protected controllerName = "lesson";

	constructor(httpClient: HttpClient) {
		super(httpClient);
	}
}
