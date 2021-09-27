import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { MovieDetails } from "../models/movie-details";
import { MoviesService } from "../services/movies.service";

@Injectable({
    providedIn: 'root',
})
export class MovieDetailsResolver implements Resolve<MovieDetails> {
    constructor(private moviesService: MoviesService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<MovieDetails> {
        let id = route.params['id'];

        return this.moviesService
            .getMovieById(id)
            .pipe(map(movie => {
                return movie;
            }));
    }
}