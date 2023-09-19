import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReadDeleteEmployeeComponent } from './read-delete-employee.component';

describe('ReadDeleteEmployeeComponent', () => {
  let component: ReadDeleteEmployeeComponent;
  let fixture: ComponentFixture<ReadDeleteEmployeeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ReadDeleteEmployeeComponent]
    });
    fixture = TestBed.createComponent(ReadDeleteEmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
