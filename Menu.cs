using DPRN2_U1_EA_JUPM.Modelos;
using System.Runtime.Intrinsics.X86;

namespace DPRN2_U1_EA_JUPM
{
    internal class Menu
    {
        static void Main(string[] args)
        {
            Int32 opc;
            funcionesMenu fMenu = new funcionesMenu();

            /*
             Menu principal que llama a las demas clases para realizar el proceso de 
            identificacion de rostro
             */

            do
            {

                Console.WriteLine("\tBioTech");

                Console.WriteLine("1.- Carga de rostros");
                Console.WriteLine("2.- Reconocimiento facial 1");
                Console.WriteLine("3.- Reconocimiento facial 2");
                Console.WriteLine("4.- Salir");
                Console.Write("Opcion: ");

                while (!int.TryParse(Console.ReadLine(), out opc) || (opc < 1 || opc > 4))
                {

                    Console.WriteLine("Ingresa un valor numerico o dentro del rango");
                }

                Console.Clear();

                /*
            Seleccion de opciones por medio de switch - case.
                opcion1.- Muestra formulario para cargar los rostros a identificar
                opcion2.- Muestra la identificacion con el algoritmoUno
                opcion3.- Muestra la identificacion con el algoritmoDos
                opcion4.- Termina ejecucion de programa
             */

                switch (opc)
                {
                    case 1:
                        fMenu.cargaRostros();
                        break;
                    case 2:

                        if (fMenu.Rostros.Count > 0)
                        {
                            fMenu.facial1();
                        }
                        else
                        {
                            Console.WriteLine("Sin rostros que reconocer. Cargar rostros!!");
                        }
                        break;
                    case 3:
                        if (fMenu.Rostros.Count > 0)
                        {
                            fMenu.facial2();
                        }
                        else
                        {
                            Console.WriteLine("Sin rostros que reconocer. Cargar rostros!!");
                        }
                        break;
                    default:
                        Console.WriteLine("Saliendo...");
                        break;
                }

                Console.ReadLine();
                Console.Clear();

            } while (opc != 4);
        }
    }
}