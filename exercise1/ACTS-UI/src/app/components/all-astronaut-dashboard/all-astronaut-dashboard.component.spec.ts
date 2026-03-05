import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllAstronautDashboardComponent } from './all-astronaut-dashboard.component';

describe('AllAstronautDashboardComponent', () => {
  let component: AllAstronautDashboardComponent;
  let fixture: ComponentFixture<AllAstronautDashboardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AllAstronautDashboardComponent]
    });
    fixture = TestBed.createComponent(AllAstronautDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
