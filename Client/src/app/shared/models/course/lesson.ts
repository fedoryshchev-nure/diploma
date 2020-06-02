export class Lesson {
    constructor(
        public id: string,
        public title: string,
        public text: string,
        // public image: any, // Used to post files
        public imageName: string,
        public order?: number,
    ) { }
}
