import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateShowtimeComponent } from './update-showtime.component';

describe('UpdateShowtimeComponent', () => {
  let component: UpdateShowtimeComponent;
  let fixture: ComponentFixture<UpdateShowtimeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateShowtimeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateShowtimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
