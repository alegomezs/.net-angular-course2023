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

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                employeesLogic.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        [HttpGet]
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
                throw new Exception(ex.Message);
            }
        }
        
        public ActionResult CreateUpdate(int id = 0)
        {
            try
            {                
                EmployeesView employeeView = null;
                if (id > 0)
                {
                    Employees emplopyee = employeesLogic.Get(id);
                    employeeView = new EmployeesView();
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