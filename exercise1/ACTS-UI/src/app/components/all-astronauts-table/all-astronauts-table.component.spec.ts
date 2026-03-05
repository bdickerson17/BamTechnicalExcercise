import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllAstronautsTableComponent } from './all-astronauts-table.component';

describe('AllAstronautsTableComponent', () => {
  let component: AllAstronautsTableComponent;
  let fixture: ComponentFixture<AllAstronautsTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AllAstronautsTableComponent]
    });
    fixture = TestBed.createComponent(AllAstronautsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
