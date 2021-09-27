import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Show } from 'src/app/models/show';
import { PaginationService } from 'src/app/services/pagination.service';

@Component({
  selector: 'app-shows-list',
  templateUrl: './shows-list.component.html',
  styleUrls: ['./shows-list.component.css']
})
export class ShowsListComponent implements OnInit {
  showList: Show[] = [];
  page: number = 1;
  isLoading: boolean = false;

  constructor(private route: ActivatedRoute, private paginationService: PaginationService) { }

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      this.showList = data[0];
    });
  }

  onLoadPage(type: string) {
    if(this.isLoading) {
      return;
    }

    this.isLoading = true;
    if(type === 'previous') {
      this.page--;
    } else if('next') {
      this.page++;
    }

    this.paginationService
      .loadPage(this.page, this.route)
      ?.subscribe(data => {
        this.showList = data;
        this.isLoading = false;
      });
  }

}
