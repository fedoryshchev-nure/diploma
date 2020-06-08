import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Observable, of } from "rxjs";

import { ToastrService } from "ngx-toastr";
import { objectToFormData } from "object-to-formdata";

import { CourseService } from "src/app/core/services/courses.service";

import { Course } from "src/app/shared/models/course/course";

@Component({
	selector: "app-admin-add-course",
	templateUrl: "./add-course.component.html",
	styleUrls: ["./add-course.component.scss"],
})
export class AddCourseComponent implements OnInit {
	public course = new Course();

	errors$: Observable<string[]>;

	constructor(private courseService: CourseService, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) {}

	ngOnInit(): void {}

	public onSubmit(formValues): void {
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
			.post(fd)
			.toPromise()
			.then((course) => {
				this.toastr.success("Created");
				this.router.navigate(["..", course.id, "edit"], { relativeTo: this.route });
			})
			.catch((err) => (this.errors$ = of([err && err.error && err.error.Message])));
	}

	public onRemove() {
		const confirmed = window.confirm("Are you sure?");
		if (confirmed) {
			this.course = new Course();
		}
	}
}
