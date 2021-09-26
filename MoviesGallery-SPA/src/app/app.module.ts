import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTabsModule } from '@angular/material/tabs';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTooltipModule } from '@angular/material/tooltip';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatPaginatorModule } from '@angular/material/paginator';
import { NgxPaginationModule } from 'ngx-pagination';

import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { MoviesComponent } from './components/movies/movies.component';
import { ShowListItemComponent } from './components/show-list-item/show-list-item.component';
import { ShowListItemCardComponent } from './components/show-list-item-card/show-list-item-card.component';
import { ShowsListComponent } from './components/shows-list/shows-list.component';
import { TopRatedShowComponent } from './components/top-rated-show/top-rated-show.component';
import { TvShowsComponent } from './components/tv-shows/tv-shows.component';
import { AppRoutesModule } from './routes/app-routes.module';
import { MoviesService } from './services/movies.service';
import { TVShowsService } from './services/tv-shows.service';
import { MoviesResolver } from './resolvers/movies.resolver';
import { TvShowsResolver } from './resolvers/tv-shows.resolver';
import { HomeResolver } from './resolvers/home.resolver';
import { AuthInterceptorService } from './services/auth-interceptor.service';
import { HomeComponent } from './components/home/home.component';
import { PaginationService } from './services/pagination.service';
import { MovieDetailsComponent } from './components/movie-details/movie-details.component';
import { TvShowDetailsComponent } from './components/tv-show-details/tv-show-details.component';
import { MoviesListResolver } from './resolvers/movies-list.resolver';
import { MovieDetailsResolver } from './resolvers/movie-details.resolver';
import { TvShowsListResolver } from './resolvers/tv-shows-list.resolver';
import { ProductionCompanyComponent } from './components/production-company/production-company.component';
import { SeasonComponent } from './components/season/season.component';



@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    MoviesComponent,
    ShowListItemComponent,
    ShowListItemCardComponent,
    ShowsListComponent,
    TopRatedShowComponent,
    TvShowsComponent,
    HomeComponent,
    MovieDetailsComponent,
    TvShowDetailsComponent,
    ProductionCompanyComponent,
    SeasonComponent,
  ],
  imports: [
    MatPaginatorModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatButtonModule,
    MatTabsModule,
    MatCardModule,
    MatInputModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatFormFieldModule,
    MatTooltipModule,
    MatProgressSpinnerModule,
    AppRoutesModule,
    NgxPaginationModule,
  ],
  providers: [
    MoviesService,
    TVShowsService,
    PaginationService,
    MoviesResolver,
    TvShowsResolver,
    HomeResolver,
    MoviesListResolver,
    MovieDetailsResolver,
    TvShowsListResolver,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
