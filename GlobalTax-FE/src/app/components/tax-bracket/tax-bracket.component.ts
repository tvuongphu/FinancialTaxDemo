import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FormArray, FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { ApiClientService } from '../../services/api.client.service'
import { TaxBracketDetail } from '../../shared/models/responseDto';
import { Country } from '../../shared/models/responseDto';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-tax-bracket',
  standalone: true,
  imports: [FormsModule, CommonModule, ReactiveFormsModule],
  templateUrl: './tax-bracket.component.html',
})

export class TaxBracketFormComponent {
  form: FormGroup;
  countries: Country[] = [];
  submitted = false;
 
  constructor(private fb: FormBuilder, private apiClientService: ApiClientService) {
    this.form = this.fb.group({
      countryCode: ['', Validators.required],
      brackets: this.fb.array([
        this.fb.group({
          level: [null, Validators.required],
          limit: [null, Validators.required],
          rate: [null, [Validators.required, Validators.min(0), Validators.max(1)]]
        })
      ])
    });
  }

  ngOnInit(): void {
    this.loadCountries();
  }

  async loadCountries(): Promise<void> {
    let re = await firstValueFrom(this.apiClientService.GetAllCountries());
    this.countries = re.country;
  }
 
  onCountryChange(event: Event) {
    const select = event.target as HTMLSelectElement;
    const countryCode = select.value.toUpperCase();

    if(!countryCode) return;

    this.loadBrackets(countryCode);
  }

  get brackets(): FormArray {
    return this.form.get('brackets') as FormArray;
  }
 
  private loadBrackets(countryCode: string) {
    this.brackets.clear();

    this.form.get('countryCode')?.setValue(countryCode, { emitEvent: false });

    this.apiClientService.getBracketByCountryCode(countryCode).subscribe(re => {
      if (re.success) {
        re.brackets.forEach(b => {
          this.brackets.push(this.createBracketGroup(b));
        });
      } else {
        this.addBracket(); // add one empty row if none exist
        alert(re.response);
      }
    });
  }

  private createBracketGroup(bracket?: TaxBracketDetail): FormGroup {
    return this.fb.group({
      // id: [bracket?.id || null], // optional, for updates
      level: [bracket?.level || null, Validators.required],
      limit: [bracket?.limit || null, Validators.required],
      rate: [bracket?.rate || null, Validators.required]
    });
  }

  addBracket() {
    this.brackets.push(this.createBracketGroup());
  }
 
  removeBracket(index: number) {
    this.brackets.removeAt(index);
  }

  async save() {
    if(confirm('Do you want to save the Tax Brackets?' ))
    {
      this.submitted = true;
      if (this.form.invalid) return;
  
      const countryCode = this.form.value.countryCode.toUpperCase();
      const brackets: TaxBracketDetail[] = this.form.value.brackets.map((b: any) => ({
        ...b
      }));
      
      var validationResult = await firstValueFrom( this.apiClientService.ValidateTaxBrackets(countryCode, brackets));

      var errors: string = '';
      if(validationResult.success === false) {
        validationResult.response.forEach(item => {
          errors += item + '\n';
        });
        alert(errors);
        return;
      }

      var updateResult = await firstValueFrom(this.apiClientService.UpdateTaxBrackets(countryCode, brackets));
        if(updateResult.success)
            alert('Brackets saved successfully!');
        else
          alert(updateResult.response);
    }
  }
}