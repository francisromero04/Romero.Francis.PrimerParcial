using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using System.Xml.Serialization;

namespace BibliotecaAerolineasCompleto
{
    public class Aerolinea
    {
        public List<Vuelo> listaVuelos { get; set; }
        public List<Avion> listaAviones { get; set; }
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

           // CrearYGuardarAvionesJson();
           // CrearYGuardarVuelosXML();

            DeserializarAvionesJson();
            DeserializarVuelosXML();
            DeserializarPasajerosXML();
            AgregarElementosDiccionario();  

            foreach (Vuelo vuelo in listaVuelos)
            {
               // this.listaPasajeros.AddRange(vuelo.Pasajeros);
                EstablecerEstadoAvion(vuelo);                
                GuardarGanancias(vuelo);
            }
          //  SumarCantidadVuelos();         
          //  EstablecerHorasAvion(listaVuelos);      
        }

        #region METODOS DICCIONARIOS

        private void AgregarElementosDiccionario()
        {
            gananciaInternacional = new Dictionary<DestinosInternacionales, decimal>();
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
        }

        private void GuardarGanancias(Vuelo vuelo)
        {
            if (vuelo.VueloNacional == false)
            {
                if (gananciaInternacional.ContainsKey(vuelo.CiudadDestinoInternacional))
                {
                    decimal ganancia = gananciaInternacional[vuelo.CiudadDestinoInternacional];

                    foreach (Pasajero p in vuelo.Pasajeros)
                    {
                        if (p.TipoPasajero)
                        {
                            ganancia += vuelo.CostoTurista;
                        }
                        else
                        {
                            ganancia += vuelo.CostoPremium;
                        }

                    }
                    gananciaInternacional[vuelo.CiudadDestinoInternacional] = ganancia;
                    dineroTotalInternacional = ganancia;
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
                        if (p.TipoPasajero)
                        {
                            ganancia += vuelo.CostoTurista;
                        }
                        else
                        {
                            ganancia += vuelo.CostoPremium;
                        }

                    }
                    gananciaNacional[vuelo.CiudadDestinoNacional] = ganancia;
                    dineroTotalNacional = ganancia;
                }
                else
                {
                    gananciaNacional.Add(vuelo.CiudadDestinoNacional, vuelo.CostoTurista);
                }
            }
        }

        #endregion

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

        private void EstablecerEstadoAvion(Vuelo vuelo)
        {
            DateTime fechaActual = DateTime.Today;

            if (vuelo.FechaVuelo >= fechaActual)
            {
                foreach (Avion avion in listaAviones)
                {
                    if (vuelo.Avion.Equals(avion))
                    {
                        avion.OcupadoEnVuelo = true;
                    }
                }
            }
        }

        private void DeserializarAvionesJson()
        {
            string json = File.ReadAllText("avionesDeAerolinea.json");
            listaAviones = JsonConvert.DeserializeObject<List<Avion>>(json);
        }

        private void EstablecerHorasAvion(List<Vuelo> listaVuelos)
        {
            for (int i = 0; i < listaVuelos.Count; i++)
            {
                Vuelo vuelo = listaVuelos[i];
                DateTime fechaActual = DateTime.Today;
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
       
        public void CrearYGuardarAvionesJson() //ELIMINAR AL FINALIZAR EL PROGRAMA
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
                if (vuelo.VueloNacional)
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

        public void CrearYGuardarVuelosXML() //ELIMINAR AL FINALIZAR EL PROGRAMA
        {
            for (int i = 0; i < 80; i++)
            {
                System.Threading.Thread.Sleep(500);
                Vuelo vuelo = new Vuelo().GenerarVueloAleatorio(this);
                agregarVuelo(vuelo);
            }

            //  string json = JsonConvert.SerializeObject(listaVuelos);
            //  File.WriteAllText("vuelosDeAerolineaDos.json", json);

            // Crear una instancia del XmlSerializer y especificar el tipo de datos que se va a serializar
            XmlSerializer serializer = new XmlSerializer(typeof(List<Vuelo>));

            // Crear un objeto FileStream para escribir el archivo XML
            using (FileStream fileStream = new FileStream("vuelosDeAerolinea.xml", FileMode.Create))
            {
                // Serializar la lista de vuelos y escribir el resultado en el archivo
                serializer.Serialize(fileStream, listaVuelos);
            }
        }
        
        private void SumarCantidadVuelos()
        {
            foreach (Pasajero p in listaPasajeros)
            {
                p.CantidadVuelosHistoricos = 1;
            }
        }

        private void DeserializarVuelosXML()
        {
            SerializarVuelos vuelosDeserializados;

            XmlSerializer serializerV = new XmlSerializer(typeof(SerializarVuelos));

            using (FileStream fileStreamV = new FileStream("vuelosDeAerolinea.xml", FileMode.Open))
            {
                vuelosDeserializados = (SerializarVuelos)serializerV.Deserialize(fileStreamV);
            }

            listaVuelos = vuelosDeserializados.Vuelos; 

         /*   // Crear una instancia del XmlSerializer y especificar el tipo de datos que se va a deserializar
            XmlSerializer serializer = new XmlSerializer(typeof(List<Vuelo>));

            // Crear un objeto FileStream para leer el archivo XML
            using (FileStream fileStream = new FileStream("vuelosDeAerolinea.xml", FileMode.Open))
            {
                // Deserializar el archivo XML y obtener la lista de vuelos
                listaVuelos = (List<Vuelo>)serializer.Deserialize(fileStream);
            } */
        }

        private void DeserializarPasajerosXML()
        {
            SerializarPersonas pasajerosDeserializados;

            XmlSerializer serializer = new XmlSerializer(typeof(SerializarPersonas));

            using (FileStream fileStream = new FileStream("pasajeros.xml", FileMode.Open))
            {
                pasajerosDeserializados = (SerializarPersonas)serializer.Deserialize(fileStream);
            }

            listaPasajeros = pasajerosDeserializados.Pasajeros;

            /*
            // Crear una instancia del XmlSerializer y especificar el tipo de datos que se va a deserializar
            XmlSerializer serializerP = new XmlSerializer(typeof(List<Pasajero>));

            // Crear un objeto FileStream para leer el archivo XML
            using (FileStream fileStreamP = new FileStream("pasajeros.xml", FileMode.Open))
            {
                // Deserializar el archivo XML y obtener la lista de vuelos
                listaPasajeros = (List<Pasajero>)serializerP.Deserialize(fileStreamP);
            }*/
        }

        #endregion
    }
}