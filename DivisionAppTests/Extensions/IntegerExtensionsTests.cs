using Microsoft.VisualStudio.TestTools.UnitTesting;
using DivisionApp.Extensions;
using System;
using DivisionApp.Exceptions;

namespace DivisionApp.Extensions.Tests
{
    [TestClass()]
    public class IntegerExtensionsTests
    {
        [TestMethod()]
        public void DoDivisionTest1()
        {            
            /*
             * Excercise 1
             * Test default Divided By Zero by passing 1 argument.
             */
            Action result = () => DivisionApp.Extensions.IntegerExtensions.DoDivision(3);
            Assert.ThrowsException<DivideByZeroException>(result);                
        }

        [TestMethod()]
        public void DoDivisionTest2()
        {
            /*
             * Excercise 2
             * Test normal division by passing 2 arguments.
             */
            decimal result = DivisionApp.Extensions.IntegerExtensions.DoDivision(60, 4);
            Assert.AreEqual(15, result);
        }

        [TestMethod()]
        public void DoDivisionTest3()
        {
            /*
             * Excercise 2.1
             * Test triggering of Custom Divided By Zero by passing 0.
             */
            Action result = () => DivisionApp.Extensions.IntegerExtensions.DoDivision(10, 0);
            Assert.ThrowsException<DivideByZeroException>(result);           
        }       
    }
}