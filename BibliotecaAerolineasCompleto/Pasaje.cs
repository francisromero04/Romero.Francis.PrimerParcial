using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAerolineasCompleto
{
    public class Pasaje
    {
        public Pasajero Pasajero { get; set; }
        public Vuelo Vuelo { get; set; }
        public bool TipoAsiento { get; set; } // false = premium
        public decimal Costo { get; set; }

        public Pasaje(Pasajero pasajero, Vuelo vuelo, bool tipoAsiento, decimal costo)
        {
            Pasajero = pasajero;
            Vuelo = vuelo;
            TipoAsiento = tipoAsiento;
            Costo = costo;
        }
    }
}
