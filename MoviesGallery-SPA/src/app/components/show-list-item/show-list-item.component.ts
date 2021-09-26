import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Show } from 'src/app/models/show';

@Component({
  selector: 'app-show-list-item',
  templateUrl: './show-list-item.component.html',
  styleUrls: ['./show-list-item.component.less']
})
export class ShowListItemComponent implements OnInit {
  @Input() showItem!: Show;

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
  }

  onNavigate() {
    if(this.showItem.type === 'Movie') {
      this.router.navigate(['/movies', 'details', this.showItem.id]);
    } else {
      this.router.navigate(['/tv-shows', 'details', this.showItem.id]);
    }
  }

}
