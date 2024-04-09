import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateShowtimeComponent } from './create-showtime.component';

describe('CreateShowtimeComponent', () => {
  let component: CreateShowtimeComponent;
  let fixture: ComponentFixture<CreateShowtimeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateShowtimeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateShowtimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
