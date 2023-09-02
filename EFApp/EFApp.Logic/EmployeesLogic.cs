using EFApp.Data;
using EFApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EFApp.Logic
{
    public class EmployeesLogic : BaseLogic, ICRUDLogic<Employees>
    {
        public List<Employees> GetAll(){ 
            return context.Employees.ToList();
        }

        public void Insert(Employees newEmployee) 
        {
            context.Employees.Add(newEmployee);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employeeToDelete = context.Employees.Find(id);            
            context.Employees.Remove(employeeToDelete);
            context.SaveChanges();
        }

        public void Update(Employees newEmployee)
        {
            var employeeUpdate = context.Employees.Find(newEmployee.EmployeeID);
            employeeUpdate.HomePhone = newEmployee.HomePhone;
            context.SaveChanges();
        }
    }
}
