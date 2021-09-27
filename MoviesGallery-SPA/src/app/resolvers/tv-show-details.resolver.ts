import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { TVShowDetails } from "../models/tv-show-details";
import { TVShowsService } from "../services/tv-shows.service";

@Injectable({
    providedIn: 'root',
})
export class TvShowDetailsResolver implements Resolve<TVShowDetails> {
    constructor(private tvShowService: TVShowsService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<TVShowDetails> {
        let id = route.params['id'];

        return this.tvShowService
            .getTvShowById(id)
            .pipe(map(tvShow => {
                return tvShow;
            }));
    }
}