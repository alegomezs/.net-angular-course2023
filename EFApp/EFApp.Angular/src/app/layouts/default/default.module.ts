import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DefaultComponent } from './default.component';
import { HomeComponent } from 'src/app/modules/home/home.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { EmployeesModule } from 'src/app/modules/employees/employees.module';


@NgModule({
  declarations: [
    DefaultComponent,
    HomeComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    EmployeesModule,
  ]
})
export class DefaultModule { }
