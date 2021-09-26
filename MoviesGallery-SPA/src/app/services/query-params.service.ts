import { HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root',
})
export class QueryParamsService {

    constructor() {}

    createMoviesQueryParams(query: string, page?: number) {
        let params = new HttpParams();
        params = params.append('movies-query', query);

        if(page != undefined) {
            params = params.append('page', page.toString());
        }

        return params;
    }

    createTvShowsQueryParams(query: string, page?: number) {
        let params = new HttpParams();
        params = params.append('tv-shows-query', query);

        if(page != undefined) {
            params = params.append('page', page.toString());
        }

        return params;
    }
}