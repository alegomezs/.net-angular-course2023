using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqTP.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqTP.Data;
using LinqTP.Entities;
using Moq;
using System.Data.Entity;

namespace LinqTP.Logic.Tests
{
    [TestClass()]
    public class ProductsLogicTests
    {
        [TestMethod()]
        public void GetProductsInStockTest()
        {
            var data = new List<Products>
            {
                new Products { ProductID = 1, ProductName = "Chai", UnitPrice = 18.00M, UnitsInStock = 0 },
                new Products { ProductID = 2, ProductName = "Chang", UnitPrice = 19.00M, UnitsInStock = 17 },
                new Products { ProductID = 3, ProductName = "Aniseed Syrup", UnitPrice = 10.00M, UnitsInStock = 13 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Products>>();
            mockSet.As<IQueryable<Products>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Products>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Products>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Products>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            ProductsLogic productsLogic = new ProductsLogic(mockContext.Object);

            var productos = productsLogic.GetProductsInStock();

            Assert.AreEqual(1, productos.Count);
            Assert.AreEqual(1, productos[0].ProductID);
            Assert.Fail();
        }
    }
}