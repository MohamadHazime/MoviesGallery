import { Component, ComponentFactoryResolver, ContentChild, Input, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import {Location} from '@angular/common';

import { AddReviewComponent } from '../add-review/add-review.component';
import { PlaceholderDirective } from 'src/app/directives/placeholder.directive';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-show-details',
  templateUrl: './show-details.component.html',
  styleUrls: ['./show-details.component.css']
})
export class ShowDetailsComponent implements OnInit, OnDestroy {
  @Input() showDetails!: any;
  @ViewChild(PlaceholderDirective, { static: false }) addReviewHost!: PlaceholderDirective;
  @ContentChild("seasonsTemplate", { static: false }) seasonsTemplateRef!: TemplateRef<any>;
  
  private closeSub!: Subscription;

  constructor(private location: Location, private componentFactoryResolver: ComponentFactoryResolver) { }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    if(this.closeSub) {
      this.closeSub.unsubscribe();
    }
  }

  onGoBack() {
    this.location.back();
  }

  onAddReviewPressed(){
    this.showReviewForm();
  }

  private showReviewForm() {
    const addReviewCmpFactory = this.componentFactoryResolver.resolveComponentFactory(AddReviewComponent);
    const hostViewContainerRef = this.addReviewHost.viewContainerRef;
    hostViewContainerRef.clear();

    const componentRef = hostViewContainerRef.createComponent(addReviewCmpFactory);

    this.closeSub = componentRef.instance.close.subscribe(() => {
      this.closeSub.unsubscribe();
      hostViewContainerRef.clear();
    });
  }

}
