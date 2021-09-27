import { Component, Input, OnInit } from '@angular/core';

import { Show } from 'src/app/models/show';

@Component({
  selector: 'app-show-list-item-card',
  templateUrl: './show-list-item-card.component.html',
  styleUrls: ['./show-list-item-card.component.less']
})
export class ShowListItemCardComponent implements OnInit {
  @Input() showItem!: Show;

  constructor() { }

  ngOnInit(): void {
  }

}
