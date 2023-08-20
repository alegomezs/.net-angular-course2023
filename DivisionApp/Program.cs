using DivisionApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Division App");
            Console.WriteLine("Ingrese dos valores");
            try
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                DivisionExceptions.DoDivision(a, b);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Excepcion de Formato: {e.Message}"); ;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Excepcion {e.Message}");
            }
            finally
            {
                Console.WriteLine("Operacion exitosa");
            }
        }
    }
}
