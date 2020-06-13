import { Component, OnInit, Output, EventEmitter, Input, OnChanges } from "@angular/core";
import { Validators, FormBuilder, FormArray, FormGroup } from "@angular/forms";
import { CdkDragDrop } from "@angular/cdk/drag-drop";
import { FileSystemFileEntry, NgxFileDropEntry } from "ngx-file-drop";

import { CourseService } from "src/app/core/services/courses.service";

import { Course } from "src/app/shared/models/course/course";
import { Lesson } from "src/app/shared/models/course/lesson";

@Component({
	selector: "app-edit-course",
	templateUrl: "./edit-course.component.html",
	styleUrls: ["./edit-course.component.scss"],
})
export class EditCourseComponent implements OnInit, OnChanges {
	@Input() default = new Course();
	@Output() formSubmitted = new EventEmitter<any>();
	@Output() remove = new EventEmitter<any>();

	title = "title";
	description = "description";
	image = "image";
	lessons = "lessons";

	editCourseForm = this.fb.group({
		title: [this.default.title, [Validators.required]],
		description: [this.default.description, [Validators.required]],
		image: [this.default.imageName, [Validators.required]],
		lessons: this.fb.array(this.default.lessons),
	});

	constructor(private fb: FormBuilder) {}

	ngOnInit(): void {}

	ngOnChanges() {
		if (this.default) {
			let defaultImage = { name: this.default.imageName };
			this.editCourseForm = this.fb.group({
				title: [this.default.title, [Validators.required]],
				description: [this.default.description, [Validators.required]],
				image: [defaultImage, [Validators.required]],
				lessons: this.fb.array([]),
			});
			this.default.lessons.forEach((lesson) => {
				this.addLesson(lesson);
			});
		}
	}

	public get lessonControls() {
		return this.editCourseForm.controls[this.lessons] as FormArray;
	}

	public getLessonAsFormGroup(i) {
		return this.lessonControls.controls[i] as FormGroup;
	}

	public onFileChange(files: NgxFileDropEntry[]) {
		const fileEntry = files[0].fileEntry as FileSystemFileEntry;
		fileEntry.file((file: File) => {
			this.editCourseForm.patchValue({
				image: file,
			});
		});
	}

	public addLesson(lesson = new Lesson()) {
		const editLessonGruop = this.fb.group({
			title: [lesson.title, [Validators.required]],
			text: [lesson.text, [Validators.required]],
			image: [{ name: lesson.imageName?.substring(37) }],
		});
		this.lessonControls.push(editLessonGruop);
	}

	public removeLesson(i: number) {
		this.lessonControls.removeAt(i);
	}

	public drop(event: CdkDragDrop<string[]>) {
		const item = this.lessonControls.at(event.previousIndex);
		this.lessonControls.removeAt(event.previousIndex);
		this.lessonControls.insert(event.currentIndex, item);
	}

	public onSubmit($event): void {
		$event.preventDefault();

		if (this.editCourseForm.valid) {
			this.formSubmitted.emit(this.editCourseForm.value);
		}
	}
}
