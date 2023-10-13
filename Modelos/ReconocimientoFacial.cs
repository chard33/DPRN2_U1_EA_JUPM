using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DPRN2_U1_EA_JUPM.Modelos
{

    /*
        Clase ReconocimientoFacial que contiene todos los atributos de identificacion,
        en este se implementan 3 constructores, uno sin informacion requerida, el segundo
        requiere todos los atributos y el tercero requiere unicamente los 2 rostros
        para asignar valores, el acceso se realiza por medio de
        getters y setters, y se sobreescribe el metodo ToString para mostrar la informacion 
        parecidad a una estructura JSON. En esta clase contiene los 3 metodos requeridos
    para la identificacion de rostros que calculan, asigna y muestran resultados.
         */
    class ReconocimientoFacial
    {

        private Rostro rostro1;
        private Rostro rostro2;
        private Int32 PorcentajeCoincidencia;
        private Int32 ElementosIdenticos;
        private Boolean Identificacion;

        public ReconocimientoFacial()
        {
            
        }

        public ReconocimientoFacial(Rostro rostro1,
            Rostro rostro2, 
            int porcentajeCoincidencia, 
            int elementosIdenticos, 
            bool identificacion)
        {
            this.rostro1 = rostro1;
            this.rostro2 = rostro2;
            PorcentajeCoincidencia = porcentajeCoincidencia;
            ElementosIdenticos = elementosIdenticos;
            Identificacion = identificacion;
        }

        public ReconocimientoFacial(Rostro rostro1, Rostro rostro2)
        {
            this.rostro1 = rostro1;
            this.rostro2 = rostro2;
        }

        public int PorcentajeCoincidencia1 { 

            get => PorcentajeCoincidencia; 
            set => PorcentajeCoincidencia = value; 
        }
        public int ElementosIdenticos1 { 
            
            get => ElementosIdenticos; 
            set => ElementosIdenticos = value; 
        }
        public bool Identificacion1 { 
            
            get => Identificacion; 
            set => Identificacion = value;
        }
        internal Rostro Rostro1 { 
            
            get => rostro1; 
            set => rostro1 = value; 
        }
        internal Rostro Rostro2 { 
            
            get => rostro2; 
            set => rostro2 = value;
        }

        public string AlgoritmoUno(int valCoinci = 50)
        {

            var porcentaje = 0;

            string coincidencias = "";

            if (rostro1.RasgosFaciales1.All(rostro2.RasgosFaciales1.Contains) &
                rostro1.RasgosFaciales1.Count == rostro2.RasgosFaciales1.Count)
            {

                porcentaje += valCoinci;
                coincidencias += "RasgosFaciales, ";
            }

            if (rostro1.Edad1 == rostro2.Edad1)
            {

                porcentaje += valCoinci;
                coincidencias += "Edad, ";
            }

            PorcentajeCoincidencia1 = porcentaje;

            ElementosIdenticos1 = coincidencias.Split(',').ToList().Count();

            Identificacion = PorcentajeCoincidencia1 >= 85 ? true : false;

            return coincidencias;
        }

        public string AlgoritmoDos()
        {
            string coincidencias = AlgoritmoUno(20);

            int valPorcentaje = PorcentajeCoincidencia1;

            if (rostro1.PatronTextura1.Equals(rostro2.PatronTextura1))
            {
               
                valPorcentaje += 15;
                coincidencias += "PatronTextura, ";
            }
            
            if (rostro1.Forma1.Equals(rostro2.Forma1))
            {
                
                valPorcentaje += 15;
                coincidencias += "Forma, ";
            }
            
            if (rostro1.ColorPiel1.Tipo.Equals(rostro2.ColorPiel1.Tipo))
            {
                
                valPorcentaje += 10;
                coincidencias += "tipoPiel, ";
            }
            
            if (rostro1.ColorPiel1.Porcentaje == rostro2.ColorPiel1.Porcentaje)
            {
                
                valPorcentaje += 10;
                coincidencias += "porcentajePiel, ";
            }
            
            if (rostro1.Otros1.All(rostro2.Otros1.Contains) &
                rostro1.Otros1.Count == rostro2.Otros1.Count)
            {
                
                valPorcentaje += 10;
                coincidencias += "Otros, ";
            }
            
            PorcentajeCoincidencia1 = valPorcentaje;

            ElementosIdenticos1 = coincidencias.Split(',').ToList().Count();

            Identificacion = PorcentajeCoincidencia1 >= 85 ? true : false;

            return coincidencias;
        }

        public string ResultadoDeIdentificacion()
        {

            return ToString();
        }

        public override string ToString()
        {

            return string.Format(
                "Rostro1: " + $"{rostro1}" +
                "\nRostro2: " + $"{rostro2}" +
                "\nPorcentaje de coincidencia: " + $"{PorcentajeCoincidencia}" + "%" +
                "\nElementos identicos: " + $"{ElementosIdenticos}" +
                "\nIdentificacion: " + $"{(Identificacion == true ? "Identificado" : "No dentificado")}\n"
                );
        }
    }
}
