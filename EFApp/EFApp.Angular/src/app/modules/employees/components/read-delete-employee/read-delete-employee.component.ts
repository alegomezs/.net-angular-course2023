import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Employee } from '../../models/employees';
import { EmployeesService } from '../../services/employees.service';
import Swal from 'sweetalert2';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-read-delete-employee',
  templateUrl: './read-delete-employee.component.html',
  styleUrls: ['./read-delete-employee.component.css'],
})
export class ReadDeleteEmployeeComponent implements OnInit, AfterViewInit {
  listEmployees: Array<Employee> = [];
  displayedColumns: string[] = ['ID', 'Nombres', 'Apellidos', 'Teléfono', 'Acciones'];
  modalTitle: string = '';
  snackTitle: string = '';
  snackDescription: string = '';
  snackDuration = 3;
  activateCreateUpdateEmployeesComponent: boolean = false;
  employee!: Employee;
  dataSource!: MatTableDataSource<Employee>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private employeesService: EmployeesService,
    private _snackBar: MatSnackBar) { }
  
  ngOnInit(): void {
    this.getEmployees();
  }

  ngAfterViewInit() {    
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  getEmployees() {
    Swal.fire({
      title: 'Aguarde un momento por favor.',
      showConfirmButton: false,
    });

    Swal.showLoading();

    this.employeesService.getEmployees().subscribe({
      next: res => {
        Swal.close();
        this.listEmployees = res;
        this.dataSource = new MatTableDataSource(this.listEmployees);
      },
      error: err => {
        Swal.close();
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'No es posible obtener la lista de empleados en este momento. Por favor reintente más tarde.'
        });
      }
    });
  }

  modalCreate() {
    this.employee = {
      EmployeeID: 0,
      FirstName: "",
      LastName: "",
      HomePhone: "",
    };
    this.modalTitle = "Crear Empleado";
    this.activateCreateUpdateEmployeesComponent = true;
  }

  modalUpdate(employee: Employee) {
    this.employee = { ...employee };
    this.modalTitle = "Modificar Empleado";
    this.activateCreateUpdateEmployeesComponent = true;
  }

  modalClose() {
    this.activateCreateUpdateEmployeesComponent = false;
  }

  modalDelete(employee: Employee) {

    Swal.fire({
      title: 'Confirmar',
      html: `¿Estás segura de que quieres eliminar el emplado: <b>${employee.FirstName + employee.LastName}</b>?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: '¡Si, eliminar!',
      cancelButtonText: 'No',
    }).then((result: any) => {

      if (result.value) {
        Swal.fire({
          title: 'Por favor espere',
          showConfirmButton: false,
        });

        Swal.showLoading();

        this.employeesService.deleteEmployee(employee.EmployeeID).subscribe({
          next: res => {
            this.getEmployees();

            Swal.close();

            const closeModalBtn = document.getElementById('create-update-modal-close');

            if (closeModalBtn) {
              closeModalBtn.click();
            }
            this.snackTitle = "Exito!";
            this.snackDescription = `Se eliminó a ${this.employee.FirstName} ${this.employee.LastName}.`;
            this.openSnackBar(this.snackTitle, this.snackDescription, this.snackDuration, "success");
          },
          error: err => {
            Swal.close();

            Swal.fire({
              icon: 'error',
              title: 'Oops...',
              text: 'No es posible eliminar el empleado en este momento. Por favor vuelva a intentar más tarde.'
            });
          }
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

  feedbackCreateUpdate(data: boolean) {
    if (data) {
      this.getEmployees();
    }
  }
}
