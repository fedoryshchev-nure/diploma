import { Component, OnInit } from "@angular/core";
import { Observable, of } from "rxjs";
import { ActivatedRoute, Router } from "@angular/router";

import { ToastrService } from "ngx-toastr";
import { objectToFormData } from "object-to-formdata";

import { CourseService } from "src/app/core/services/courses.service";

import { Course } from "src/app/shared/models/course/course";

@Component({
	selector: "app-admin-edit-course",
	templateUrl: "./edit-course.component.html",
	styleUrls: ["./edit-course.component.scss"],
})
export class EditCourseComponent implements OnInit {
	public course$: Observable<Course> = new Observable<Course>();

	private courseId: string;

	constructor(public courseService: CourseService, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) {}

	ngOnInit(): void {
		this.courseId = this.route.snapshot.paramMap.get("courseId");
		this.course$ = this.courseService.activeModel ? of(this.courseService.activeModel) : this.courseService.get(this.courseId);
	}

	public onSubmit(formValues) {
		const dto = {
			title: formValues.title,
			description: formValues.description,
			imageName: formValues.image.name,
			lessons: formValues.lessons.map((lesson) => ({
				title: lesson.title,
				text: lesson.text,
				imageName: lesson.image.name,
			})),
			images: [formValues.image, ...formValues.lessons.map((x) => x.image)],
		};
		const fd = objectToFormData(dto, { indices: true });
		fd.delete("images"); // This is required as lib won't map that array properly
		dto.images.forEach((image) => {
			fd.append("images", image);
		});
		this.courseService
			.put(this.courseId, fd)
			.toPromise()
			.then((x) => this.toastr.success("Edited"))
			.catch((x) => this.toastr.error(x.message || "Error occurd"));
	}

	public onRemove() {
		const confirmed = window.confirm("Are you sure?");
		if (confirmed) {
			this.courseService
				.delete(this.courseId)
				.toPromise()
				.then((x) => {
					this.toastr.success("Removed");
					this.router.navigate(["../../add"], { relativeTo: this.route });
				})
				.catch((x) => this.toastr.error(x.message || "Error occurd"));
		}
	}
}
