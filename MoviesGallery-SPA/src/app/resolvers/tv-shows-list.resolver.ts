import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, Router } from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Show } from "../models/show";
import { TVShowsService } from "../services/tv-shows.service";

@Injectable({
    providedIn: 'root',
})
export class TvShowsListResolver implements Resolve<{'list': Show[], 'type': string}> {
    constructor(private tvShowsService: TVShowsService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot): Observable<{'list': Show[], 'type': string}> {
        let categoryName = route.params['category-name'];
        let categoryId = 0;

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

        if(categoryId == 0) {
            this.router.navigate(['/home']);
        }

        return this.tvShowsService.getTvShowsByGenre(categoryId, 1)
            .pipe(map(tvShows => {
                return {'list': tvShows, 'type': 'tv-shows'};
            }));
    }
}