import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowListItemCardComponent } from './show-list-item-card.component';

describe('ShowListItemCardComponent', () => {
  let component: ShowListItemCardComponent;
  let fixture: ComponentFixture<ShowListItemCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowListItemCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowListItemCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
