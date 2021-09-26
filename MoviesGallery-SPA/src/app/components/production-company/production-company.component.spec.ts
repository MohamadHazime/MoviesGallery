import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionCompanyComponent } from './production-company.component';

describe('ProductionCompanyComponent', () => {
  let component: ProductionCompanyComponent;
  let fixture: ComponentFixture<ProductionCompanyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductionCompanyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductionCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
