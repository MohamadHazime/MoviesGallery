import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TVShowDetails } from 'src/app/models/tv-show-details';

@Component({
  selector: 'app-tv-show-details',
  templateUrl: './tv-show-details.component.html',
  styleUrls: ['./tv-show-details.component.css']
})
export class TvShowDetailsComponent implements OnInit {
  tvShowDetails!: TVShowDetails

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.tvShowDetails = data[0];
      console.log("Tv Show Details: ", this.tvShowDetails);
    })
  }

}
