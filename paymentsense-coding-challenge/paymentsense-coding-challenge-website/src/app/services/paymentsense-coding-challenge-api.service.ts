import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class PaymentsenseCodingChallengeApiService {
  private baseUrl: string;
  constructor(private httpClient: HttpClient) {
    this.baseUrl = 'https://localhost:44394/';
  }

  private genURI = (apiPart: string) => `${this.baseUrl}${apiPart}`;

  public getHealth(): Observable<string> {
    return this.httpClient.get(this.genURI('health'), {
      responseType: 'text',
    });
  }
}
