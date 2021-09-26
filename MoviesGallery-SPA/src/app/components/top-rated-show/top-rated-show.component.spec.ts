import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopRatedShowComponent } from './top-rated-show.component';

describe('TopRatedShowComponent', () => {
  let component: TopRatedShowComponent;
  let fixture: ComponentFixture<TopRatedShowComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TopRatedShowComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TopRatedShowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
