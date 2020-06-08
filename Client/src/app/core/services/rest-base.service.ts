import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";

import { Cacheable } from "ngx-cacheable";

import { IModel } from "src/app/shared/models/imodel";
import { Paged } from "src/app/shared/models/paged";

import { environment } from "src/environments/environment";

export abstract class RestBaseService<TModel extends IModel> {
	// Can't retrieve meta about Tmodel therefore its require to specify controller directly
	protected abstract controllerName: string;

	public activeModel: TModel;

	constructor(protected http: HttpClient) {}

	// @Cacheable()
	getAll(filters: any): Observable<Paged<TModel>> {
		return this.http.get<Paged<TModel>>(`${environment.apiUrl}/${this.controllerName}`, { params: filters });
	}

	// @Cacheable()
	get(id: string): Observable<TModel> {
		return this.http.get<TModel>(`${environment.apiUrl}/${this.controllerName}/${id}`).pipe(tap((model) => this.setActiveModel(model)));
	}

	post(model: TModel | FormData): Observable<TModel> {
		return this.http.post<TModel>(`${environment.apiUrl}/${this.controllerName}`, model).pipe(tap((model) => this.setActiveModel(model)));
	}

	put(id: string, model: TModel | FormData): Observable<TModel> {
		return this.http.put<TModel>(`${environment.apiUrl}/${this.controllerName}/${id}`, model).pipe(tap((model) => this.setActiveModel(model)));
	}

	delete(id: string) {
		return this.http.delete(`${environment.apiUrl}/${this.controllerName}/${id}`).pipe(
			tap(() => {
				if (id == this.activeModel?.id) this.setActiveModel(null);
			})
		);
	}

	public setActiveModel(model: TModel) {
		this.activeModel = model;
	}
}
