import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { forkJoin, Observable } from "rxjs";
import { map } from "rxjs/operators";
import { TvShowsModel } from "../models/tv-shows-view";
import { TVShowsService } from "../services/tv-shows.service";

@Injectable({
    providedIn: 'root',
})
export class TvShowsResolver implements Resolve<TvShowsModel> {
    constructor(private tvShowsService: TVShowsService) {}

    resolve(): Observable<TvShowsModel> {
        let actionAndAdventureTvShowsRequest = this.tvShowsService.getTopRatedTvShowsByGenre(this.tvShowsService.actionAndAdventureTvShowsId);
        let comedyTvShowsRequest = this.tvShowsService.getTopRatedTvShowsByGenre(this.tvShowsService.comedyTvShowsId);
        let dramaTvShowsRequest = this.tvShowsService.getTopRatedTvShowsByGenre(this.tvShowsService.dramaTvShowsId);

        return forkJoin([actionAndAdventureTvShowsRequest, comedyTvShowsRequest, dramaTvShowsRequest])
            .pipe(map(response => {
                let tvShowsModel: TvShowsModel = {
                    actionAndAdventureTvShows: response[0],
                    comedyTvShows: response[1],
                    dramaTvShows: response[2]
                };

                return tvShowsModel;
            }));
    }
}