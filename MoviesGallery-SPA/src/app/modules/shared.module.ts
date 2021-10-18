import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FlexLayoutModule } from "@angular/flex-layout";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatCardModule } from "@angular/material/card";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatTabsModule } from "@angular/material/tabs";
import { MatTooltipModule } from "@angular/material/tooltip";
import { RouterModule } from "@angular/router";

import { AddReviewComponent } from "../components/add-review/add-review.component";
import { FooterComponent } from "../components/footer/footer.component";
import { HeaderComponent } from "../components/header/header.component";
import { ProductionCompanyComponent } from "../components/production-company/production-company.component";
import { ShowDetailsComponent } from "../components/show-details/show-details.component";
import { ShowListItemCardComponent } from "../components/show-list-item-card/show-list-item-card.component";
import { ShowListItemComponent } from "../components/show-list-item/show-list-item.component";
import { ShowsListComponent } from "../components/shows-list/shows-list.component";
import { TopRatedShowComponent } from "../components/top-rated-show/top-rated-show.component";
import { PlaceholderDirective } from "../directives/placeholder.directive";

@NgModule({
    declarations: [
        FooterComponent,
        HeaderComponent,
        ShowListItemComponent,
        ShowListItemCardComponent,
        ShowsListComponent,
        TopRatedShowComponent,
        ProductionCompanyComponent,
        AddReviewComponent,
        ShowDetailsComponent,
        PlaceholderDirective,
    ],
    imports: [
        RouterModule,
        CommonModule,
        MatPaginatorModule,
        MatIconModule,
        MatButtonModule,
        MatTabsModule,
        MatCardModule,
        MatInputModule,
        FlexLayoutModule,
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatTooltipModule,
        MatProgressSpinnerModule,
    ],
    exports: [
        FooterComponent,
        HeaderComponent,
        ShowListItemComponent,
        ShowListItemCardComponent,
        ShowsListComponent,
        TopRatedShowComponent,
        ProductionCompanyComponent,
        AddReviewComponent,
        ShowDetailsComponent,
        CommonModule,
        MatPaginatorModule,
        MatIconModule,
        MatButtonModule,
        MatTabsModule,
        MatCardModule,
        MatInputModule,
        FlexLayoutModule,
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatTooltipModule,
        MatProgressSpinnerModule,
        PlaceholderDirective,
    ]
})
export class SharedModule {}