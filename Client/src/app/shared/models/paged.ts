export class Paged<TModel> {
	constructor(public items: TModel[], public total: number) {}
}
