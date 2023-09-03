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
    public class ProductsLogic : BaseLogic
    {
        public ProductsLogic() { }

        public ProductsLogic(NorthwindContext context) : base(context)
        {
        }

        public List<Products> GetProductsInStock()
        {
            // 2.Query para devolver todos los productos sin stock
            return context.Products.Where(p => p.UnitsInStock == 0).ToList();
        }

        public List<Products> GetProductsInStockByCertainPrice(decimal precio)
        {
            // 3. Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad            
            return (from product in context.Products
                    where product.UnitsInStock > 0 && product.UnitPrice > precio
                    select product).ToList();
        }

        public Products GetFirstProductOrNullById(int id)
        {
            // 5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789
            return context.Products.Where(p => p.ProductID == id).FirstOrDefault();
        }

        public List<Products> GetProductsOrderedByName()
        {
            // 9. Query para devolver lista de productos ordenados por nombre
            return (from product in context.Products
                    orderby product.ProductName
                    select product).ToList();
        }

        public List<Products> GetProductsOrderedByUnitsInStockDesc()
        {
            // 10. Query para devolver lista de productos ordenados por unit in stock de mayor a menor.
            return context.Products.OrderByDescending(p => p.UnitsInStock).ToList();
        }

        public List<ProductsDTO> GetCategoriesRelatedToProducts()
        {
            // 11. Query para devolver las distintas categorías asociadas a los productos
            var query =
                (from product in context.Products
                 join category in context.Categories on product.CategoryID 
                 equals category.CategoryID
                 select new ProductsDTO { 
                     CategoryID = category.CategoryID, 
                     CategoryName = category.CategoryName 
                 }).Distinct();
            return query.ToList();
        }

        public Products GetFirstProduct()
        {
            // 12. Query para devolver el primer elemento de una lista de productos
            return (from product in context.Products
                    select product).FirstOrDefault();
        }
    }
}
