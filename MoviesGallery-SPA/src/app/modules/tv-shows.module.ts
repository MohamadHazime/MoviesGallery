import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";

import { SeasonComponent } from "../components/season/season.component";
import { TvShowDetailsComponent } from "../components/tv-show-details/tv-show-details.component";
import { TvShowsComponent } from "../components/tv-shows/tv-shows.component";
import { TVShowsRoutesModule } from "../routes/tv-shows-routes.module";
import { SharedModule } from "./shared.module";

@NgModule({
    declarations: [
        TvShowsComponent,
        TvShowDetailsComponent,
        SeasonComponent,
    ],
    imports: [
        RouterModule,
        TVShowsRoutesModule,
        SharedModule,
    ]
})
export class TVShowsModule {}