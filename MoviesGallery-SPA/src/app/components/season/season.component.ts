import { Component, Input, OnInit } from '@angular/core';

import { Season } from 'src/app/models/season';

@Component({
  selector: 'app-season',
  templateUrl: './season.component.html',
  styleUrls: ['./season.component.css']
})
export class SeasonComponent implements OnInit {
  @Input() seasonItem!: Season;

  constructor() { }

  ngOnInit(): void {
  }

}
