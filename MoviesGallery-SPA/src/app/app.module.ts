import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutesModule } from './app-routes.module';
import { SharedModule } from './modules/shared.module';
import { CoreModule } from './modules/core.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutesModule,
    SharedModule,
    CoreModule,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
