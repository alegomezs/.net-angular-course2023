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
            int transportAmount = 10;
            while (!salir)
            {
                try
                {
                    //App Menu
                    AppMenu(omnibusID, taxiID, transportList.Count);
                    int opcion = int.Parse(Console.ReadLine());
                    int input;

                    switch (opcion)
                    {
                        case 1:
                            /*
                            * Set the amount of passengers for this Transport and sets an ID to it.
                            */
                            if (transportList.Count != transportAmount)
                            {
                                if (omnibusID < 5)
                                {
                                    Console.Clear();
                                    Console.WriteLine("CANTIDADD DE PASAJEROS:");
                                    Console.WriteLine("INGRESAR LA CANTIDAD Y PRESIONAR 'ENTER'");
                                    input = int.Parse(Console.ReadLine());
                                    try
                                    {
                                        omnibusID += 1;
                                        Omnibus omnibus = new Omnibus(omnibusID, input);
                                        transportList.Add(omnibus);
                                        Console.Clear();
                                    }
                                    catch (FormatException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("CUPO DE OMNIBUS COMPLETO");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("CUPO DE TRANSPORTES COMPLETO");
                                Console.WriteLine();
                            }
                            break;
                        case 2:
                            /*
                            * Set the amount of passengers for this Transport and sets an ID to it.
                            */
                            if (transportList.Count != transportAmount)
                            {
                                if (taxiID < 5)
                                {
                                    Console.Clear();
                                    Console.WriteLine("CANTIDADD DE PASAJEROS:");
                                    Console.WriteLine("INGRESAR LA CANTIDAD Y PRESIONAR 'ENTER'");
                                    input = int.Parse(Console.ReadLine());
                                    try
                                    {
                                        taxiID += 1;
                                        Taxi taxi = new Taxi(taxiID, input);
                                        transportList.Add(taxi);
                                        Console.Clear();
                                    }
                                    catch (FormatException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("CUPO DE TAXIS COMPLETO");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("CUPO DE TRANSPORTES COMPLETO");
                                Console.WriteLine();
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
                                    Console.WriteLine("{0}: {1}", transport.Description(), transport.CapacityStatus());
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 4:
                            AppSubMenu(transportList);
                            break;
                        case 5:
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


        public static void AppMenu(int a, int b, int c)
        {
            Console.WriteLine("- TRANSPORTES ADMIN -");
            Console.WriteLine("CUPO DE TRANSPORTES A COMPLETAR ({0}/10)", c);
            Console.WriteLine();
            Console.WriteLine("1. CARGAR OMNIBUS ({0}/5)", a);
            Console.WriteLine("2. CARGAR TAXI ({0}/5)", b);
            Console.WriteLine("3. LISTAR");
            Console.WriteLine("4. INDICAR ACCION");
            Console.WriteLine("5. SALIR");
            Console.WriteLine("INGRESAR OPCION Y PRESIONAR 'ENTER'");
        }

        public static void AppSubMenu(List<Transport> transportList)
        {
            Console.WriteLine("-- INDICAR ACCION --");
            Console.WriteLine();
            if (transportList.Count == 0) {
                Console.WriteLine("SIN TRANSPORTES CARGADOS PARA LA ACCION");
            }
            else
            {
                Console.WriteLine("SELECCIONE UNIDAD POR ID:");                
                foreach (Transport transport in transportList)
                {                   
                    Console.WriteLine(transport.Description());
                }
                int input = int.Parse(Console.ReadLine());
                if (input != 0)
                {
                    Console.WriteLine("SELECCIONE ACCION: ");
                    Console.WriteLine();
                    Console.WriteLine("1. AVANZAR");
                    Console.WriteLine("2. DETENERSE");
                }
            }
        }
    }
}
