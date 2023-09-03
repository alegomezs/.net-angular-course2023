using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace LinqTP
{
    public class Program
    {
        private static CustomersUI customersUI;
        private static ProductsUI productsUI;        
        public static void Main(string[] args)
        {
            bool exit = false;
            customersUI = new CustomersUI();
            productsUI = new ProductsUI();

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Practica 4 - LINQ. Queries:" + Environment.NewLine);
                Console.WriteLine("1. Ejecutar queries.");
                Console.WriteLine("2. Salir.");
                try
                {                                                          
                    int option = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (option)
                    {
                        case 1:
                            ExcecuteQueries();
                            break;
                        case 2:
                            exit = true;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + Environment.NewLine);
                    Console.WriteLine("Presiona ENTER para continuar.");
                    Console.ReadLine();
                }
            }
        }

        public static void ExcecuteQueries()
        {                        
            Console.WriteLine("1. Query para devolver objeto customer.");
            customersUI.GetCustomers();
            Console.WriteLine("2. Query para devolver todos los productos sin stock.");
            productsUI.GetProductsInStock();
            Console.WriteLine("3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad.");
            productsUI.GetProductsInStockByCertainPrice(3);
            Console.WriteLine("4. Query para devolver todos los customers de la Región WA.");
            customersUI.GetCustomersByRegion("WA");
            Console.WriteLine("5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789.");
            productsUI.GetFirstProductOrNullById(789);
            Console.WriteLine("6. Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.");
            Console.WriteLine("Nombres de los Customers en Mayúscula" + Environment.NewLine);
            customersUI.GetCustomersNamesInUpperOrLower(true);
            Console.WriteLine(Environment.NewLine + "Nombres de los Customers en Minúscula" + Environment.NewLine);
            customersUI.GetCustomersNamesInUpperOrLower();
            Console.WriteLine("7. Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997.");
            customersUI.GetCustomersNamesAndOrdersByRegionAndDate("WA", new DateTime(1997, 1, 1));
            Console.WriteLine("8. Query para devolver los primeros 3 Customers de la  Región WA");
            customersUI.GetCustomersByRegion("WA", 3);
            Console.WriteLine("9. Query para devolver lista de productos ordenados por nombre.");
            productsUI.GetProductsOrderedByName();
            Console.WriteLine("10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor.");
            productsUI.GetProductsOrderedByUnitsInStockDesc();
            Console.WriteLine("11. Query para devolver las distintas categorías asociadas a los productos.");
            productsUI.GetCategoriesRelatedToProducts();
            Console.WriteLine("12. Query para devolver el primer elemento de una lista de productos.");
            productsUI.GetFirstProduct();
            Console.WriteLine("13. Query para devolver los customer con la cantidad de ordenes asociadas.");
            customersUI.GetCustomersAndRelatedOrdersQuantity();
            Console.WriteLine(Environment.NewLine);
        }
    }
}
