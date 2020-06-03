import { Course } from "./course/course";

export class User {
	constructor(
		public id: string,
		public email: string,
		public password: string,
		public firstName: string,
		public lastName: string,
		public courses: Course[],
		public token?: string
	) {}
}
