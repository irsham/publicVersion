import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Country } from '../models';

@Injectable({
  providedIn: 'root',
})
export class TableService {
  private baseUrl: string;
  constructor(private httpClient: HttpClient) {
    this.baseUrl = 'https://localhost:44394/';
  }

  private genURI = (apiPart: string) => `${this.baseUrl}${apiPart}`;
  private genApiUri = (apiPart: string) => this.genURI(`api/${apiPart}`);

  public getCountryList() {
    return this.httpClient.get<Country[]>(this.genApiUri('CountryList')).toPromise();
  }
}
