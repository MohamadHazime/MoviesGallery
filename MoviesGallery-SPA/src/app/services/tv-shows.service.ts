import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { Show } from "../models/show";
import { TVShowDetails } from "../models/tv-show-details";
import { QueryParamsService } from "./query-params.service";

@Injectable({
    providedIn: 'root',
})
export class TVShowsService {
    baseUrl = environment.apiUrl;
    imageUrl: string = environment.imageUrl;
    actionAndAdventureTvShowsId = 10759;
    comedyTvShowsId = 35;
    dramaTvShowsId = 18;

    constructor(private http: HttpClient, private queryParamsService: QueryParamsService) {}

    getTvShowById(id: number) {
        let params = this.queryParamsService.createTvShowsQueryParams('tv');

        return this.http
            .get<TVShowDetails>(this.baseUrl + 'tvshows/' + id, {
                params: params
            }).pipe(map(tvshow => {
                if(tvshow.posterPath == null) {
                    tvshow.posterPath = 'assets/images/no_image.png';
                } else {
                    tvshow.posterPath = this.imageUrl + tvshow.posterPath;
                }
                if(tvshow.backdropPath == null) {
                    tvshow.backdropPath = 'assets/images/no_image.png';
                } else {
                    tvshow.backdropPath = this.imageUrl + tvshow.backdropPath;
                }
                tvshow.productionCompanies.forEach(c => {
                    if(c.logoPath == null) {
                        c.logoPath = 'assets/images/no_image.png';
                    } else {
                        c.logoPath = this.imageUrl + c.logoPath;
                    }
                });
                tvshow.seasons.forEach(s => {
                    if(s.posterPath == null) {
                        s.posterPath = 'assets/images/no_image.png';
                    } else {
                        s.posterPath = this.imageUrl + s.posterPath;
                    }
                })

                return tvshow;
            }));
    }

    getTopRatedTvShows() {
        let params = this.queryParamsService.createTvShowsQueryParams('tv/top_rated');

        return this.http
            .get<Show[]>(this.baseUrl + 'tvshows/top-rated', {
                params: params
            }).pipe(map(tvShows => {
                tvShows.forEach(tvshow => {
                    if(tvshow.posterPath == null) {
                        tvshow.posterPath = 'assets/images/no_image.png';
                    } else {
                        tvshow.posterPath = this.imageUrl + tvshow.posterPath;
                    }

                    tvshow.type = 'TvShow';
                });
                return tvShows;
            }));
    }

    getTvShowsByGenre(genreId: number, page: number) {
        let params = this.queryParamsService.createTvShowsQueryParams('discover/tv', page);

        return this.http
            .get<Show[]>(this.baseUrl + 'tvshows/genre/' + genreId, {
                params: params
            }).pipe(map(tvShows => {
                tvShows.forEach(tvshow => {
                    if(tvshow.posterPath == null) {
                        tvshow.posterPath = 'assets/images/no_image.png';
                    } else {
                        tvshow.posterPath = this.imageUrl + tvshow.posterPath;
                    }

                    tvshow.type = 'TvShow';
                });
                return tvShows;
            }));
    }

    getTopRatedTvShowsByGenre(genreId: number) {
        let params = this.queryParamsService.createTvShowsQueryParams('tv/top_rated');

        return this.http
            .get<Show[]>(this.baseUrl + 'tvshows/genre/' + genreId + '/top-rated', {
                params: params
            }).pipe(map(tvShows => {
                tvShows.forEach(tvshow => {
                    if(tvshow.posterPath == null) {
                        tvshow.posterPath = 'assets/images/no_image.png';
                    } else {
                        tvshow.posterPath = this.imageUrl + tvshow.posterPath;
                    }

                    tvshow.type = 'TvShow';
                });
                return tvShows;
            }));
    }
}