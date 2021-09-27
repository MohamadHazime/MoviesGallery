import { Component, Input, OnInit } from '@angular/core';

import { Show } from 'src/app/models/show';

@Component({
  selector: 'app-top-rated-show',
  templateUrl: './top-rated-show.component.html',
  styleUrls: ['./top-rated-show.component.css']
})
export class TopRatedShowComponent implements OnInit {
  @Input() showTopRatedList: Show[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
