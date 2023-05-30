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
    /// <summary>
    /// Representa una aerolínea.
    /// </summary>
    public class Aerolinea
    {
        private List<Vuelo> listaVuelos;
        private decimal dineroTotalNacional;
        private decimal dineroTotalInternacional;
        private List<Avion> listaAviones;
        private List<Pasajero> listaPasajeros;              
        public Dictionary<DestinosInternacionales, decimal> gananciaInternacional;
        public Dictionary<DestinosNacionales, decimal> gananciaNacional;

        /// <summary>
        /// Crea una nueva instancia de la clase Aerolinea.
        /// </summary>
        public Aerolinea()
        {
            ListaAviones = new List<Avion>();
            ListaVuelos = new List<Vuelo>();
            ListaPasajeros = new List<Pasajero>();

            DeserializarAvionesJson();
            DeserializarVuelosXML();
            DeserializarPasajerosXML();
            ProcesarListaVuelos();
        }

        #region GETTERS Y SETTERS

        /// <summary>
        /// Obtiene o establece la lista de vuelos.
        /// </summary>
        /// <value>La lista de vuelos.</value>
        public List<Vuelo> ListaVuelos 
        { 
            get { return listaVuelos; }
            set {listaVuelos = value; } 
        }

        /// <summary>
        /// Obtiene o establece la lista de aviones.
        /// </summary>
        /// <value>La lista de aviones.</value>
        public List<Avion> ListaAviones 
        {
            get { return listaAviones; }
            set { listaAviones = value; } 
        }

        /// <summary>
        /// Obtiene o establece la lista de pasajeros.
        /// </summary>
        /// <value>La lista de pasajeros.</value>
        public List<Pasajero> ListaPasajeros 
        {
            get { return listaPasajeros; }
            set {listaPasajeros = value; }
        }

        /// <summary>
        /// Obtiene o establece el dinero total para vuelos nacionales.
        /// </summary>
        /// <value>El dinero total para vuelos nacionales.</value>
        public decimal DineroTotalNacional 
        {
            get { return dineroTotalNacional; }
            set {dineroTotalNacional = value; }
        }

        /// <summary>
        /// Obtiene o establece el dinero total para vuelos internacionales.
        /// </summary>
        /// <value>El dinero total para vuelos internacionales.</value>
        public decimal DineroTotalInternacional
        {
            get { return dineroTotalInternacional; }
            set { dineroTotalInternacional = value; }
        }

        #endregion

        #region METODOS DICCIONARIOS

        /// <summary>
        /// Procesa la lista de vuelos, realizando las operaciones necesarias para cada vuelo, 
        /// como agregar elementos al diccionario de ganancias, establecer el estado del avión y guardar las ganancias del vuelo.
        /// </summary>
        private void ProcesarListaVuelos()
        {
            AgregarElementosDiccionario();

            foreach (Vuelo vuelo in ListaVuelos)
            {
                EstablecerEstadoAvion(vuelo);
                GuardarGanancias(vuelo);
            }
        }

        /// <summary>
        /// Agrega los elementos iniciales al diccionario de ganancias internacionales y nacionales, estableciendo su valor inicial en 0.
        /// </summary>
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

        /// <summary>
        /// Guarda las ganancias de un vuelo en el diccionario correspondiente según si es un vuelo nacional o internacional.
        /// </summary>
        /// <param name="vuelo">El objeto Vuelo que contiene la información del vuelo.</param>
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
                    DineroTotalInternacional = ganancia;
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
                    DineroTotalNacional = ganancia;
                }
                else
                {
                    gananciaNacional.Add(vuelo.CiudadDestinoNacional, vuelo.CostoTurista);
                }
            }
        }

        #endregion

        #region METODOS DE AVION

        /// <summary>
        /// Agrega un nuevo avión a la lista de aviones.
        /// </summary>
        /// <param name="avion">El objeto Avion a agregar.</param>
        public void agregarAvion(Avion avion)
        {
            ListaAviones.Add(avion);
        }

        /// <summary>
        /// Elimina un avión de la lista de aviones.
        /// </summary>
        /// <param name="avion">El objeto Avion a eliminar.</param>
        public void eliminarAvion(Avion avion)
        {
            ListaAviones.Remove(avion);
        }

        /// <summary>
        /// Verifica si una matrícula de avión ya existe en la lista de aviones.
        /// </summary>
        /// <param name="matricula">La matrícula del avión a verificar.</param>
        /// <returns><c>true</c> si la matrícula existe en la lista de aviones; <c>false</c> en caso contrario.</returns>
        public bool VerificarMatriculaExistente(string matricula)
        {
            foreach (Avion avion in ListaAviones)
            {
                if (avion.Matricula == matricula)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Establece el estado de ocupación de un avión basado en un vuelo. Si la fecha del vuelo es igual o posterior a la fecha actual, el avión se marca como ocupado.
        /// </summary>
        /// <param name="vuelo">El objeto Vuelo que contiene la información del vuelo.</param>
        private void EstablecerEstadoAvion(Vuelo vuelo)
        {
            DateTime fechaActual = DateTime.Today;

            if (vuelo.FechaVuelo >= fechaActual)
            {
                foreach (Avion avion in ListaAviones)
                {
                    if (vuelo.Avion.Equals(avion))
                    {
                        avion.OcupadoEnVuelo = true;
                    }
                }
            }
        }

        /// <summary>
        /// Deserializa los aviones en formato JSON desde un archivo y actualiza la lista de aviones.
        /// </summary>
        private void DeserializarAvionesJson()
        {
            string json = File.ReadAllText("avionesDeAerolinea.json");
            ListaAviones = JsonConvert.DeserializeObject<List<Avion>>(json);
        }
       
        #endregion

        #region METODOS DE PASAJERO

        /// <summary>
        /// Agrega un nuevo pasajero a la lista de pasajeros, siempre y cuando el DNI del pasajero no exista previamente.
        /// </summary>
        /// <param name="pasajero">El objeto Pasajero a agregar.</param>
        public void agregarPasajero(Pasajero pasajero)
        {
            if (VerificarDniExistente(pasajero.Dni) == false)
            {
                ListaPasajeros.Add(pasajero);
            }
        }

        /// <summary>
        /// Elimina un pasajero de la lista de pasajeros.
        /// </summary>
        /// <param name="pasajero">El objeto Pasajero a eliminar.</param>
        public void eliminarPasajero(Pasajero pasajero)
        {
            ListaPasajeros.Remove(pasajero);
        }

        /// <summary>
        /// Reemplaza el pasajero seleccionado en la lista de pasajeros con un nuevo pasajero.
        /// </summary>
        /// <param name="pasajeroSeleccionado">El objeto Pasajero seleccionado que será reemplazado.</param>
        public void ReemplazarPasajeroSeleccionado(Pasajero pasajeroSeleccionado)
        {
            for (int i = 0; i < ListaPasajeros.Count; i++)
            {
                if (ListaPasajeros[i].Equals(pasajeroSeleccionado))
                {
                    ListaPasajeros[i] = pasajeroSeleccionado;
                    break;
                }
            }
        }

        /// <summary>
        /// Verifica si un número de DNI ya existe en la lista de pasajeros.
        /// </summary>
        /// <param name="dni">El número de DNI a verificar.</param>
        /// <returns><c>true</c> si el DNI existe en la lista de pasajeros; <c>false</c> en caso contrario.</returns>
        public bool VerificarDniExistente(int dni)
        {
            // Verificar si el DNI ya existe en la lista de pasajeros
            foreach (Pasajero pasajero in ListaPasajeros)
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

        /// <summary>
        /// Agrega un vuelo a la lista de vuelos.
        /// </summary>
        /// <param name="vuelo">El vuelo a agregar.</param>
        public void agregarVuelo(Vuelo vuelo)
        {
            ListaVuelos.Add(vuelo);
        }

        /// <summary>
        /// Elimina un vuelo de la lista de vuelos.
        /// </summary>
        /// <param name="vuelo">El vuelo a eliminar.</param>
        public void eliminarVuelo(Vuelo vuelo)
        {
            ListaVuelos.Remove(vuelo);
        }

        // <summary>
        /// Obtiene el destino más seleccionado en la lista de vuelos.
        /// </summary>
        /// <returns>El destino más seleccionado.</returns>
        public string DestinoMasSeleccionado()
        {
            Dictionary<string, int> destinosContador = new Dictionary<string, int>();

            foreach (Vuelo vuelo in ListaVuelos)
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

        /// <summary>
        /// Deserializa los vuelos desde un archivo XML y asigna la lista de vuelos deserializados a la propiedad ListaVuelos.
        /// </summary>
        private void DeserializarVuelosXML()
        {
            SerializarVuelos vuelosDeserializados;

            XmlSerializer serializerV = new XmlSerializer(typeof(SerializarVuelos));

            using (FileStream fileStreamV = new FileStream("vuelosDeAerolinea.xml", FileMode.Open))
            {
                vuelosDeserializados = (SerializarVuelos)serializerV.Deserialize(fileStreamV);
            }

            ListaVuelos = vuelosDeserializados.Vuelos; 
        }

        /// <summary>
        /// Deserializa los pasajeros desde un archivo XML y asigna la lista de pasajeros deserializados a la propiedad ListaPasajeros.
        /// </summary>
        private void DeserializarPasajerosXML()
        {
            SerializarPersonas pasajerosDeserializados;

            XmlSerializer serializer = new XmlSerializer(typeof(SerializarPersonas));

            using (FileStream fileStream = new FileStream("pasajeros.xml", FileMode.Open))
            {
                pasajerosDeserializados = (SerializarPersonas)serializer.Deserialize(fileStream);
            }

            ListaPasajeros = pasajerosDeserializados.Pasajeros;
        }

        #endregion
    }
}