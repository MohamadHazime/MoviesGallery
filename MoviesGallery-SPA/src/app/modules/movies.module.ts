import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";

import { MovieDetailsComponent } from "../components/movie-details/movie-details.component";
import { MoviesComponent } from "../components/movies/movies.component";
import { SharedModule } from "./shared.module";

@NgModule({
    declarations: [
        MoviesComponent,
        MovieDetailsComponent,
    ],
    imports: [
        RouterModule,
        SharedModule,
    ]
})
export class MoviesModule {}