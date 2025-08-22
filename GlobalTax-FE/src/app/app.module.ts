import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
 
import { AppRoutingModule } from '../app/app-routing.module';  // ✅ add this
import { AppComponent } from '../app/app.component';
import { HttpClientModule } from '@angular/common/http';
 
@NgModule({
  declarations: [
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,  // ✅ import here
    AppComponent,       // ✅ import standalone component here
    HttpClientModule
  ],
  providers: [],
})
export class AppModule { }

 