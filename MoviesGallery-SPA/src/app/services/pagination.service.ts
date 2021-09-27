import { Injectable } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { MoviesService } from "./movies.service";
import { TVShowsService } from "./tv-shows.service";

@Injectable({
    providedIn: 'root',
})
export class PaginationService {

    constructor(
        private moviesService: MoviesService,
        private tvShowsService: TVShowsService
    ) {}

    loadPage(page: number, route: ActivatedRoute) {
        let type = '';
        let categoryName = '';

        route.url.subscribe(data => {
            type = data[0].path;
            categoryName = data[1].path;
        });

        let categoryId = 0;
        if(type === 'movies') {
            switch(categoryName) {
                case 'action':
                    categoryId = this.moviesService.actionMoviesId;
                    break;
                case 'comedy':
                    categoryId = this.moviesService.comedyMoviesId;
                    break;
                case 'drama':
                    categoryId = this.moviesService.actionMoviesId;
                    break;
                default:
                    categoryId = 0;
            }

            return this.moviesService.getMoviesByGenre(categoryId, page);
        } else if(type === 'tv-shows') {
            switch(categoryName) {
                case 'action-adventure':
                    categoryId = this.tvShowsService.actionAndAdventureTvShowsId;
                    break;
                case 'comedy':
                    categoryId = this.tvShowsService.comedyTvShowsId;
                    break;
                case 'drama':
                    categoryId = this.tvShowsService.dramaTvShowsId;
                    break;
                default:
                    categoryId = 0;
            }
            
            return this.tvShowsService.getTvShowsByGenre(categoryId, page);
        }
        
        return null;
    }
}