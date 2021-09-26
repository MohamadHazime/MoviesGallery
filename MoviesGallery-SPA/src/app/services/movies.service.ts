import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Show } from "../models/show";
import { QueryParamsService } from "./query-params.service";
import { map } from 'rxjs/operators';
import { MovieDetails } from "../models/movie-details";

@Injectable({
    providedIn: 'root',
})
export class MoviesService {
    baseUrl: string = environment.apiUrl;
    imageUrl: string = environment.imageUrl;
    actionMoviesId = 28;
    comedyMoviesId = 35;
    dramaMoviesId = 18;

    constructor(private http: HttpClient, private queryParamsService: QueryParamsService) {}

    getMovies(page: number) {
        let params = this.queryParamsService.createMoviesQueryParams('movie/popular', page);

        return this.http
            .get<Show[]>(this.baseUrl + 'movies', {
                params: params
            }).pipe(map(movies => {
                movies.forEach(movie => {
                    if(movie.posterPath == null) {
                        movie.posterPath = 'assets/images/no_image.png';
                    } else {
                        movie.posterPath = this.imageUrl + movie.posterPath;
                    }
                });
                return movies;
            }));
    }

    getMovieById(id: number) {
        let params = this.queryParamsService.createMoviesQueryParams('movie');

        return this.http
            .get<MovieDetails>(this.baseUrl + 'movies/' + id, {
                params: params
            }).pipe(map(movie => {
                if(movie.posterPath == null) {
                    movie.posterPath = 'assets/images/no_image.png';
                } else {
                    movie.posterPath = this.imageUrl + movie.posterPath;
                }
                if(movie.backdropPath == null) {
                    movie.backdropPath = 'assets/images/no_image.png';
                } else {
                    movie.backdropPath = this.imageUrl + movie.backdropPath;
                }
                movie.productionCompanies.forEach(c => {
                    if(c.logoPath == null) {
                        c.logoPath = 'assets/images/no_image.png';
                    } else {
                        c.logoPath = this.imageUrl + c.logoPath;
                    }
                });

                return movie;
            }));
    }

    getTopRatedMovies() {
        let params = this.queryParamsService.createMoviesQueryParams('movie/top_rated');

        return this.http
            .get<Show[]>(this.baseUrl + 'movies/top-rated', {
                params: params
            }).pipe(map(movies => {
                movies.forEach(movie => {
                    if(movie.posterPath == null) {
                        movie.posterPath = 'assets/images/no_image.png';
                    } else {
                        movie.posterPath = this.imageUrl + movie.posterPath;
                    }

                    movie.type = 'Movie';
                });
                return movies;
            }));
    }

    getMoviesByGenre(genreId: number, page: number) {
        let params = this.queryParamsService.createMoviesQueryParams('discover/movie', page);

        return this.http
            .get<Show[]>(this.baseUrl + 'movies/genre/' + genreId, {
                params: params
            }).pipe(map(movies => {
                movies.forEach(movie => {
                    if(movie.posterPath == null) {
                        movie.posterPath = 'assets/images/no_image.png';
                    } else {
                        movie.posterPath = this.imageUrl + movie.posterPath;
                    }

                    movie.type = 'Movie';
                });
                return movies;
            }));
    }

    getTopRatedMoviesByGenre(genreId: number) {
        let params = this.queryParamsService.createMoviesQueryParams('movie/top_rated');

        return this.http
            .get<Show[]>(this.baseUrl + 'movies/genre/' + genreId + '/top-rated', {
                params: params
            }).pipe(map(movies => {
                movies.forEach(movie => {
                    if(movie.posterPath == null) {
                        movie.posterPath = 'assets/images/no_image.png';
                    } else {
                        movie.posterPath = this.imageUrl + movie.posterPath;
                    }

                    movie.type = 'Movie';
                });
                return movies;
            }));
    }
}