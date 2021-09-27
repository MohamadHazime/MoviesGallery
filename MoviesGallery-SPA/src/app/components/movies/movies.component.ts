import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { MoviesViewModel } from 'src/app/models/movies-view';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  moviesData: MoviesViewModel = {
    actionMovies: [],
    comedyMovies: [],
    dramaMovies: []
  };

  constructor(
    private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.moviesData = data[0];
    });
  }

  onNavigate(filterString: string) {
    this.router.navigate([filterString], {relativeTo: this.route});
  }

}
