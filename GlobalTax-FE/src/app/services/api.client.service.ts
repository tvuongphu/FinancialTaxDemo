// src/app/services/tax.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ValidationResponseDto, UpdateBracketResponseDto, GetTaxBracketResponseDto, TaxBracketDetail, GetCountryResponseDto } from '../shared/models/responseDto';

@Injectable({
  providedIn: 'root'
})

export class ApiClientService {

  private baseUrl = 'https://localhost:5129/api/v1';
  private taxClientUrl = this.baseUrl + '/tax';
  private countryClientUrl = this.baseUrl + '/country';

  constructor(private http: HttpClient) { }

  // Tax
  getBracketByCountryCode(countryCode: string): Observable<GetTaxBracketResponseDto> {
    var url = `${this.taxClientUrl}/GetTaxBracketByCountry/${countryCode}`;
    return this.http.get<GetTaxBracketResponseDto>(url);
  }

  ValidateTaxBrackets(countryCode: string, brackets: TaxBracketDetail[]): Observable<ValidationResponseDto> {
    const url = `${this.taxClientUrl}/Validate?countryCode=${countryCode}`;
    return this.http.post<ValidationResponseDto>(url, brackets);
  }

  UpdateTaxBrackets(countryCode: string, brackets: TaxBracketDetail[]): Observable<UpdateBracketResponseDto> {
    const url = `${this.taxClientUrl}/UpdateTaxBrackets?countryCode=${countryCode}`;
    return this.http.post<UpdateBracketResponseDto>(url, brackets);
  }

  // Country
  GetAllCountries(): Observable<GetCountryResponseDto> {
    var url = `${this.countryClientUrl}/GetAll`;
    return this.http.get<GetCountryResponseDto>(url);
  }

}
