using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionApp.Exceptions
{
    public class DivisionExceptions
    {
        public static void ThrowCustomException()
        {
            throw new CustomException();
        }
        public static void ThrowExceptions() {
			try
			{
				 
			}
			catch (DivideByZeroException e)
			{

				throw e;
			}
			catch (Exception e)
			{
				throw e;
			}
        }

        public static void DoDivision(int a, int b)
        {
            try
            {
                int result = a/b;

                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("¡Solo Chuck Norris divide por 0!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exepcion: {e.Message}");                
            }
        }
    }
}
