using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DPRN2_U1_EA_JUPM.Modelos
{
    class funcionesMenu
    {

        String patronTextura, forma, tipoPiel, aspectoFacial, otro;
        Int32 opc2, porcentajePiel = 0, edad = 0, cont = 1, cont2;
        List<Rostro> rostros = new List<Rostro>();
        ReconocimientoFacial recoFacial;

        internal List<Rostro> Rostros {
            get => rostros; 
            set => rostros = value;
        }

        /*
             Clase de funcionalidades de carga e identificacion de rostros
             */

        /*
             Metodo para cargar informacion de los rostros, se implementa 
        un bucle que pide 2 veces la carga.
             */
        public void cargaRostros()
        {
            cont2 = 1;

            rostros.Clear();

            do
            {
                List<string> aspectoFaciales = new List<string>();
                List<string> otros = new List<string>();
                cont = 1;

                Console.WriteLine($"\tRostro {cont2}");

                Console.Write("Ingresa el patron de textura: ");
                patronTextura = Console.ReadLine();

                Console.Write("Ingresa el forma: ");
                forma = Console.ReadLine();

                Console.Write("Ingresa el tipo piel: ");
                tipoPiel = Console.ReadLine();

                Console.Write("Ingresa el porcentaje piel: ");

                while (!int.TryParse(Console.ReadLine(), out porcentajePiel) ||
                    (porcentajePiel < 1 || porcentajePiel > 100))
                {

                    Console.WriteLine("Ingresa un valor numerico o dentro del rango");
                }

                do
                {
                    Console.Write($"Ingresa el aspecto facial {cont}: ");
                    aspectoFacial = Console.ReadLine();

                    aspectoFaciales.Add(aspectoFacial);

                    Console.Write("Desea ingresar mas valores(CONTINUAR = 1 --- SALIR = 0)? ");
                    while (!int.TryParse(Console.ReadLine(), out opc2))
                    {

                        Console.WriteLine("Ingresa un valor numerico o dentro del rango");
                    }

                    cont++;

                } while (opc2 != 0);

                Console.Write("Ingresa el edad: ");

                while (!int.TryParse(Console.ReadLine(), out edad) ||
                    (edad < 1 || edad > 100))
                {

                    Console.WriteLine("Ingresa un valor numerico");
                }

                cont = 1;

                do
                {
                    Console.Write($"Ingresa otro {cont}: ");
                    otro = Console.ReadLine();

                    otros.Add(otro);

                    Console.Write("Desea ingresar mas valores(CONTINUAR = 1 --- SALIR = 0)? ");
                    while (!int.TryParse(Console.ReadLine(), out opc2))
                    {

                        Console.WriteLine("Ingresa un valor numerico");
                    }

                    cont++;

                } while (opc2 != 0);

                /*
             La informacion se ingresa a una lista de rostros por medio del 
                constructor de la clase rostro
             */

                rostros.Add(new Rostro(
                    patronTextura,
                    forma,
                    new ColorRostro(
                        tipoPiel,
                        porcentajePiel
                        ),
                    aspectoFaciales,
                    edad,
                    otros
                    ));

                cont2++;
                Console.Clear();

            } while (cont2 <= 2);

            /*
             Al finalizar la carga de informacion de los rostros,
            se ingresan los rostros al constructor de la clase de 
            reconocimiento facial.
             */

            recoFacial = new ReconocimientoFacial(
                rostros[0],
                rostros[1]
                );

            Console.WriteLine("Rostros cargados exitosamente!! Presione cualquier tecla...");
        }

        public void facial1()
        {
            /*
             El metodo facial1, aplica la funcionalidad del algoritmoUno
            que identifica 2 caracteristicas del rostro y muestra los resultados
             */
            string coincidencias = recoFacial.AlgoritmoUno();
            Console.WriteLine(recoFacial.ResultadoDeIdentificacion() + coincidencias);
        }

        public void facial2()
        {
            /*
             El metodo facial2, aplica la funcionalidad del AlgoritmoDos
            que identifica todas caracteristicas del rostro y muestra los resultados
             */
            string coincidencias = recoFacial.AlgoritmoDos();
            Console.WriteLine(recoFacial.ResultadoDeIdentificacion() + coincidencias);
        }
    }
}
