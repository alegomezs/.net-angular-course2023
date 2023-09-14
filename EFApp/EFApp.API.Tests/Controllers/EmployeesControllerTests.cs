using EFApp.Entities;
using EFApp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EFApp.Logic;

namespace EFApp.API.Controllers.EmployeesApiController.Tests
{
    [TestClass()]
    public class EmployeesControllerTests
    {
        [TestMethod()]
        public void GetEmployeesTest()
        {
            var data = new List<Employees>
            {
                new Employees { FirstName = "Speedy", LastName = "Gonzalez", HomePhone = "(503) 555-9831" },
                new Employees { FirstName = "Fort", LastName = "Ricardo", HomePhone = "(503) 555-3199" },
                new Employees { FirstName = "Quien", LastName = "Te conoce?", HomePhone = "(503) 555-9931" },
            }.AsQueryable();


            var mockSet = new Mock<DbSet<Employees>>();
            mockSet.As<IQueryable<Employees>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Employees>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Employees>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Employees>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Employees).Returns(mockSet.Object);

            ICRUDLogic<Employees> employeesLogic = new EmployeesLogic(mockContext.Object);

            Assert.IsTrue(employeesLogic.GetAll().Count > 0);
        }
    }
}