import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatePointsComponent } from './update-points.component';

describe('UpdatePointsComponent', () => {
  let component: UpdatePointsComponent;
  let fixture: ComponentFixture<UpdatePointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdatePointsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdatePointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
