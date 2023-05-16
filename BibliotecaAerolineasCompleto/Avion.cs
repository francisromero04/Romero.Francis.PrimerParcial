using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAerolineasCompleto
{
    public class Avion
    {
        public string Matricula { get; set; }
        public int CantidadAsientos { get; set; }
        public int CantidadBanos { get; set; }
        public bool ServicioInternet { get; set; }
        public bool OfreceComida { get; set; }
        public decimal CapacidadBodega { get; set; }
        public bool OcupadoEnVuelo { get; set; }

        public Avion()
        {
            //CONSTRUCTOR VACIO
        }

        public Avion(string matricula, int cantidadAsientos, int cantidadBanos, bool servicioInternet, bool ofreceComida, decimal capacidadBodega)
        {
            Matricula = matricula;
            CantidadAsientos = cantidadAsientos;
            CantidadBanos = cantidadBanos;
            ServicioInternet = servicioInternet;
            OfreceComida = ofreceComida;
            CapacidadBodega = capacidadBodega;
        }

        public Avion GenerarAvionAleatorio()
        {
            Random rnd = new Random(DateTime.Now.Millisecond); //lee los milisegundos de la pc y en base a eso genera el random
            const string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string matricula = new string(
                Enumerable.Range(1, 8)
                    .Select(x => x <= 4 ? letras[rnd.Next(letras.Length)] : Char.Parse(rnd.Next(10).ToString()))
                    .ToArray()
            );
            int cantidadAsientos = rnd.Next(50, 300);
            int cantidadBanos = rnd.Next(1, 5);
            bool servicioInternet = rnd.Next(2) == 1;
            bool ofreceComida = rnd.Next(2) == 1;
            decimal capacidadBodega = rnd.Next(1000, 10000);
            OcupadoEnVuelo = false;
            return new Avion(matricula, cantidadAsientos, cantidadBanos, servicioInternet, ofreceComida, capacidadBodega);
        }

        public string ObtenerEstadoAvion
        {
            get
            {
                string ocupado = OcupadoEnVuelo ? "ocupado" : "disponible";
                return $"Avión con matrícula {Matricula}, estado: {ocupado}, asientos: {CantidadAsientos}";
            }
        }

        public override bool Equals(object obj)
        {
            // Si el objeto es null, entonces no son iguales
            if (obj == null)
                return false;

            // Si el objeto no es de tipo Avion, entonces no son iguales
            if (!(obj is Avion))
                return false;

            // Compara la matrícula para determinar si son iguales
            Avion avion = (Avion)obj;
            return Matricula.Equals(avion.Matricula);
        }

        public override int GetHashCode()
        {
            return Matricula.GetHashCode();
        }
    }
}
