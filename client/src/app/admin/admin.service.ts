import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IDictionary } from '../shared/models/dictionary';
import { IPagination } from '../shared/models/pagination';
import { map } from 'rxjs/operators';
import { PublisherParams } from '../shared/models/publisherParams';

@Injectable({
  providedIn: 'root',
})
export class AdminService {
  private baseUrl = 'https://localhost:44375/api/';
  constructor(private http: HttpClient) {}

  getPublishers(publisherParams: PublisherParams): Observable<IPagination> {
    let params = new HttpParams();

    if (publisherParams.groupId !== 0) {
      params = params.append('groupId', publisherParams.groupId.toString());
    }

    if (publisherParams.titleId !== 0) {
      params = params.append('titleId', publisherParams.titleId.toString());
    }

    if (publisherParams.statusId !== 0) {
      params = params.append('statusId', publisherParams.statusId.toString());
    }

    if (publisherParams.search) {
      params = params.append('search', publisherParams.search);
    }

    params = params.append('sort', publisherParams.sort);
    params = params.append('pageIndex', publisherParams.pageNumber.toString());
    params = params.append('pageSize', publisherParams.pageSize.toString());

    return this.http
      .get<IPagination>(this.baseUrl + 'publisher', {
        observe: 'response',
        params,
      })
      .pipe(map((response) => response.body));
  }

  getGroups(): Observable<IDictionary[]> {
    return this.http.get<IDictionary[]>(this.baseUrl + 'publisher/groups');
  }

  getTitles(): Observable<IDictionary[]> {
    return this.http.get<IDictionary[]>(this.baseUrl + 'publisher/titles');
  }

  getStatuses(): Observable<IDictionary[]> {
    return this.http.get<IDictionary[]>(this.baseUrl + 'publisher/statuses');
  }
}
