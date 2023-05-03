using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAerolineasCompleto
{
    public class Aerolinea
    {
        public List<Vuelo> listaVuelos { get; set;}

        public List<Avion> listaAviones { get; set;}

        public List<Pasajero> listaPasajeros { get; set; }

        public Aerolinea()
        {
            listaAviones = new List<Avion>();
            listaVuelos = new List<Vuelo>();
            listaPasajeros = new List<Pasajero>();
        }

        public void agregarAvion(Avion avion)
        {
           listaAviones.Add(avion);
        }

        public void eliminarAvion(Avion objetoABajar)
        {
            listaAviones.Remove(objetoABajar);
        }

        public void agregarPasajero(Pasajero pasajero)
        {
            listaPasajeros.Add(pasajero);
        }

        public void eliminarPasajero(Pasajero pasajero)
        {
            listaPasajeros.Remove(pasajero);
        }
    }
}
