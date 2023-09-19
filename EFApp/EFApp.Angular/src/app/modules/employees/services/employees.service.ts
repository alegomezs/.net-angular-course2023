import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { Employee } from '../models/employees';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {

  endpoint: string = 'employees';
  constructor(private http: HttpClient) { }

  public getEmployees(): Observable<Array<Employee>> {
    const url = environment.apiEmployees + this.endpoint;
    return this.http.get<Array<Employee>>(url);
  }

  public createEmployee(employeeRequest: Employee): Observable<any> {
    const url = environment.apiEmployees + this.endpoint;
    return this.http.post(url, employeeRequest);
  }

  public updateEmployee(employeeRequest: Employee): Observable<any> {
    const url = environment.apiEmployees + this.endpoint;
    return this.http.put(url, employeeRequest);
  }

  public deleteEmployee(id: number | string) {
    return this.http.delete(environment.apiEmployees + this.endpoint + `/${id}`);
  }
}
