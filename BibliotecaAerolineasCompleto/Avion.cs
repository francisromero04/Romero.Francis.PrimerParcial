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
        public int CapacidadBodega { get; set; }

        public Avion()
        {

        }

        public Avion(string matricula, int cantidadAsientos, int cantidadBanos, bool servicioInternet, bool ofreceComida, int capacidadBodega)
        {
            Matricula = matricula;
            CantidadAsientos = cantidadAsientos;
            CantidadBanos = cantidadBanos;
            ServicioInternet = servicioInternet;
            OfreceComida = ofreceComida;
            CapacidadBodega = capacidadBodega;
        }

        public Avion DevolverAvion()
        {
            Random rnd = new Random();
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
            int capacidadBodega = rnd.Next(1000, 10000);

            Console.WriteLine(matricula);

            return new Avion(matricula, cantidadAsientos, cantidadBanos, servicioInternet, ofreceComida, capacidadBodega);
        }
    }
}
