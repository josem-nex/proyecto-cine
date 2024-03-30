import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemMovieComponent } from './item-movie.component';

describe('ItemMovieComponent', () => {
  let component: ItemMovieComponent;
  let fixture: ComponentFixture<ItemMovieComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ItemMovieComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ItemMovieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
