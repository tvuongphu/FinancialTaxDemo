import { Routes } from '@angular/router';
import { TaxFormComponent } from './components/tax-form/tax-form.component';
import { TaxBracketFormComponent } from './components/tax-bracket/tax-bracket.component';
 
export const routes: Routes = [
    { path: '', component: TaxBracketFormComponent },    
    { path: 'brackets', component: TaxBracketFormComponent },   
    { path: 'tax', component: TaxFormComponent },
    { path: '**', redirectTo: '' }              
];