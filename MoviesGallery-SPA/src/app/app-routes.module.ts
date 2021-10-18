import { NgModule } from "@angular/core";
import { PreloadAllModules, RouterModule, Routes } from "@angular/router";

const appRoutes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: "full" },
  { 
    path: 'home', 
    loadChildren: () => import('./modules/home.module').then(m => m.HomeModule) 
  },
  { 
    path: 'movies', 
    loadChildren: () => import('./modules/movies.module').then(m => m.MoviesModule) 
  },
  { 
    path: 'tv-shows', 
    loadChildren: () => import('./modules/tv-shows.module').then(m => m.TVShowsModule) 
  },
  // { path: '**', redirectTo: '/home' }
];
  

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutesModule {

}
  