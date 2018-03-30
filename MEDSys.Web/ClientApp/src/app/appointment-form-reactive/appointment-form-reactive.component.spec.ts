import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppointmentFormReactiveComponent } from './appointment-form-reactive.component';

describe('AppointmentFormReactiveComponent', () => {
  let component: AppointmentFormReactiveComponent;
  let fixture: ComponentFixture<AppointmentFormReactiveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppointmentFormReactiveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppointmentFormReactiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
