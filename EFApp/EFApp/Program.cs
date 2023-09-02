using EFApp.Data;
using EFApp.Entities;
using EFApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EFApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
                        
            while (!exit)
            {
                try
                {
                    Menu();
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            GetEmpoloyees();                            
                            break;
                        case 2:
                            GetEmployeesAndOrders();
                            break;
                        case 3:
                            InsertEmployee();
                            break;
                        case 4:
                            UpdateEmployee();
                            break;
                        case 5:
                            DeleteEmployee();
                            break;
                        case 6:
                            exit = true;
                            break;
                    }                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + Environment.NewLine);
                }
            }
        }

        static void Menu()
        {
            Console.WriteLine("Seleccione opcion y precione ENTER");
            Console.WriteLine("1. Listar Empleados.");
            Console.WriteLine("2. Listar Empleados y sus pedidos.");            
            Console.WriteLine("3. Crear Empleado.");
            Console.WriteLine("4. Editar Telefono de contacto de un empleado.");
            Console.WriteLine("5. Eliminar Empleado.");
            Console.WriteLine("6. Salir.");                       
            Console.WriteLine(Environment.NewLine);
        }

        static void GetEmpoloyees()
        {
            EmployeesLogic employeesLogic = new EmployeesLogic();

            foreach (Employees employee in employeesLogic.GetAll())
            {
                Console.WriteLine($" {employee.EmployeeID} - {employee.FirstName} {employee.LastName} - tel: {employee.HomePhone}.");                
            }
            Console.WriteLine(Environment.NewLine);
        }

        static void GetEmployeesAndOrders()
        {
            EmployeesLogic employeesLogic = new EmployeesLogic();

            foreach (Employees employee in employeesLogic.GetAll())
            {
                Console.WriteLine($" {employee.EmployeeID} - {employee.FirstName} {employee.LastName} - tel: {employee.HomePhone}.");
                if (employee.Orders != null)
                {
                    Console.WriteLine($"Pedidos:");
                    foreach (Orders order in employee.Orders)
                    {
                        Console.WriteLine($"-- {order.OrderID} {order.ShipName}.");
                    }
                }
            }
            Console.WriteLine(Environment.NewLine);
        }

        static void InsertEmployee()
        {                      
            try
            {
                NorthwindContext context = new NorthwindContext();

                var lastColumn = context.Employees
                       .OrderByDescending(e => e.EmployeeID)
                       .FirstOrDefault();

                int lastID = lastColumn.EmployeeID;

                Console.WriteLine("Nombre:");
                string firstName = Console.ReadLine();
                Console.WriteLine("Apellido:");
                string lastName = Console.ReadLine();
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Home Phone:");
                string homePhone = Console.ReadLine();

                if (lastID != 0)
                {
                    lastID++;
                    EmployeesLogic employeesLogic = new EmployeesLogic();
                    employeesLogic.Insert(new Employees
                    {
                        EmployeeID = lastID,
                        FirstName = firstName,
                        LastName = lastName,
                        HomePhone = homePhone
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DeleteEmployee()
        {
            try
            {
                Console.WriteLine("Seleccione empleado por ID:");
                GetEmpoloyees();
                int optionId = int.Parse(Console.ReadLine());
                if (optionId != 0)
                {
                    EmployeesLogic employeesLogic = new EmployeesLogic();
                    try
                    {                       
                        employeesLogic.Delete(optionId);
                        Console.WriteLine($"Empleado ID {optionId} eliminado exitosamente! {Environment.NewLine}");
                    }catch(Exception ex)
                    {
                        Console.WriteLine($"No se pudo eliminar. Reintente...{Environment.NewLine}");
                    }
                }
                else 
                {
                    Console.WriteLine("Debe ingresar un ID diferente a 0");
                    DeleteEmployee();
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void UpdateEmployee()
        {
            try
            {
                Console.WriteLine("Seleccione empleado por ID:");
                GetEmpoloyees();
                int optionId = int.Parse(Console.ReadLine());
                if (optionId != 0)
                {                   
                    try
                    {
                        Console.WriteLine("Ingrese numero de telefono:");
                        string homePhone = Console.ReadLine();
                        EmployeesLogic employeesLogic = new EmployeesLogic();
                        employeesLogic.Update(new Employees
                        {                   
                            EmployeeID = optionId,
                            HomePhone = homePhone
                        });
                        Console.WriteLine($"Empleado ID {optionId} actualizado exitosamente! {Environment.NewLine}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"No se pudo actualizar el telefono. Reintente...{Environment.NewLine}");
                    }
                }
                else
                {
                    Console.WriteLine("Debe ingresar un ID diferente a 0");
                    DeleteEmployee();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
