using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DPRN2_U1_EA_JUPM.Modelos

/*
        Clase rostro que contiene todos los atributos del rostro a identificar,
        en este se implementan 2 constructores, uno sin informacion requerida y el segundo
        requiere todos los atributos para asignar valores, el acceso se realiza por medio de
        getters y setters, y se sobreescribe el metodo ToString para mostrar la informacion 
        parecidad a una estructura JSON. Y contiene el metodo de simulacion de 
envejicimiento sobrecargado 3 veces.
         */
{
    class Rostro
    {
        private String PatronTextura;
        private String Forma;
        private ColorRostro ColorPiel;
        private List<string> RasgosFaciales;
        private Int32 Edad;
        private List<string> Otros;

        public Rostro(){
        }

        public Rostro(
            string patronTextura,
            string forma,
            ColorRostro colorPiel,
            List<string> rasgosFaciales,
            int edad,
            List<string> otros
            ){

            this.PatronTextura = patronTextura;
            this.Forma = forma;
            this.ColorPiel = colorPiel;
            this.RasgosFaciales = rasgosFaciales;
            this.Edad = edad;
            this.Otros = otros;
        }

        public string PatronTextura1 {

            get => PatronTextura;
            set => PatronTextura = value; 
        }
        public string Forma1 {
            
            get => Forma;
            set => Forma = value; 
        }
        public ColorRostro ColorPiel1 {

            get => ColorPiel;
            set => ColorPiel = value; 
        }
        public List<string> RasgosFaciales1 { 
            
            get => RasgosFaciales;
            set => RasgosFaciales = value; 
        }
        public int Edad1 { 
            
            get => Edad; 
            set => Edad = value; 
        }
        public List<string> Otros1 { 
            
            get => Otros; 
            set => Otros = value; 
        }

        public void SimularEnvejecimiento(ColorRostro CambiarIntensidadColorPiel)
        {

            this.ColorPiel = CambiarIntensidadColorPiel;

        }

        public void SimularEnvejecimiento(int CambiarEdad)
        {

            this.Edad = CambiarEdad;
        }

        public void SimularEnvejecimiento(String AgregarRasgosFaciales)
        {

            this.RasgosFaciales.Add(AgregarRasgosFaciales);
        }

        public override string ToString()
        {

            return string.Format(
                "\n\tPatronTextura: " + $"{PatronTextura}" +
                "\n\tForma: " + $"{Forma}" +
                "\n\tColorPiel: " + $"{ColorPiel}" +
                "\n\tRasgosFaciales: " + $"[{string.Join(", ", RasgosFaciales)}]" +
                "\n\tEdad: " + $"{Edad}" +
                "\n\tOtros: " + $"[{string.Join(",", Otros)}]");
        }
    }
}
