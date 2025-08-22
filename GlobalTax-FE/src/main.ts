import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes';
import { TaxService } from './app/services/tax.sevice';
import { provideHttpClient  } from '@angular/common/http';
 
bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes), 
    TaxService,
    provideHttpClient()
  ],
    
}).catch(err => console.error(err));