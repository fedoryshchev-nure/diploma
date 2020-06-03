import { Lesson } from './lesson';
import { environment } from 'src/environments/environment';

export class Course {
    constructor(
        public id: string = "",
        public title: string = "",
        public description: string = "",
        // public image: any, // Used to post files
        public imageName: string = "",
        public lessons: Lesson[] = [],
    ) { }

    public get imageUrl() {
        const imageLink = this.imageName
            ? `${environment.apiImageUrl}/${this.imageName}`
            : "assets/images/default-placeholder.png";
        return imageLink
    }
}
