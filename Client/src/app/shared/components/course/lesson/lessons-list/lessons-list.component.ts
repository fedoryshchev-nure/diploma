import { Component, OnInit, Input, OnChanges, OnDestroy } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Subscription } from "rxjs";

import { Lesson } from "src/app/shared/models/course/lesson";

@Component({
	selector: "app-lessons-list",
	templateUrl: "./lessons-list.component.html",
	styleUrls: ["./lessons-list.component.scss"],
})
export class LessonsListComponent implements OnInit, OnChanges, OnDestroy {
	@Input() lessons: Lesson[] = [];

	public courseId: string;
	public lessonId: string;
	public selectedLesson: Lesson;

	public routeSubscription: Subscription;

	constructor(private router: Router, private route: ActivatedRoute) {}

	ngOnInit(): void {
		this.routeSubscription = this.route.paramMap.subscribe((x) => {
			this.courseId = this.route.parent.snapshot.paramMap.get("courseId");
			this.lessonId = x.get("lessonId");
			if (this.lessons && this.lessonId) {
				this.selectedLesson = this.lessons.find((x) => x.id === this.lessonId);
			}
		});
	}

	ngOnChanges() {
		if (this.lessons && this.lessons.length) {
			this.selectedLesson = this.lessons.find((x) => x.id === this.lessonId) || this.lessons[0];
		}
	}

	ngOnDestroy() {
		if (this.routeSubscription) this.routeSubscription.unsubscribe();
	}

	public get nextLesson() {
		return this.lessons.find((x) => x.order === this.selectedLesson.order + 1)?.id;
	}

	public get prevLesson() {
		return this.lessons.find((x) => x.order === this.selectedLesson.order - 1)?.id;
	}

	public navigateToLesson(lesson: Lesson) {
		this.router.navigate(["lesson", lesson.id], { relativeTo: this.route.parent });
		this.selectedLesson = lesson;
	}

	public completeLesson(lessonId: string) {
		console.log("completing " + lessonId);
		const lesson = this.lessons.find((x) => x.id === lessonId);
		lesson.isCompleted = true;
	}
}
