import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewPersonDialogComponent } from './new-person-dialog.component';

describe('NewPersonDialogComponent', () => {
  let component: NewPersonDialogComponent;
  let fixture: ComponentFixture<NewPersonDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NewPersonDialogComponent]
    });
    fixture = TestBed.createComponent(NewPersonDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
