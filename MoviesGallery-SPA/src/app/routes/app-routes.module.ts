import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "../components/home/home.component";
import { MovieDetailsComponent } from "../components/movie-details/movie-details.component";
import { MoviesComponent } from "../components/movies/movies.component";
import { ShowsListComponent } from "../components/shows-list/shows-list.component";
import { TvShowDetailsComponent } from "../components/tv-show-details/tv-show-details.component";
import { TvShowsComponent } from "../components/tv-shows/tv-shows.component";
import { HomeResolver } from "../resolvers/home.resolver";
import { MovieDetailsResolver } from "../resolvers/movie-details.resolver";
import { MoviesListResolver } from "../resolvers/movies-list.resolver";
import { MoviesResolver } from "../resolvers/movies.resolver";
import { TvShowDetailsResolver } from "../resolvers/tv-show-details.resolver";
import { TvShowsListResolver } from "../resolvers/tv-shows-list.resolver";
import { TvShowsResolver } from "../resolvers/tv-shows.resolver";

const appRoutes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: "full" },
    { path: 'home', component: HomeComponent, resolve: [HomeResolver] },
    { path: 'movies', component: MoviesComponent, resolve: [MoviesResolver] },
    { path: 'movies/details/:id', component: MovieDetailsComponent, resolve: [MovieDetailsResolver] },
    { path: 'movies/:category-name', component: ShowsListComponent, resolve: [MoviesListResolver] },
    { path: 'tv-shows', component: TvShowsComponent, resolve: [TvShowsResolver] },
    { path: 'tv-shows/details/:id', component: TvShowDetailsComponent, resolve: [TvShowDetailsResolver] },
    { path: 'tv-shows/:category-name', component: ShowsListComponent, resolve: [TvShowsListResolver] },
    { path: '**', redirectTo: '/home' }
  ];
  

@NgModule({
    imports: [
      // RouterModule.forRoot(appRoutes, {useHash: true})
      RouterModule.forRoot(appRoutes)
    ],
    exports: [RouterModule]
})
export class AppRoutesModule {

}
  