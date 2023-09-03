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
    public class CustomersLogicTests
    {
        [TestMethod()]
        public void GetCustomersTest()
        {
            var data = new List<Customers>
            {
                new Customers { CustomerID = "HAHAH", ContactName = "Napoleon Goodpart", Region = "WA" },
                new Customers { CustomerID = "CRASH", ContactName = "Ricardo Fort", Region = "BC" },
                new Customers { CustomerID = "PUUMM", ContactName = "Bruce Lee", Region = "SP" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customers>>();
            mockSet.As<IQueryable<Customers>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customers>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Customers).Returns(mockSet.Object);

            CustomersLogic customersLogic = new CustomersLogic(mockContext.Object);

            var clientes = customersLogic.GetCustomers();

            Assert.AreEqual(3, clientes.Count);
            Assert.AreEqual("HAHAH", clientes[0].CustomerID);
            Assert.AreEqual("CRASH", clientes[1].CustomerID);
            Assert.AreEqual("PUUMM", clientes[2].CustomerID);
            Assert.Fail();
        }
    }
}