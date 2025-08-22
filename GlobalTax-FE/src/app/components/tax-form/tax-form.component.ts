// src/app/tax-form/tax-form.component.ts
import { Component } from '@angular/core';
import { ApiClientService } from '../../services/api.client.service'
import { TaxService } from '../../services/tax.sevice'
import { TaxResult } from '../../shared/models/responseDto';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Country } from '../../shared/models/responseDto';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-tax-form',
  templateUrl: './tax-form.component.html',
  standalone: true,
  imports: [FormsModule, CommonModule]
})
export class TaxFormComponent {
  countryCode: string = '';
  currency: string = '';
  countries: Country[] = [];
  income: number = 0;
  incomeError: boolean = false;
  taxResult: TaxResult | null = null;

  constructor(private taxService: TaxService, private apiClientService: ApiClientService) {}

  ngOnInit(): void {
    this.loadCountries();
  }

  async loadCountries(): Promise<void> {
    let re = await firstValueFrom(this.apiClientService.GetAllCountries());
    this.countries = re.country;
  }

    async calculateTax(): Promise<void> {
    if (this.income !== null && this.income >= 0) {
      this.taxResult = await this.taxService.calculateTax(this.countryCode, this.income);
    } else {
      this.taxResult = null;
    }
  }

  onCountryChange(value: string) {
    this.currency = this.countries.find(c => c.countryCode === value)?.currency || '';
  }

  onIncomeChange(value: string) {
      const raw = value.replace(/,/g, '');
      const parsed = Number(raw);
  
      if (isNaN(parsed) || parsed <= 0) {
        this.incomeError = true;
        this.income = 0;
      } else {
        this.incomeError = false;
        this.income = parsed;
      }
    }
}
 