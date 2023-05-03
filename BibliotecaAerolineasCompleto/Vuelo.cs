using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAerolineasCompleto
{
    public class Vuelo
    {
        public string CiudadPartida { get; set; }//modificar
        public DestinosNacionales CiudadDestinoNacional { get; set; }
        public DestinosInternacionales CiudadDestinoInternacional { get; set; }
        public DateTime FechaVuelo { get; set; }
        public Avion Avion { get; set; }
        public int AsientosPremiumDisponibles { get; set; }
        public int AsientosTuristaDisponibles { get; set; }
        public decimal CostoPremium { get; set; }
        public decimal CostoTurista { get; set; }
        public TimeSpan DuracionVuelo { get; set; }
        public List<Pasajero> Pasajeros { get; set; }
    }
}
