using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionApp.Exceptions
{
    public class CustomException : Exception
    {
        private string message;

        public CustomException(String message)
        {
            this.message = message;
        }   
        
        public override string Message
        {
            get
            {
                return $"Mensaje personalizado: {message}";
            }
        }
    }
}
