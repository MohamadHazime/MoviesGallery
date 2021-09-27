import { Injectable } from "@angular/core";
import { Resolve } from "@angular/router";
import { forkJoin, Observable } from "rxjs";
import { map } from "rxjs/operators";
import { MoviesViewModel } from "../models/movies-view";
import { MoviesService } from "../services/movies.service";

@Injectable({
    providedIn: 'root',
})
export class MoviesResolver implements Resolve<MoviesViewModel> {
    constructor(private moviesService: MoviesService) {}

    resolve(): Observable<MoviesViewModel> {
        let actionMoviesRequest = this.moviesService.getTopRatedMoviesByGenre(this.moviesService.actionMoviesId);
        let comedyMoviesRequest = this.moviesService.getTopRatedMoviesByGenre(this.moviesService.comedyMoviesId);
        let dramaMoviesRequest = this.moviesService.getTopRatedMoviesByGenre(this.moviesService.dramaMoviesId);

        return forkJoin([actionMoviesRequest, comedyMoviesRequest, dramaMoviesRequest])
            .pipe(map(response => {
                let moviesViewModel: MoviesViewModel = {
                    actionMovies: response[0],
                    comedyMovies: response[1],
                    dramaMovies: response[2]
                };

                return moviesViewModel;
            }));
    }
}