import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";

import { MovieDetailsComponent } from "../components/movie-details/movie-details.component";
import { MoviesComponent } from "../components/movies/movies.component";
import { MoviesRoutesModule } from "../routes/movies-routes.module";
import { SharedModule } from "./shared.module";

@NgModule({
    declarations: [
        MoviesComponent,
        MovieDetailsComponent,
    ],
    imports: [
        RouterModule,
        MoviesRoutesModule,
        SharedModule,
    ]
})
export class MoviesModule {}