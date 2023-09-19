import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReadDeleteEmployeeComponent } from './components/read-delete-employee/read-delete-employee.component';
import { EmployeesComponent } from './employees.component';
import { CreateUpdateEmployeeComponent } from './components/create-update-employee/create-update-employee.component';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [
    EmployeesComponent,
    CreateUpdateEmployeeComponent,
    ReadDeleteEmployeeComponent,
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    SharedModule,
  ],
})
export class EmployeesModule { }
