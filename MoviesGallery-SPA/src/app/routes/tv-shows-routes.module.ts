import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ShowsListComponent } from '../components/shows-list/shows-list.component';
import { TvShowDetailsComponent } from '../components/tv-show-details/tv-show-details.component';
import { TvShowsComponent } from '../components/tv-shows/tv-shows.component';
import { TvShowDetailsResolver } from '../resolvers/tv-show-details.resolver';
import { TvShowsListResolver } from '../resolvers/tv-shows-list.resolver';
import { TvShowsResolver } from '../resolvers/tv-shows.resolver';

const routes: Routes = [
  { path: '', component: TvShowsComponent, resolve: [TvShowsResolver] },
  { path: 'details/:id', component: TvShowDetailsComponent, resolve: [TvShowDetailsResolver] },
  { path: ':category-name', component: ShowsListComponent, resolve: [TvShowsListResolver] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TVShowsRoutesModule {}