using EFApp.Entities;
using EFApp.Logic;
using EFApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;

namespace EFApp.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeesLogic employeesLogic = new EmployeesLogic();
        // GET: Employee
        public ActionResult Index()
        {            
            List<Employees> employees = employeesLogic.GetAll();

            List<EmployeesView> employeesView = employees.Select(s => new EmployeesView
            {
                EmployeeID = s.EmployeeID,
                FirstName = s.FirstName,
                LastName = s.LastName,
                HomePhone = s.HomePhone,
            }).ToList();

            return View(employeesView);
        }

        public JsonResult delete(int id = 0)
        {
            bool ok = false;
            string message = "";

            if (id == 0)
            {
                message = "Debe seleccionar el empleado que desea eliminar";
            }
            else
            {
                try
                {
                    employeesLogic.Delete(id);
                    ok = true;
                    message = "El empleado se ha eliminado correctamente";
                }
                catch (System.FormatException e)
                {
                    message = "\nNo se pudo eliminar el empleado. \nMotivo: seguro ingreso una letra o no ingreso nada";
                }
                catch (System.ArgumentNullException)
                {
                    message = "\nNo se pudo eliminar el empleado. \nMotivo: no se encontró ningún empleado con el ID ingresado";
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                {
                    message = "\nNo se pudo eliminar el empleado. \nMotivo: el empleado que desea eliminar está siendo utilizado como referencia.";
                }
            }

            return Json(new { ok = ok, message = message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateUpdate(EmployeesView employeesView)
        {            
            try
            {
                if (ModelState.IsValid)
                {
                    if (employeesView.EmployeeID == 0)
                    {
                        employeesLogic.Insert(new Employees
                        {
                            FirstName = employeesView.FirstName,
                            LastName = employeesView.LastName,
                            HomePhone = employeesView.HomePhone
                        });
                    }
                    else
                    {
                        Employees employees = employeesLogic.Get(employeesView.EmployeeID);                       
                        employees.FirstName = employeesView.FirstName;
                        employees.LastName = employeesView.LastName;
                        employees.HomePhone = employeesView.HomePhone;
                        employeesLogic.Update(employees);                        
                    }
                    
                    return RedirectToAction("Index");
                }
                return View(employeesView);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
        public ActionResult CreateUpdate(int id = 0)
        {
            try
            {                
                EmployeesView employeeView = null;
                if (id > 0)
                {
                    Employees emplopyee = employeesLogic.Get(id);
                    employeeView = new EmployeesView();
                    employeeView.EmployeeID = emplopyee.EmployeeID;
                    employeeView.LastName = emplopyee.LastName;
                    employeeView.FirstName = emplopyee.FirstName;                    
                    employeeView.HomePhone = emplopyee.HomePhone;
                }
                return View(employeeView);

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }          
        }
    }
}