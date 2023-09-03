using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqTP.Logic;

namespace LinqTP
{
    public class CustomersUI
    {
        private CustomersLogic customersLogic;

        public CustomersUI()
        {
            customersLogic = new CustomersLogic();
        }

        public void GetCustomers()
        {             
            Console.Write("{0,-10} {1,-30} {2,-15}", "ID", "Nombre de Contacto", "Región");
            Console.WriteLine("\n____________________________________________________\n");
            foreach (var item1 in customersLogic.GetCustomers())
            {
                Console.WriteLine("{0,-10} {1,-30:N1} {2,-15:N1}", item1.CustomerID, item1.ContactName, item1.Region);
            }
            Continue();
        }

        public void GetCustomersByRegion(string region)
        {           
            Console.Write("{0,-10} {1,-30} {2,-15}", "ID", "Nombre de Contacto", "Región");
            Console.WriteLine("\n____________________________________________________\n");
            foreach (var item4 in customersLogic.GetCustomersByRegion(region))
            {
                Console.WriteLine("{0,-10} {1,-30:N1} {2,-15:N1}", item4.CustomerID, item4.ContactName, item4.Region);
            }
            Continue();
        }

        public void GetCustomersNamesInUpperOrLower(bool toUpper = false)
        {           
            Console.Write("{0,-10} {1,-30} {2,-15}", "ID", "Nombre de Contacto", "Región");
            Console.WriteLine("\n____________________________________________________\n");
            foreach (var item6a in customersLogic.GetCustomersNamesInUpperOrLower(toUpper))
            {
                Console.WriteLine("{0,-10} {1,-30:N1} {2,-15:N1}", item6a.CustomerID, item6a.ContactName, item6a.Region);
            }
            Continue();
        }

        public void GetCustomersNamesAndOrdersByRegionAndDate(string region, DateTime ordenFecha)
        {           
            Console.Write("{0,-10} {1,-30} {2,-15} {3,-15}", "ID", "Nombre de Contacto", "Región", "Fecha de Orden");
            Console.WriteLine("\n____________________________________________________________________________________\n");
            var query = customersLogic.GetCustomersNamesAndOrdersByRegionAndDate(region, ordenFecha);
            if (query.Count == 0)
            {
                Console.WriteLine($"No hay Ordenes de Clientes de la Región: {region} en la Fecha: {ordenFecha.ToShortDateString()}");
            }
            else
            {
                foreach (var item7 in query)
                {
                    Console.WriteLine("{0,-10} {1,-30:N1} {2,-15:N1} {3,-15}", item7.CustomerID, item7.ContactName, item7.Region, item7.OrderDate);
                }
            }
            Continue();
        }

        public void GetCustomersByRegion(string region, int limit)
        {           
            Console.Write("{0,-10} {1,-30} {2,-15}", "ID", "Nombre de Contacto", "Región");
            Console.WriteLine("\n____________________________________________________\n");
            foreach (var item8 in customersLogic.GetCustomersByRegion("WA", 3))
            {
                Console.WriteLine("{0,-10} {1,-30:N1} {2,-15:N1}", item8.CustomerID, item8.ContactName, item8.Region);
            }
            Continue();
        }

        public void GetCustomersAndRelatedOrdersQuantity()
        {            
            Console.Write("{0,-10} {1,-35} {2,-15}", "ID", "Nombre de Contacto", "Cantidad de Ordenes");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            foreach (var item13 in customersLogic.GetCustomersAndRelatedOrdersQuantity())
            {
                Console.WriteLine("{0,-10} {1,-35:N1} {2,-15}", item13.CustomerID, item13.ContactName, item13.CountOrders);
            }
            Continue();
        }

        public void Continue()
        {
            Console.WriteLine(Environment.NewLine +
               "Presiona ENTER para siguiente query ..." +
               Environment.NewLine);
            Console.ReadLine();
        }
    }
}
