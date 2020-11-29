import { Injectable } from '@angular/core';
import { Country } from '../models';

@Injectable({
  providedIn: 'root',
})
export class MockTableService {
  public getCountryList() {
    return [
      {
        alpha3Code: 'alpha3Code',
        borders: ['alpha3Code'],
        capital: 'capital',
        currencies: [{ name: 'curName', code: 'curCode', symbol: 's' }],
        flag: 'f',
        languages: [
          {
            iso639_1: 'Iso639_1',
            iso639_2: 'Iso639_2',
            name: 'langName',
            nativeName: 'NativeName',
          },
        ],
        name: 'country name',
        population: 234,
        timezones: ['UTC+0'],
      } as Country,
    ];
  }
}
