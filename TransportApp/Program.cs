using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp
{
    internal class Program
    {
        static void Main(string[] args)
        {         
            bool salir = false;
           
            List<Transport> transportList = new List<Transport>();

            int taxiID = 0;
            int omnibusID = 0;
            while (!salir)
            {
                try
                {
                    //App Menu
                    Console.WriteLine("PASAJEROS * TRANSPORTES ADMIN");
                    Console.WriteLine("1. CARGAR OMNIBUS");
                    Console.WriteLine("2. CARGAR TAXI");
                    Console.WriteLine("3. LISTAR");
                    Console.WriteLine("4. SALIR");
                    Console.WriteLine("INGRESAR OPCION Y PRESIONAR 'ENTER'");
                    int opcion = int.Parse(Console.ReadLine());
                    int amount;
                   
                    switch (opcion)
                    {
                        case 1:
                            /*
                            * Set the amount of passengers for this Transport and sets an ID to it.
                            */                          
                            Console.Clear();
                            Console.WriteLine("CANTIDADD DE PASAJEROS:");
                            Console.WriteLine("INGRESAR LA CANTIDAD Y PRESIONAR 'ENTER'");
                            amount = int.Parse(Console.ReadLine());
                            try
                            {
                                omnibusID += 1;
                                Omnibus omnibus = new Omnibus(omnibusID, amount);
                                transportList.Add(omnibus);
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 2:
                            /*
                            * Set the amount of passengers for this Transport and sets an ID to it.
                            */
                            Console.Clear();
                            Console.WriteLine("CANTIDADD DE PASAJEROS:");
                            Console.WriteLine("INGRESAR LA CANTIDAD Y PRESIONAR 'ENTER'");
                            amount = int.Parse(Console.ReadLine());
                            try
                            {
                                taxiID += 1;
                                Taxi taxi = new Taxi(taxiID, amount);
                                transportList.Add(taxi);
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 3:
                            /*
                             * Display a list of different Transport and their descriptions.
                             */
                            Console.Clear();
                            try
                            {
                                foreach (Transport transport in transportList)
                                {
                                    Console.WriteLine(transport.ShowPassengersAmount());
                                }
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 4:
                            //Exit the App
                            Console.Clear();
                            Console.WriteLine("SALIENDO");
                            salir = true;
                            break;                      
                        default:
                            Console.WriteLine("LA OPCION INGRESADA NO EXISTE");
                            break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        
        public static void showPassengers()
        {
           
        }
        
    }
}
