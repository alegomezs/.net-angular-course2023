using EFApp.API.Models.DTO;
using EFApp.Entities;
using EFApp.Logic;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EFApp.API.Controllers
{
    [Route("api/[controller]")]   
    public class EmployeesApiController : ApiController
    {       
        public class EmployeesController : ApiController
        {
            private readonly ICRUDLogic<Employees> employeeLogic;

            public EmployeesController()
            {
                this.employeeLogic = new EmployeesLogic(); ;
            }

            public EmployeesController(ICRUDLogic<Employees> employeeLogic)
            {
                this.employeeLogic = employeeLogic;
            }

            // GET: employees
            /// <summary>
            /// Listado de Employees
            /// </summary>
            /// <returns></returns>+
            [HttpGet]            
            public IHttpActionResult GetEmployees()
            {
                try
                {
                    var Employees = employeeLogic.GetAll();
                    var EmployeesViews = Employees.Select(e => new EmployeeDTO
                    {
                        EmployeeID = e.EmployeeID,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        HomePhone = e.HomePhone

                    }).ToList();

                    return Ok(EmployeesViews);
                }
                catch (Exception e)
                {
                    return NotFound();
                }
            }

            // GET: employees/{id}
            /// <summary>
            /// Obtener employee por Id
            /// </summary>
            /// <param name="id">Id del Elemento por Route Param</param>
            /// <returns></returns>
            [HttpGet]            
            public IHttpActionResult GetEmployees(int id)
            {
                try
                {
                    Employees employee = employeeLogic.Get(id);
                    if (employee == null)
                    {
                        return NotFound();
                    }
                    var EmployeesViews = new EmployeeDTO
                    {
                        EmployeeID = employee.EmployeeID,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        HomePhone = employee.HomePhone
                    };

                    return Ok(EmployeesViews);
                }
                catch (Exception e)
                {
                    return NotFound();
                }
            }

            // POST: employees
            /// <summary>
            /// Crear un employee
            /// </summary>
            /// <param name="employeeRequest">Json From body</param>
            /// <returns></returns>
            [HttpPost]            
            public IHttpActionResult PostEmployees(EmployeeDTO employee)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        Employees employeeEntity = new Employees
                        {                            
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            HomePhone = employee.HomePhone
                        };
                        employeeLogic.Insert(employeeEntity);                        
                        return Content(HttpStatusCode.Created, employeeEntity); ;
                    }

                    return BadRequest(ModelState.ToString());
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }

            // PUT: employees
            /// <summary>
            /// Editar un employee
            /// </summary>
            /// <param name="employeeRequest">Json From body</param>
            /// <returns></returns>
            [HttpPut]
            public IHttpActionResult PutEmployees(EmployeeDTO employee)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        Employees employeeEntity = employeeLogic.Get(employee.EmployeeID);
                        if (employeeEntity == null)
                        {
                            return NotFound();
                        }
                        employeeEntity.EmployeeID = employee.EmployeeID;
                        employeeEntity.FirstName = employee.FirstName;
                        employeeEntity.LastName = employee.LastName;
                        employeeEntity.HomePhone = employee.HomePhone;
                        employeeLogic.Update(employeeEntity);
                        return Ok(employeeEntity);

                    }

                    return BadRequest(ModelState.ToString());
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }

            // DELETE: employees/{id}
            /// <summary>
            /// Eliminar un employee por Id
            /// </summary>
            /// <param name="id">Id del Elemento por Route Param</param>
            /// <returns></returns>
            [HttpDelete]
            public IHttpActionResult DeleteEmployees(int id)
            {
                try
                {
                    try
                    {
                        employeeLogic.Delete(id);
                        return Ok("El empleado se ha eliminado correctamente");
                    }
                    catch (System.FormatException e)
                    {
                        return BadRequest("No se pudo eliminar al empleado. \nMotivo: seguro ingreso una letra o no ingreso nada");
                    }
                    catch (System.ArgumentNullException)
                    {
                        return NotFound();
                    }
                    catch (System.Data.EntityException e)
                    {
                        return BadRequest("No se pudo eliminar al empleado. \nMotivo: el empleado que desea eliminar está siendo utilizado como referencia.");
                    }
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
        }
    }
}