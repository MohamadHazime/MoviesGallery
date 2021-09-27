import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {Location} from '@angular/common';

import { MovieDetails } from 'src/app/models/movie-details';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
  movieDetails!: MovieDetails

  constructor(private route: ActivatedRoute, private location: Location) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.movieDetails = data[0];
    });
  }

  onGoBack() {
    this.location.back();
  }

}
