import { Component, OnInit, Input, OnDestroy, Output, EventEmitter } from "@angular/core";
import { Router } from "@angular/router";
import { Subscription } from "rxjs";

import { UserService } from "src/app/core/services/user.service";

import { Lesson } from "src/app/shared/models/course/lesson";

@Component({
	selector: "app-lessons-list-item",
	templateUrl: "./lessons-list-item.component.html",
	styleUrls: ["./lessons-list-item.component.scss"],
})
export class LessonsListItemComponent implements OnInit, OnDestroy {
	@Input() courseId: string;
	@Input() prevLessonId: string;
	@Input() nextLessonId: string;
	@Input() lesson: Lesson;

	@Output() completeLesson = new EventEmitter<string>();

	private completeLessonSubscription: Subscription;

	constructor(private router: Router, private userService: UserService) {}

	onNextClick() {
		this.completeLessonSubscription = this.userService.completeLesson(this.courseId, this.lesson).subscribe(() => {
			this.completeLesson.emit(this.lesson.id);
			this.tryNavigateToLesson(this.nextLessonId);
		});
	}

	ngOnInit(): void {}

	ngOnDestroy() {
		if (this.completeLessonSubscription) this.completeLessonSubscription.unsubscribe();
	}

	public tryNavigateToLesson(lessonId: string) {
		this.router.navigate(["/course", this.courseId, "lesson", lessonId]);
	}
}
