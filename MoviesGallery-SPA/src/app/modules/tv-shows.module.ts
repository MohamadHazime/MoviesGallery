import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";

import { SeasonComponent } from "../components/season/season.component";
import { TvShowDetailsComponent } from "../components/tv-show-details/tv-show-details.component";
import { TvShowsComponent } from "../components/tv-shows/tv-shows.component";
import { SharedModule } from "./shared.module";

@NgModule({
    declarations: [
        TvShowsComponent,
        TvShowDetailsComponent,
        SeasonComponent,
    ],
    imports: [
        RouterModule,
        SharedModule,
    ]
})
export class TVShowsModule {}