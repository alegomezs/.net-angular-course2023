using DivisionApp.Exceptions;
using DivisionApp.Extensions;
using System;

namespace DivisionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Practica 2" + Environment.NewLine);
            bool flag = false;
            decimal dividend = 0;
            /*
             * User inputs for the first two Excercises.
             */
            do
            {
                try
                {
                    Console.WriteLine("Ingrese Dividendo y presione ENTER:");
                    dividend = decimal.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Cargando Dividendo..." + Environment.NewLine);
                }

            } while (!flag);

            flag = false;
            decimal divisor = 0;

            do
            {
                try
                {
                    Console.WriteLine("Ingrese Divisor y presione ENTER:");
                    divisor = decimal.Parse(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("¡Seguro Ingreso una letra o no ingreso nada!");
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Cargando Divisor..." + Environment.NewLine);
                }

            } while (!flag);
           
            Console.WriteLine("Ejecutando operaciones..." + Environment.NewLine);            

            /*
             * Excercise 1            
             */
            FirstExcercise(dividend);


            /*
             * Excercise 2             
             */
            SecondExcercise(dividend, divisor);

            /*
             * Excercise 3            
             */
            try
            {
                Console.WriteLine("Ejercicio 3");
                Logic.ExceptionExcercice3();
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine($"Excepcion disparada: {ex.Message}");
                Console.WriteLine($"Exception de tipo: {ex.GetType().ToString()} { Environment.NewLine}");
            }
            finally
            {
                Console.WriteLine("Fin del ejercicio 3." + Environment.NewLine);
            }

            /*
             * Excercise 4            
             */
            flag = false;
            do
            {
                try
                {
                    Console.WriteLine("Ejercicio 4");
                    Console.WriteLine("Ingrese mensaje personalizado de la Custom Excepcion y presione ENTER:");                   
                    Logic.ExceptionExcercice4(Console.ReadLine());                    
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("¡Seguro no ingreso nada!");
                    Console.WriteLine($"Error: {ex.Message} {Environment.NewLine}");
                }
                catch (CustomException ex)
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine(ex.Message + Environment.NewLine);
                    flag = true;
                }
                finally
                {
                    if (flag) {
                        Console.WriteLine("Fin del ejercicio 4." + Environment.NewLine);
                    } else
                    {
                        Console.WriteLine(Environment.NewLine);
                    }
                }
            } while (!flag);

            Console.WriteLine("Presione ENTER para salir");
            Console.ReadLine();

        }

        /*
         *  First excercise method 
         */
        public static void FirstExcercise(decimal dividend)
        {
            Console.WriteLine("- Ejercicio 1: Division por 0");
            try
            {       
                Console.WriteLine($"Resultado: {dividend.DoDivision()}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Division fianlizada!"+ Environment.NewLine);                
            }
        }

        /*
         * Second excercise method with 'Chuck Norris' Exception
         */
        public static void SecondExcercise(decimal dividend, decimal divisor)
        {
            Console.WriteLine("- Ejercicio 2: Division con ambos valores");
            DivisionExceptions.Division(dividend, divisor, true);
        }

    }
}
