import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { HomeComponent } from "../components/home/home.component";
import { SharedModule } from "./shared.module";

@NgModule({
    declarations: [
        HomeComponent,
    ],
    imports: [
        RouterModule,
        SharedModule,
    ],
})
export class HomeModule {}