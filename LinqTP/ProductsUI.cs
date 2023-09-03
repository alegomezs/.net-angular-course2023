using LinqTP.Entities;
using LinqTP.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTP
{
    public class ProductsUI
    {
        private ProductsLogic productsLogic;

        public ProductsUI()
        {
            productsLogic = new ProductsLogic();
        }

        public void GetProductsInStock()
        {
            Console.Write("{0,-10} {1,-35} {2,-15} {3,-15}", "ID", "Producto", "Precio", "Unidad en Stock");
            Console.WriteLine("\n_________________________________________________________________________________\n");            
            foreach (var item2 in productsLogic.GetProductsInStock())
            {
                Console.WriteLine("{0,-10} {1,-35:N1} {2,-15:N1} {3,-15:N1}", item2.ProductID, item2.ProductName, item2.UnitPrice, item2.UnitsInStock);
            }            
            Continue();
        }

        public void GetProductsInStockByCertainPrice(decimal precio)
        {
            Console.Write("{0,-10} {1,-35} {2,-15} {3,-15}", "ID", "Producto", "Precio", "Unidad en Stock");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            foreach (var item3 in productsLogic.GetProductsInStockByCertainPrice(precio))
            {
                Console.WriteLine("{0,-10} {1,-35:N1} {2,-15:N1} {3,-15:N1}", item3.ProductID, item3.ProductName, item3.UnitPrice, item3.UnitsInStock);
            }
            Continue();
        }

        public void GetFirstProductOrNullById(int id)
        {
            Console.Write("{0,-10} {1,-35} {2,-15} {3,-15}", "ID", "Producto", "Precio", "Unidad en Stock");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            Products item5 = productsLogic.GetFirstProductOrNullById(id);

            if (item5 == null)
            {
                Console.WriteLine($"No se encontró producto con ID: {id}");
            }
            else
            {
                Console.WriteLine("{0,-10} {1,-35:N1} {2,-15:N1} {3,-15:N1}", item5.ProductID, item5.ProductName, item5.UnitPrice, item5.UnitsInStock);
            }
            Continue();
        }

        public void GetProductsOrderedByName()
        {            
            Console.Write("{0,-10} {1,-35} {2,-15} {3,-15}", "ID", "Producto", "Precio", "Unidad en Stock");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            foreach (var item9 in productsLogic.GetProductsOrderedByName())
            {
                Console.WriteLine("{0,-10} {1,-35:N1} {2,-15:N1} {3,-15:N1}", item9.ProductID, item9.ProductName, item9.UnitPrice, item9.UnitsInStock);
            }
            Continue();
        }

        public void GetProductsOrderedByUnitsInStockDesc()
        {
            Console.Write("{0,-10} {1,-35} {2,-15} {3,-15}", "ID", "Producto", "Precio", "Unidad en Stock");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            foreach (var item10 in productsLogic.GetProductsOrderedByUnitsInStockDesc())
            {
                Console.WriteLine("{0,-10} {1,-35:N1} {2,-15:N1} {3,-15:N1}", item10.ProductID, item10.ProductName, item10.UnitPrice, item10.UnitsInStock);
            }
            Continue();
        }

        public void GetCategoriesRelatedToProducts()
        {
            Console.Write("{0,-10} {1,-35}", "ID", "Nombre de Categoría");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            foreach (var item11 in productsLogic.GetCategoriesRelatedToProducts())
            {
                Console.WriteLine("{0,-10} {1,-35:N1}", item11.CategoryID, item11.CategoryName);
            }
            Continue();
        }

        public void GetFirstProduct()
        {
            Console.Write("{0,-10} {1,-35} {2,-15} {3,-15}", "ID", "Producto", "Precio", "Unidad en Stock");
            Console.WriteLine("\n_________________________________________________________________________________\n");
            var item12 = productsLogic.GetFirstProduct();
            Console.WriteLine("{0,-10} {1,-35:N1} {2,-15:N1} {3,-15:N1}", item12.ProductID, item12.ProductName, item12.UnitPrice, item12.UnitsInStock);
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
