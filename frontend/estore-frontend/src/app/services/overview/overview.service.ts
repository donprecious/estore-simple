import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { GetOverViewResponse } from './overview-model';

@Injectable({
  providedIn: 'root',
})
export class OverviewService {
  baseUrl = environment.estoreApiUrl;
  constructor(private httpClient: HttpClient) {}

  getOverview(): Observable<GetOverViewResponse> {
    return this.httpClient.get<GetOverViewResponse>(`${this.baseUrl}/overview`);
  }
}
