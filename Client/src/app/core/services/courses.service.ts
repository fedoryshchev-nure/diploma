import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Cacheable } from "ngx-cacheable";

import { RestBaseService } from "./rest-base.service";

import { Course } from "src/app/shared/models/course/course";

import { environment } from "src/environments/environment";

@Injectable({
	providedIn: "root",
})
export class CourseService extends RestBaseService<Course> {
	protected controllerName = "course";

	constructor(httpClient: HttpClient) {
		super(httpClient);
	}

	@Cacheable()
	public getRecommendations() {
		return this.http.get<Course[]>(`${environment.apiUrl}/${this.controllerName}/recommendations`);
	}
}
