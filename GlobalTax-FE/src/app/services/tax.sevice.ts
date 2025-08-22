// src/app/services/tax.service.ts
import { Injectable } from '@angular/core';
import { TaxResult } from '../shared/models/responseDto'
import { ApiClientService } from './api.client.service';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class TaxService {

  constructor(private ApiClientService: ApiClientService) { }

  async calculateTax(countryCode: string, income: number): Promise<TaxResult> {

    var response = await firstValueFrom(this.ApiClientService.getBracketByCountryCode(countryCode));
    
     if(response.success === false) {
        alert(response.response);
        return {
          totalTax: 0,
          effectiveRate: 0,
          breakdown: []
        };
      }

      let remaining = income;
      let lastLimit = 0;
      let totalTax = 0;
      const breakdown: { range: string; rate: number; taxedAmount: number; taxOwed: number }[] = [];

      for (const bracket of response.brackets) {
        if (remaining <= 0) break;

        const taxable = Math.min(remaining, bracket.limit - lastLimit);
        const taxOwed = taxable * bracket.rate;

        breakdown.push({
          range: `${lastLimit + 1} – ${bracket.limit === Infinity ? '∞' : bracket.limit}`,
          rate: bracket.rate,
          taxedAmount: taxable,
          taxOwed: taxOwed
        });

        totalTax += taxOwed;
        remaining -= taxable;
        lastLimit = bracket.limit;
      }

      return {
        totalTax,
        effectiveRate: income > 0 ? totalTax / income : 0,
        breakdown
      };
  }


  // calculateTax(countryCode: string, income: number): Observable<TaxResult> {
  //   return this.ApiClientService.getBracketByCountryCode(countryCode).pipe(
  //     map((re) => {

  //       if(re.success === false) {
  //         alert(re.response);
  //       }

  //       let remaining = income;
  //       let lastLimit = 0;
  //       let totalTax = 0;
  //       const breakdown: { range: string; rate: number; taxedAmount: number; taxOwed: number }[] = [];
  
  //       for (const bracket of re.brackets) {
  //         if (remaining <= 0) break;
  
  //         const taxable = Math.min(remaining, bracket.limit - lastLimit);
  //         const taxOwed = taxable * bracket.rate;
  
  //         breakdown.push({
  //           range: `${lastLimit + 1} – ${bracket.limit === Infinity ? '∞' : bracket.limit}`,
  //           rate: bracket.rate,
  //           taxedAmount: taxable,
  //           taxOwed: taxOwed
  //         });
  
  //         totalTax += taxOwed;
  //         remaining -= taxable;
  //         lastLimit = bracket.limit;
  //       }
  
  //       return {
  //         totalTax,
  //         effectiveRate: income > 0 ? totalTax / income : 0,
  //         breakdown
  //       };
  //     })
  //   );
  // }
}
