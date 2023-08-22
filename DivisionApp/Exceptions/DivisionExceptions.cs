using System;
using DivisionApp.Extensions;

namespace DivisionApp.Exceptions
{
    public class DivisionExceptions
    {
        public static void Division(decimal dividend, decimal divisor, bool doing)
        {
            try
            {
                Console.WriteLine($"Resultado: {dividend.DoDivision(divisor)}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("¡Solo Chuck Norris divide por 0!");
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Division finalizada!" + Environment.NewLine);                
            }
        }
    }
}
