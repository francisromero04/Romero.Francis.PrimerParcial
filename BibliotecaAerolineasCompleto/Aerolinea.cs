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
        public decimal dineroTotalNacional { get; set; }
        public decimal dineroTotalInternacional { get; set; }

        public Dictionary<DestinosInternacionales, decimal> gananciaInternacional;
        public Dictionary<DestinosNacionales, decimal> gananciaNacional;

        public Aerolinea()
        {
            listaAviones = new List<Avion>();
            listaVuelos = new List<Vuelo>();
            listaPasajeros = new List<Pasajero>();

            dineroTotalNacional = 1000000; //DINERO INICIAL DE LA AEROLINEA
            dineroTotalInternacional = 1000000;
            DateTime fechaActual = DateTime.Today;

            gananciaInternacional = new Dictionary<DestinosInternacionales, decimal>();
            // Agregar elementos al diccionario
            gananciaInternacional.Add(DestinosInternacionales.RecifeBrasil, 0);
            gananciaInternacional.Add(DestinosInternacionales.RomaItalia, 0);
            gananciaInternacional.Add(DestinosInternacionales.AcapulcoMexico, 0);
            gananciaInternacional.Add(DestinosInternacionales.MiamiEEUU, 0);

            gananciaNacional = new Dictionary<DestinosNacionales, decimal>();
            gananciaNacional.Add(DestinosNacionales.BuenosAires, 0);
            gananciaNacional.Add(DestinosNacionales.Bariloche, 0);
            gananciaNacional.Add(DestinosNacionales.Cordoba, 0);
            gananciaNacional.Add(DestinosNacionales.Corrientes, 0);
            gananciaNacional.Add(DestinosNacionales.Jujuy, 0);
            gananciaNacional.Add(DestinosNacionales.Iguazu, 0);
            gananciaNacional.Add(DestinosNacionales.Salta, 0);
            gananciaNacional.Add(DestinosNacionales.SantaRosa, 0);
            gananciaNacional.Add(DestinosNacionales.Posadas, 0);
            gananciaNacional.Add(DestinosNacionales.Neuquen, 0);
            gananciaNacional.Add(DestinosNacionales.Mendoza, 0);
            gananciaNacional.Add(DestinosNacionales.PuertoMadryn, 0);
            gananciaNacional.Add(DestinosNacionales.SantiagoDelEstero, 0);
            gananciaNacional.Add(DestinosNacionales.Trelew, 0);
            gananciaNacional.Add(DestinosNacionales.Tucuman, 0);
            gananciaNacional.Add(DestinosNacionales.Ushuaia, 0);

            string json = File.ReadAllText("avionesDeAerolinea.json");
            listaAviones = JsonConvert.DeserializeObject<List<Avion>>(json);
           
            string jsonDos = File.ReadAllText("vuelosDeAerolinea.json");
            listaVuelos = JsonConvert.DeserializeObject<List<Vuelo>>(jsonDos);

            foreach(Vuelo vuelo in listaVuelos)
            {
                this.listaPasajeros.AddRange(vuelo.Pasajeros);

                if(vuelo.FechaVuelo >= fechaActual)
                {
                    foreach(Avion avion in listaAviones)
                    {
                        if(vuelo.Avion.Equals(avion))
                        {
                            avion.OcupadoEnVuelo = true;
                        }
                    }                   
                }

                if(vuelo.vueloNacional == false)
                {                    
                    if (gananciaInternacional.ContainsKey(vuelo.CiudadDestinoInternacional))
                    {
                        decimal ganancia = gananciaInternacional[vuelo.CiudadDestinoInternacional];
                        
                        foreach(Pasajero p in vuelo.Pasajeros)
                        {
                            if(p.tipoPasajero)
                            {
                                ganancia += vuelo.CostoTurista; 
                            }
                            else
                            {
                                ganancia += vuelo.CostoPremium;
                            }

                        }
                        gananciaInternacional[vuelo.CiudadDestinoInternacional] = ganancia; 
                    }
                    else
                    {
                        gananciaInternacional.Add(vuelo.CiudadDestinoInternacional, vuelo.CostoTurista);
                    }
                }
                else
                {
                    if (gananciaNacional.ContainsKey(vuelo.CiudadDestinoNacional))
                    {
                        decimal ganancia = gananciaNacional[vuelo.CiudadDestinoNacional];

                        foreach (Pasajero p in vuelo.Pasajeros)
                        {
                            if (p.tipoPasajero)
                            {
                                ganancia += vuelo.CostoTurista;
                            }
                            else
                            {
                                ganancia += vuelo.CostoPremium;
                            }

                        }
                        gananciaNacional[vuelo.CiudadDestinoNacional] = ganancia;
                    }
                    else
                    {
                        gananciaNacional.Add(vuelo.CiudadDestinoNacional, vuelo.CostoTurista);
                    }
                }
            }

            foreach(Pasajero p in listaPasajeros)
            {
                p.cantidadVuelosHistoricos++;
            }

            for (int i = 0; i < listaVuelos.Count; i++)
            {
                Vuelo vuelo = listaVuelos[i];
                if (vuelo.FechaVuelo <= fechaActual)
                {
                    Avion avion = listaAviones.Find(a => vuelo.Avion.Equals(a));
                    if (avion != null)
                    {
                        avion.HorasVueloHistoricas += vuelo.DuracionVuelo;
                        listaAviones[listaAviones.IndexOf(avion)] = avion;
                    }
                }
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
            if (VerificarDniExistente(pasajero.Dni) == false)
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
                if (pasajero.Dni == dni)
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
                string destino;
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

        public void CrearYGuardarVuelosJson()
        {
            for(int i = 0; i < 80; i++)
            {
                System.Threading.Thread.Sleep(500);
                Vuelo vuelo = new Vuelo(this).GenerarVueloAleatorio(this);
                agregarVuelo(vuelo);         
            }

            string json = JsonConvert.SerializeObject(listaVuelos);
            File.WriteAllText("vuelosDeAerolinea.json", json);
        }

        public void CrearYGuardarAvionesJson()
        {
            for (int i = 0; i < 20; i++)
            {
                System.Threading.Thread.Sleep(5);
                Avion avion = new Avion().GenerarAvionAleatorio();
                agregarAvion(avion);

            }

            string json = JsonConvert.SerializeObject(listaAviones);
            File.WriteAllText("avionesDeAerolinea.json", json);
        }

        #endregion
    }
}
