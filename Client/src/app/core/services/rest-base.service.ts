import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Paged } from 'src/app/shared/models/paged';

export abstract class RestBaseService<TModel> {
  // Can't retrieve meta about Tmodel therefore its require to specify controller directly
  protected abstract controllerName: String;

  constructor(
    protected http: HttpClient,
  ) { }

  getAll(filters: any): Observable<Paged<TModel>> {
    return this.http.get<Paged<TModel>>(`${environment.apiUrl}/${this.controllerName}`,
      { params: filters });
  }

  get(id: string): Observable<TModel> {
    return this.http.get<TModel>(`${environment.apiUrl}/${this.controllerName}/${id}`);
  }

  post(model: TModel): Observable<TModel> {
    return this.http.post<TModel>(`${environment.apiUrl}/${this.controllerName}`,
      model);
  }

  put(id: string, model: TModel): Observable<TModel> {
    return this.http.post<TModel>(`${environment.apiUrl}/${this.controllerName}`,
      model,
      { params: { id } });
  }

  delete(id: string) {
    return this.http.delete(`${environment.apiUrl}/${this.controllerName}`,
      { params: { id } });
  }
}
