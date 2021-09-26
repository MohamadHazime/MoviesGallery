import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { forkJoin, Observable, of } from "rxjs";
import { map } from "rxjs/operators";
import { HomeViewModel } from "../models/home-view";
import { MoviesService } from "../services/movies.service";
import { TVShowsService } from "../services/tv-shows.service";

@Injectable({
    providedIn: 'root',
})
export class HomeResolver implements Resolve<HomeViewModel> {
    constructor(private moviesService: MoviesService, private tvShowsService: TVShowsService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<HomeViewModel> {
        let topRatedMovies = this.moviesService.getTopRatedMovies();
        let topRatedTvShows = this.tvShowsService.getTopRatedTvShows();

        return forkJoin([topRatedMovies, topRatedTvShows])
            .pipe(map(response => {
                let homeViewModel: HomeViewModel = {
                    topRatedMovies: response[0],
                    topRatedTvShows: response[1]
                };

                return homeViewModel;
            }));
    }
}