using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionApp.Exceptions
{
    public class Logic
    {
        public static void ExceptionExcercice3()
        {
            throw new ArithmeticException();
        }

        public static void ExceptionExcercice4(string message)
        {
            if (message != "") {
                throw new CustomException(message);
            }
            else
            {
                throw new FormatException();
            }
        }        
    }
}
