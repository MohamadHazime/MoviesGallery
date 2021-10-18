import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MovieDetailsComponent } from '../components/movie-details/movie-details.component';
import { MoviesComponent } from '../components/movies/movies.component';
import { ShowsListComponent } from '../components/shows-list/shows-list.component';
import { MovieDetailsResolver } from '../resolvers/movie-details.resolver';
import { MoviesListResolver } from '../resolvers/movies-list.resolver';
import { MoviesResolver } from '../resolvers/movies.resolver';

const routes: Routes = [
  { path: '', component: MoviesComponent, resolve: [MoviesResolver] },
  { path: 'details/:id', component: MovieDetailsComponent, resolve: [MovieDetailsResolver] },
  { path: ':category-name', component: ShowsListComponent, resolve: [MoviesListResolver] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MoviesRoutesModule {}