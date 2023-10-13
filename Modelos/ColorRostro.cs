namespace DPRN2_U1_EA_JUPM.Modelos
{
    /*
        Clase ReconocimientoFacial que sirve para separar y dar mayor detalle 
    a la clase rostro.
         */
    public class ColorRostro
    {

        private string tipo;
        private Int32 porcentaje;

        public ColorRostro()
        {
        }

        public ColorRostro(string tipo, int porcentaje)
        {
            this.tipo = tipo;
            this.porcentaje = porcentaje;
        }

        public string Tipo { 

            get => tipo; 
            set => tipo = value; 
        }
        public int Porcentaje {
            
            get => porcentaje; 
            set => porcentaje = value; 
        }

        public override string ToString()
        {
            return string.Format(

                "\n\t\tTipo: " + $"{tipo}" +
                "\n\t\tPorcentaje: " + $"{porcentaje}"
                );
        }
    }
}