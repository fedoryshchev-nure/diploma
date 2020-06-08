import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { FormGroup, FormGroupDirective } from "@angular/forms";
import { Observable } from "rxjs";
import { NgxFileDropEntry, FileSystemFileEntry } from "ngx-file-drop";

@Component({
	selector: "app-edit-lesson",
	templateUrl: "./edit-lesson.component.html",
	styleUrls: ["./edit-lesson.component.scss"],
	providers: [],
})
export class EditLessonComponent implements OnInit {
	@Input() form: FormGroupDirective;
	@Input() editLessonFormGroup: FormGroup;
	@Input() removable = true;

	@Output() remove = new EventEmitter();

	title = "title";
	text = "text";
	image = "image";

	errors$: Observable<string[]>;

	constructor() {}

	ngOnInit(): void {}

	public onFileChange(files: NgxFileDropEntry[]) {
		const fileEntry = files[0].fileEntry as FileSystemFileEntry;
		fileEntry.file((file: File) => {
			this.editLessonFormGroup.patchValue({
				image: file,
			});
		});
	}
}
