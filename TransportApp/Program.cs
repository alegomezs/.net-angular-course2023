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
            int taxiID = 0;
            int omnibusID = 0;
           
            List<Transport> transportList = new List<Transport>();

            while (!salir)
            {
                try
                {
                    Console.WriteLine("PASAJEROS * TRANSPORTES ADMIN");
                    Console.WriteLine("1. CARGAR OMNIBUS");
                    Console.WriteLine("2. CARGAR TAXI");
                    Console.WriteLine("3. LISTAR");
                    Console.WriteLine("4. SALIR");
                    Console.WriteLine("INGRESAR OPCION Y PRESIONAR 'ENTER'");
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("CANTIDADD DE PASAJEROS:");
                            Console.WriteLine("INGRESAR LA CANTIDAD Y PRESIONAR 'ENTER'");
                            try
                            {
                                omnibusID += 1; 
                                Omnibus omnibus = new Omnibus(omnibusID, Convert.ToInt32(Console.ReadLine()));
                                transportList.Add(omnibus);
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 2:
                            Console.WriteLine("CANTIDADD DE PASAJEROS:");
                            Console.WriteLine("INGRESAR LA CANTIDAD Y PRESIONAR 'ENTER'");
                            try
                            {
                                taxiID += 1;
                                Taxi taxi = new Taxi(taxiID, Convert.ToInt32(Console.ReadLine()));
                                transportList.Add(taxi);
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 3:
                            foreach(Transport transport in transportList)
                            {
                                Console.WriteLine(transport.PassengersAmount);
                            }
                            break;
                        case 4:
                            Console.WriteLine("SALIENDO");
                            salir = true;
                            break;                      
                        default:
                            UndefinedOption();
                            break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void UndefinedOption()
        {
            Console.WriteLine("LA OPCION INGRESADA NO EXISTE");
        }
        /*
        public static void CreateTransport()
        {
            Console.WriteLine("");
            Console.WriteLine("TIPO DE UNIDAD:");
            Console.WriteLine("1. OMNIBUS");
            Console.WriteLine("2. TAXI");
            Console.WriteLine("INGRESAR OPCION Y PRESIONAR 'ENTER'");
            int opcion = Convert.ToInt32(Console.ReadLine());
            switch(opcion)
            {
                case 1:
                   
                    
                    break;
                case 2:
                    break;
                default:
                    Console.WriteLine("LA OPCION INGRESADA NO EXISTE");
                    break;
            }
        }
        */
    }
}
