using Microsoft.VisualStudio.TestTools.UnitTesting;
using DivisionApp.Exceptions;
using System;


namespace DivisionApp.Exceptions.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void ExceptionExcercice3Test()
        {
            /*
             * Excercise 3
             * Test triggering an Exception.
             */
            Action result = () => DivisionApp.Exceptions.Logic.ExceptionExcercice3();
            Assert.ThrowsException<ArithmeticException>(result);
        }

        [TestMethod()]
        public void ExceptionExcercice4Test()
        {
            /*
             * Excercise 4
             * Test triggering a Custom Message exception.
             */
            string message = "Mensaje de prueba Unit Test.";
            Action result = () => DivisionApp.Exceptions.Logic.ExceptionExcercice4(message);
            Assert.ThrowsException<CustomException>(result);
        }
    }
}