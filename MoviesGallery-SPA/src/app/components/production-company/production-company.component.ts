import { Component, Input, OnInit } from '@angular/core';
import { ProductionCompany } from 'src/app/models/production-company';

@Component({
  selector: 'app-production-company',
  templateUrl: './production-company.component.html',
  styleUrls: ['./production-company.component.css']
})
export class ProductionCompanyComponent implements OnInit {
  @Input() prodCompanyItem!: ProductionCompany;

  constructor() { }

  ngOnInit(): void {
  }

}
