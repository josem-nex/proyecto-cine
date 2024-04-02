import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateMonetaryComponent } from './update-monetary.component';

describe('UpdateMonetaryComponent', () => {
  let component: UpdateMonetaryComponent;
  let fixture: ComponentFixture<UpdateMonetaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateMonetaryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateMonetaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
