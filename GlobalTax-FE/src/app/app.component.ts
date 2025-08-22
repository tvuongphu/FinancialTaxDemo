import { Component } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';
 
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink],   // ✅ router-outlet is standalone too
  template: `
    <div class="container">
      <h1>Tax Application</h1>
      <nav>
        <a routerLink="/brackets">Tax Brackets</a> |
        <a routerLink="/tax">Tax Calculator</a>
      </nav>
      <hr>
      <router-outlet></router-outlet>
    </div>
  `
})
export class AppComponent {}