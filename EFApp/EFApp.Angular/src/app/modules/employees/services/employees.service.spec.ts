import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { environment } from '../../../../environments/environment';
import { EmployeesService } from './employees.service';

describe('EmployeesService', () => {
  let service: EmployeesService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [EmployeesService],
    });
    service = TestBed.inject(EmployeesService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should retrieve employees via GET', () => {
    const mockEmployees =
      [
        {
          "EmployeeID": 1,
          "FirstName": "Nancy",
          "LastName": "Davolio",
          "HomePhone": "(206) 555-9857"
        },
        {
          "EmployeeID": 2,
          "FirstName": "Andrew",
          "LastName": "Fuller",
          "HomePhone": "(206) 555-9482"
        },
        {
          "EmployeeID": 3,
          "FirstName": "Janet",
          "LastName": "Leverling",
          "HomePhone": "(206) 555-3412"
        },
      ];

    service.getEmployees().subscribe((employees) => {
      expect(employees).toEqual(mockEmployees);
    });

    const req = httpTestingController.expectOne(environment.apiEmployees + 'employees');
    expect(req.request.method).toBe('GET');

    req.flush(mockEmployees);
  });

});
