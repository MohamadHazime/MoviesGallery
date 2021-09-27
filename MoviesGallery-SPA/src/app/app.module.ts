import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutesModule } from './app-routes.module';
import { MoviesModule } from './modules/movies.module';
import { TVShowsModule } from './modules/tv-shows.module';
import { SharedModule } from './modules/shared.module';
import { HomeModule } from './modules/home.module';
import { CoreModule } from './modules/core.module'

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutesModule,
    HomeModule,
    MoviesModule,
    TVShowsModule,
    SharedModule,
    CoreModule,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
