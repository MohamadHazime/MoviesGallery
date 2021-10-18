import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";

import { HomeComponent } from "../components/home/home.component";
import { HomeRoutesModule } from "../routes/home-routes.module";
import { SharedModule } from "./shared.module";

@NgModule({
    declarations: [
        HomeComponent,
    ],
    imports: [
        RouterModule,
        HomeRoutesModule,
        SharedModule,
    ],
})
export class HomeModule {}