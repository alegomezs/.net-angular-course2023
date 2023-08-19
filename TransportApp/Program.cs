using System;
using System.Collections;
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
                                    Console.WriteLine("INGRESAR CANTIDAD Y PRESIONAR 'ENTER'");
                                    input = int.Parse(Console.ReadLine());
                                    try
                                    {
                                        int capacity = 80;
                                        if (input <= capacity)
                                        {
                                            omnibusID += 1;
                                            Omnibus omnibus = new Omnibus(omnibusID, input, 1);
                                            transportList.Add(omnibus);
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("LA CAPACIDAD DE PASAJEROS ES HASTA {0}", capacity);                                          
                                        }                                                                               
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
                                    Console.WriteLine("INGRESAR CANTIDAD Y PRESIONAR 'ENTER'");
                                    input = int.Parse(Console.ReadLine());
                                    try
                                    {
                                        int capacity = 4;
                                        if (input <= capacity)
                                        {
                                            taxiID += 1;
                                            Taxi taxi = new Taxi(taxiID, input, 2);
                                            transportList.Add(taxi);
                                        }
                                        else
                                        {                                            
                                            Console.WriteLine("LA CAPACIDAD DE PASAJEROS ES HASTA {0}", capacity);                                            
                                        }                                                                               
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
                                //Sorts the list by Transport type.
                                List<Transport> transoportSorted = transportList.OrderBy(t => t.TransportType).ToList();
                                
                                foreach (Transport transport in transoportSorted)
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
                            /*
                             * Go to Accions Menu.
                             */
                            AppSubMenu(transportList);
                            break;
                        case 5:
                            //Exit the App.
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
                Console.WriteLine();
            }
        }

        /*
         * Main App Menu.
         */
        private static void AppMenu(int a, int b, int c)
        {
            Console.WriteLine("- TRANSPORTES ADMIN -");
            Console.WriteLine("[TOTAL DE UNIDADES CARGADAS: {0}/10]", c);
            Console.WriteLine();
            Console.WriteLine("1. CARGAR OMNIBUS [{0}/5]", a);
            Console.WriteLine("2. CARGAR TAXI [{0}/5]", b);
            Console.WriteLine("3. LISTAR");
            Console.WriteLine("4. INDICAR ACCION");
            Console.WriteLine("5. SALIR");
            Console.WriteLine("INGRESAR OPCION Y PRESIONAR 'ENTER'");
        }

        /*
         * Accions Menu,
         */
        private static void AppSubMenu(List<Transport> transportList)
        {
            Console.Clear();
            Console.WriteLine("-- INDICAR ACCION --");
            Console.WriteLine();
            if (transportList.Count == 0) {
                Console.WriteLine("SIN TRANSPORTES CARGADOS PARA LA ACCION");
            }
            else
            {
                int option = 0;
                Console.WriteLine("SELECCIONE UNIDAD:");                
                foreach (Transport transport in transportList)
                {                   
                    Console.WriteLine("{0}. {1}", option++, transport.Description());
                }
                int input = int.Parse(Console.ReadLine());
                if (input >= 0 && input <= transportList.Count)
                {
                    Console.Clear();
                    Console.WriteLine("SELECCIONE ACCION: ");
                    Console.WriteLine();
                    Console.WriteLine("1. AVANZAR");
                    Console.WriteLine("2. DETENERSE");
                    int action = int.Parse(Console.ReadLine());
                    try
                    {
                        for (int i = 0; i < transportList.Count; i++)
                        {
                            if (i == input)
                            {
                                switch (action)
                                {
                                    case 1:
                                        Console.WriteLine("{0}: {1}", transportList[i].Description(), transportList[i].Move());
                                        break;
                                    case 2:
                                        Console.WriteLine("{0}: {1}", transportList[i].Description(), transportList[i].Stop());
                                        break;
                                    default:
                                        Console.WriteLine("LA OPCION INGRESADA NO EXISTE");
                                        break;
                                }
                            }
                            
                        }
                        Console.WriteLine();
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            }
        }
    }
}
