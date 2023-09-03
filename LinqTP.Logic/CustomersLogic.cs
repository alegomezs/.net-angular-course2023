using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqTP.Data;
using LinqTP.Entities;
using LinqTP.Logic.DTO;

namespace LinqTP.Logic
{
    public class CustomersLogic : BaseLogic
    {
        public CustomersLogic() { }

        public CustomersLogic(NorthwindContext context) : base(context)
        {
        }
        
        public List<Customers> GetCustomers()
        {
            // 1. Query para devolver objeto customer
            return (
                from customer in context.Customers
                select customer).ToList();
        }

        public List<Customers> GetCustomersByRegion(string region, int quantity = 0)
        {
            // 4. Query para devolver todos los customers de la Región WA
            var query = context.Customers.Where(c => c.Region == region);
            if (quantity > 0)
            {
                // 8. Query para devolver los primeros 3 Customers de la  Región WA
                query.Take(quantity);
            }
            return query.ToList();
        }

        public List<CustomersDTO> GetCustomersNamesInUpperOrLower(bool toUpper = false)
        {
            // 6. Query para devolver los nombre de los Customers. Mostrarlos en Mayúscula y en Minúscula.
            var query = from customer in context.Customers
                        select new CustomersDTO()
                        {
                            CustomerID = customer.CustomerID,
                            ContactName = toUpper ? customer.ContactName.ToUpper() : customer.ContactName.ToLower(),
                            Region = customer.Region
                        };

            return query.ToList();
        }

        public List<CustomersDTO> GetCustomersNamesAndOrdersByRegionAndDate(string region, DateTime ordenFecha)
        {
            // 7. Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.
            var query = context.Customers.Join(context.Orders
                                        , c => c.CustomerID
                                        , o => o.CustomerID
                                        , (c, o) => new { c, o }
                                        ).Select(f => new CustomersDTO
                                        {
                                            CustomerID = f.c.CustomerID,
                                            ContactName = f.c.ContactName,
                                            Region = f.c.Region,
                                            OrderDate = f.o.RequiredDate
                                        }
                                        ).Where(z => z.Region == region && z.OrderDate == ordenFecha);

            return query.ToList();
        }

        public List<CustomersDTO> GetCustomersAndRelatedOrdersQuantity()
        {
            // 13. Query para devolver los customer con la cantidad de ordenes asociadas
            var query =
                (from customer in context.Customers
                 join order in context.Orders on customer.CustomerID equals order.CustomerID
                 select new { customer.CustomerID, customer.ContactName, order.OrderID } into x
                 group x by new { x.CustomerID, x.ContactName } into g
                 select new CustomersDTO
                 {
                     CustomerID = g.Key.CustomerID,
                     ContactName = g.Key.ContactName,
                     CountOrders = g.Select(x => x.OrderID).Count()
                 });
            return query.ToList(); ;
        }
    }
}
