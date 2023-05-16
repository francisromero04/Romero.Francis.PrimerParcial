using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace BibliotecaAerolineasCompleto
{
    public class Aerolinea
    {
        public List<Vuelo> listaVuelos { get; set;}
        public List<Avion> listaAviones { get; set;}
        public List<Pasajero> listaPasajeros { get; set; }
        public decimal dineroTotal { get; set; }

        public Aerolinea()
        {
            listaAviones = new List<Avion>();
            listaVuelos = new List<Vuelo>();
            listaPasajeros = new List<Pasajero>();
            dineroTotal = 1000000; //DINERO INICIAL DE LA AEROLINEA

            string json = File.ReadAllText("avionesDeAerolinea.json");
            listaAviones = JsonConvert.DeserializeObject<List<Avion>>(json);

            string jsonDos = File.ReadAllText("vuelosDeAerolinea.json");
            listaVuelos = JsonConvert.DeserializeObject<List<Vuelo>>(jsonDos);

            foreach(Vuelo vuelo in listaVuelos)
            {
                this.listaPasajeros.AddRange(vuelo.Pasajeros);
            }            
        }

        #region METODOS DE AVION

        public void agregarAvion(Avion avion)
        {
           listaAviones.Add(avion);
        }

        public void eliminarAvion(Avion avion)
        {
            listaAviones.Remove(avion);
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

        #endregion

        #region METODOS DE PASAJERO

        public void agregarPasajero(Pasajero pasajero)
        {
            if (VerificarDniExistente(pasajero.dni) == false)
            {
                listaPasajeros.Add(pasajero);
            }
        }

        public void eliminarPasajero(Pasajero pasajero)
        {
            listaPasajeros.Remove(pasajero);
        }

        public void ReemplazarPasajeroSeleccionado(Pasajero pasajeroSeleccionado)
        {
            for (int i = 0; i < listaPasajeros.Count; i++)
            {
                if (listaPasajeros[i].Equals(pasajeroSeleccionado))
                {
                    listaPasajeros[i] = pasajeroSeleccionado;
                    break;
                }
            }
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

        #endregion

        #region METODOS DE VUELO

        public void agregarVuelo(Vuelo vuelo)
        {
            listaVuelos.Add(vuelo);
        }

        public void eliminarVuelo(Vuelo vuelo)
        {
            listaVuelos.Remove(vuelo);
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

      /*  public void CrearYGuardarVuelosJson()
        {
            for(int i = 0; i < 80; i++)
            {
                System.Threading.Thread.Sleep(5);
                Vuelo vuelo = new Vuelo(this).GenerarVueloAleatorio(this);
                agregarVuelo(vuelo);         
            }

            string json = JsonConvert.SerializeObject(listaVuelos);
            File.WriteAllText("vuelosDeAerolinea.json", json);
        } */

        #endregion
    }
}
