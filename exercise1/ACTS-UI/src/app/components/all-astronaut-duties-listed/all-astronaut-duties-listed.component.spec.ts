import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllAstronautDutiesListedComponent } from './all-astronaut-duties-listed.component';

describe('AllAstronautDutiesListedComponent', () => {
  let component: AllAstronautDutiesListedComponent;
  let fixture: ComponentFixture<AllAstronautDutiesListedComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AllAstronautDutiesListedComponent]
    });
    fixture = TestBed.createComponent(AllAstronautDutiesListedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
