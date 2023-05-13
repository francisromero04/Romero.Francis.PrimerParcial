using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaAerolineasCompleto
{
    public class Aerolinea
    {
        public List<Vuelo> listaVuelos { get; set;}

        public List<Avion> listaAviones { get; set;}

        public List<Pasajero> listaPasajeros { get; set; }

        public decimal dineroTotal { get; set; }

        public string destinoMasSeleccionado { get; set; }

        public Aerolinea()
        {
            listaAviones = new List<Avion>();
            listaVuelos = new List<Vuelo>();
            listaPasajeros = new List<Pasajero>();
            dineroTotal = 1000000;

            //AVIONES
            for (int i = 0; i < 100; i++) 
            {
                System.Threading.Thread.Sleep(5);
                Avion avion = new Avion().DevolverAvion();
                if (VerificarMatriculaExistente(avion.Matricula) == false)
                {
                    agregarAvion(avion);
                }
            }

            //PASAJEROS
            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(5);
                Random random = new Random(DateTime.Now.Millisecond); //lee los milisegundos de la pc y en base a eso genera el random
                Pasajero pasajero = new Pasajero().GenerarPasajeroAleatorio(random);

                if (VerificarDniExistente(pasajero.dni) == false)
                {
                    agregarPasajero(pasajero);
                }                
            }

            //VUELOS
            for(int i = 0;i < 25; i++)
            {
                System.Threading.Thread.Sleep(5);
                Vuelo vuelo = new Vuelo(this).CrearVueloAleatorio(this);
                if (vuelo != null)
                {
                    agregarVuelo(vuelo);
                }
            }

        }

        public void agregarAvion(Avion avion)
        {
           listaAviones.Add(avion);
        }

        public void eliminarAvion(Avion avion)
        {
            listaAviones.Remove(avion);
        }

        public void agregarPasajero(Pasajero pasajero)
        {
            if (VerificarDniExistente(pasajero.dni) == false)
            {
                listaPasajeros.Add(pasajero);
            }
        }

        public void ReemplazarPasajeroSeleccionado(Pasajero pasajeroSeleccionado)
        {
            for (int i = 0; i < listaPasajeros.Count; i++)
            {
                if (listaPasajeros[i].dni == pasajeroSeleccionado.dni)
                {
                    listaPasajeros[i] = pasajeroSeleccionado;
                    break;
                }
            }
        }

        public void eliminarPasajero(Pasajero pasajero)
        {
            listaPasajeros.Remove(pasajero);
        }

        public bool VerificarDniExistente(int dni)
        {
            // Verificar si el DNI ya existe en la lista de pasajeros
            foreach (Pasajero pasajero in listaPasajeros)
            {
                if (pasajero.dni == dni)
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificarMatriculaExistente(string matricula)
        {
            // Verificar si el DNI ya existe en la lista de pasajeros
            foreach (Avion avion in listaAviones)
            {
                if (avion.Matricula == matricula)
                {
                    return true;
                }
            }
            return false;
        }

        public void agregarVuelo(Vuelo vuelo)
        {
            listaVuelos.Add(vuelo);
        }

        public string DestinoMasSeleccionado()
        {
            Dictionary<string, int> destinosContador = new Dictionary<string, int>();

            foreach (Vuelo vuelo in listaVuelos)
            {
                string destino = "";
                if (vuelo.vueloNacional)
                {
                    destino = vuelo.CiudadDestinoNacional.ToString();
                }
                else
                {
                    destino = vuelo.CiudadDestinoInternacional.ToString();
                }

                if (destinosContador.ContainsKey(destino))
                {
                    destinosContador[destino]++;
                }
                else
                {
                    destinosContador.Add(destino, 1);
                }
            }

            int maxContador = 0;
            string destinoMasSeleccionado = "";
            foreach (KeyValuePair<string, int> destinoContador in destinosContador)
            {
                if (destinoContador.Value > maxContador)
                {
                    maxContador = destinoContador.Value;
                    destinoMasSeleccionado = destinoContador.Key;
                }
            }

            return destinoMasSeleccionado;
        }
    }
}
