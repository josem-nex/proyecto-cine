import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateMonetaryComponent } from './create-monetary.component';

describe('CreateMonetaryComponent', () => {
  let component: CreateMonetaryComponent;
  let fixture: ComponentFixture<CreateMonetaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateMonetaryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateMonetaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
