import { NgModule } from "@angular/core";

import { HomeResolver } from "../resolvers/home.resolver";
import { MovieDetailsResolver } from "../resolvers/movie-details.resolver";
import { MoviesListResolver } from "../resolvers/movies-list.resolver";
import { MoviesResolver } from "../resolvers/movies.resolver";
import { TvShowsListResolver } from "../resolvers/tv-shows-list.resolver";
import { TvShowsResolver } from "../resolvers/tv-shows.resolver";
import { MoviesService } from "../services/movies.service";
import { TVShowsService } from "../services/tv-shows.service";
import { PaginationService } from "../services/pagination.service";
import { QueryParamsService } from "../services/query-params.service";
import { TvShowDetailsResolver } from "../resolvers/tv-show-details.resolver";
import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { AuthInterceptorService } from "../services/auth-interceptor.service";

@NgModule({
    providers: [
        MoviesService,
        TVShowsService,
        QueryParamsService,
        PaginationService,
        HomeResolver,
        MoviesResolver,
        TvShowsResolver,
        MoviesListResolver,
        MovieDetailsResolver,
        TvShowsListResolver,
        TvShowDetailsResolver,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthInterceptorService,
            multi: true
        }
    ]
})
export class CoreModule {}