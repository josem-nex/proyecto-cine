import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudShowtimeComponent } from './crud-showtime.component';

describe('CrudShowtimeComponent', () => {
  let component: CrudShowtimeComponent;
  let fixture: ComponentFixture<CrudShowtimeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CrudShowtimeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CrudShowtimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
