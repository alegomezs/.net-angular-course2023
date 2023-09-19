import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeesService } from '../../services/employees.service';
import { Employee } from '../../models/employees';
import Swal from 'sweetalert2';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-create-update-employee',
  templateUrl: './create-update-employee.component.html',
  styleUrls: ['./create-update-employee.component.css']
})
export class CreateUpdateEmployeeComponent implements OnInit {

  public formEmployee!: FormGroup;
  snackTitle: string = '';
  snackDescription: string = '';
  snackDuration = 3;

  constructor(
    private formBuild: FormBuilder,
    private employeeService: EmployeesService,
    private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.initForm();
  }

  @Input() employee!: Employee;

  @Output() submittedEmployee = new EventEmitter<boolean>();

  btnName: string = "Crear";

  initForm() {
    this.formEmployee = this.formBuild.group({
      firstName: ['', [Validators.required, Validators.maxLength(40)]],
      lastName: ['', [Validators.required, Validators.maxLength(40)]],
      homePhone: ['', [Validators.required, Validators.maxLength(16)]],
    });
    this.formEmployee.get('firstName')?.setValue(this.employee.FirstName);
    this.formEmployee.get('lastName')?.setValue(this.employee.LastName);
    this.formEmployee.get('homePhone')?.setValue(this.employee.HomePhone);
    if (this.employee.EmployeeID != 0) {
      this.btnName = "Modificar";
    }
  }

  private createEmployee() {
    Swal.fire({
      title: 'Espere un momento',
      showConfirmButton: false,
    });

    Swal.showLoading(null);

    const employee = new Employee();

    employee.FirstName = this.formEmployee.get('firstName')?.value;
    employee.LastName = this.formEmployee.get('lastName')?.value;
    employee.HomePhone = this.formEmployee.get('homePhone')?.value;

    this.employeeService.createEmployee(employee).subscribe({
      next: res => {
        this.submittedEmployee.emit(true);
        const closeModalBtn = document.getElementById('create-update-modal-close');

        if (closeModalBtn) {
          closeModalBtn.click();
        }

        this.snackTitle = "Exito!";
        this.snackDescription = `Se creó a ${this.employee.FirstName} ${this.employee.LastName}.`;
        this.openSnackBar(this.snackTitle, this.snackDescription, this.snackDuration, "success");
      },
      error: err => {
        this.submittedEmployee.emit(false);
        Swal.close();
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'En estos momentos no es posible crear empleados. Por favor reintente más tarde.',
        });
      }
    });
  }

  private updateEmployee() {
    Swal.fire({
      title: 'Espere un momento',
      showConfirmButton: false,
    });

    Swal.showLoading(null);

    const employee = {
      EmployeeID: this.employee.EmployeeID,
      FirstName: this.formEmployee.get('firstName')?.value,
      LastName: this.formEmployee.get('lastName')?.value,
      HomePhone: this.formEmployee.get('homePhone')?.value,
    };

    this.employeeService.updateEmployee(employee).subscribe({
      next: res => {
        this.submittedEmployee.emit(true);
        const closeModalBtn = document.getElementById('create-update-modal-close');

        if (closeModalBtn) {
          closeModalBtn.click();
        }

        this.snackTitle = "Exito!";
        this.snackDescription = `Se actualizó a ${this.employee.FirstName} ${this.employee.LastName}.`;
        this.openSnackBar(this.snackTitle, this.snackDescription, this.snackDuration, "success");
      },
      error: err => {
        console.error(err);
        this.submittedEmployee.emit(false);
        Swal.close();
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'En estos momentos no es posible crear empleados. Por favor reintente más tarde.',
        });
      }
    });
  }

  openSnackBar(message: string, action: string, seconds: number, style: string) {
    this._snackBar.open(message, action,
      {
        duration: seconds * 1000,
        panelClass: style,
      });
  }

  submitEmployee() {
    if (this.employee.EmployeeID == 0) {
      this.createEmployee();
    } else {
      this.updateEmployee();
    }
  }

  get f() { return this.formEmployee.controls }
}
