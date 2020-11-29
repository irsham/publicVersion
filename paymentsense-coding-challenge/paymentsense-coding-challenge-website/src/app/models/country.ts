import { Currency } from './currency';
import { Language } from './language';

export interface Country {
  name: string;
  alpha3Code: string;
  flag: string;
  population: number;
  timezones: string[];
  currencies: Currency[];
  capital: string;
  languages: Language[];
  borders: string[];
}
