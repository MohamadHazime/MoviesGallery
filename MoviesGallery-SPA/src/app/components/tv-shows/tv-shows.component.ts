import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TvShowsModel } from 'src/app/models/tv-shows-view';

@Component({
  selector: 'app-tv-shows',
  templateUrl: './tv-shows.component.html',
  styleUrls: ['./tv-shows.component.css']
})
export class TvShowsComponent implements OnInit {
  tvShowsData: TvShowsModel = {
    actionAndAdventureTvShows: [],
    comedyTvShows: [],
    dramaTvShows: []
  };

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.tvShowsData = data[0];
    });
  }

}
