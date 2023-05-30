using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BibliotecaAerolineasCompleto
{
    /// <summary>
    /// Representa un vuelo de una aerolínea.
    /// </summary>
    [XmlRoot("Vuelo")]
    public class Vuelo
    {
        private string ciudadPartida;
        private DestinosInternacionales ciudadDestinoInteracional;
        private DestinosNacionales ciudadDestinoNacional;
        private DateTime fechaVuelo;
        private Avion avion;
        private int asientosPremiumDisponibles;
        private int asientosTuristaDisponibles;
        private int cantidadPasajeros;
        private decimal costoPremium, costoTurista;
        private int duracionVuelo;
        private List<Pasajero> pasajeros;
        private bool vueloNacional, vueloPasado;
        private decimal iva;

        /// <summary>
        /// Crea una nueva instancia de la clase Vuelo.
        /// </summary>
        public Vuelo()
        {
            Pasajeros = new List<Pasajero>();
            IVA = 1.21m;
        }

        #region GETTERS Y SETTERS

        /// <summary>
        /// Obtiene o establece la ciudad de partida del vuelo.
        /// </summary>
        [XmlElement("CiudadPartida")]
        public string CiudadPartida
        {
            get {return ciudadPartida; }
            set { ciudadPartida = value; }
        }

        /// <summary>
        /// Obtiene o establece la ciudad de destino nacional del vuelo.
        /// </summary>
        [XmlElement("CiudadDestinoNacional")]
        public DestinosNacionales CiudadDestinoNacional 
        {
            get { return ciudadDestinoNacional; }
            set { ciudadDestinoNacional = value; }
        }

        /// <summary>
        /// Obtiene o establece la ciudad de destino internacional del vuelo.
        /// </summary>
        [XmlElement("CiudadDestinoInternacional")]
        public DestinosInternacionales CiudadDestinoInternacional 
        {
            get { return ciudadDestinoInteracional; }
            set { ciudadDestinoInteracional = value; }
        }

        /// <summary>
        /// Obtiene o establece la fecha del vuelo.
        /// </summary>
        [XmlElement("FechaVuelo")]
        public DateTime FechaVuelo 
        {
            get { return fechaVuelo; }
            set { fechaVuelo = value; }
        }

        /// <summary>
        /// Obtiene o establece el avión asignado al vuelo.
        /// </summary>
        [XmlElement("Avion")]
        public Avion Avion 
        {
            get { return avion; }
            set { avion = value; }
        }

        /// <summary>
        /// Obtiene o establece la cantidad de asientos premium disponibles en el vuelo.
        /// </summary>
        [XmlElement("AsientosPremiumDisponibles")]
        public int AsientosPremiumDisponibles 
        {
            get { return asientosPremiumDisponibles; }
            set { asientosPremiumDisponibles = value; }
        }

        /// <summary>
        /// Obtiene o establece la cantidad de asientos turista disponibles en el vuelo.
        /// </summary>
        [XmlElement("AsientosTuristaDisponibles")]
        public int AsientosTuristaDisponibles 
        {
            get { return asientosTuristaDisponibles; }
            set { asientosTuristaDisponibles = value; }
        }

        /// <summary>
        /// Obtiene o establece la cantidad de pasajeros en el vuelo.
        /// </summary>
        [XmlElement("CantidadPasajeros")]
        public int CantidadPasajeros
        {
            get { return cantidadPasajeros; }
            set { cantidadPasajeros = value; }
        }

        /// <summary>
        /// Obtiene o establece el costo premium del vuelo.
        /// </summary>
        [XmlElement("CostoPremium")]
        public decimal CostoPremium
        {
            get { return costoPremium; }
            set { costoPremium = value; }
        }

        /// <summary>
        /// Obtiene o establece el costo turista del vuelo.
        /// </summary>
        [XmlElement("CostoTurista")]
        public decimal CostoTurista
        {
            get { return costoTurista; }
            set { costoTurista = value; }
        }

        /// <summary>
        /// Obtiene o establece la duración del vuelo en horas.
        /// </summary>
        [XmlElement("DuracionVuelo")]
        public int DuracionVuelo
        {
            get { return duracionVuelo; }
            set { duracionVuelo = value; }
        }

        /// <summary>
        /// Obtiene o establece la lista de pasajeros del vuelo.
        /// </summary>
        [XmlElement("Pasajeros")]
        public List<Pasajero> Pasajeros
        {
            get { return pasajeros; }
            set { pasajeros = value; }
        }

        /// <summary>
        /// Obtiene o establece si el vuelo es de tipo nacional.
        /// </summary>
        [XmlElement("VueloNacional")]
        public bool VueloNacional
        {
            get { return vueloNacional; }
            set { vueloNacional = value; }
        }

        /// <summary>
        /// Obtiene o establece el valor del impuesto al valor agregado (IVA) aplicado al vuelo.
        /// </summary>
        [XmlElement("IVA")]
        public decimal IVA
        {
            get { return iva; }
            set { iva = value; }
        }

        /// <summary>
        /// Obtiene o establece un valor que indica si el vuelo ya ha pasado.
        /// </summary>
        [XmlElement("VueloPasado")]
        public bool VueloPasado
        {
            get { return vueloPasado; }
            set { vueloPasado = value; }
        }

        #endregion

        /// <summary>
        /// Verifica si el pasajero dado ya está en la lista de pasajeros del vuelo actual.
        /// </summary>
        /// <param name="pasajero">El objeto Pasajero a verificar.</param>
        /// <returns>True si el pasajero está en la lista, False en caso contrario.</returns>
        public bool ContienePasajero(Pasajero pasajero)
        {
            foreach(Pasajero p in Pasajeros)
            {
                if(p.Equals(pasajero))
                {
                    MessageBox.Show("El pasajero ya fue incorporado a la lista de pasajeros perteneciente al vuelo seleccionado.");
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Vende un pasaje para el pasajero especificado y el tipo de pasajero indicado.
        /// </summary>
        /// <param name="pasajero">El objeto Pasajero para el cual se va a vender el pasaje.</param>
        /// <param name="tipoPasajero">Indica si el tipo de pasajero es premium (True) o turista (False).</param>
        /// <exception cref="ArgumentNullException">Se lanza si el objeto pasajero es nulo.</exception>
        public void VenderPasaje(Pasajero pasajero, bool tipoPasajero)
        {
            if (pasajero == null)
            {
                throw new ArgumentNullException("El objeto pasajero es nulo.");
            }

            if (tipoPasajero == false && AsientosPremiumDisponibles > 0 && Avion.CapacidadBodega > pasajero.PesoEquipaje)
            {
                CantidadPasajeros++;
                AsientosPremiumDisponibles--;
            }            
            else if (tipoPasajero == true && AsientosTuristaDisponibles > 0 && Avion.CapacidadBodega > pasajero.PesoEquipaje)
            {
                CantidadPasajeros++;                
                AsientosTuristaDisponibles--;
            }
            else
            {
                MessageBox.Show("No se puede vender el pasaje.");
            }
        }

        /// <summary>
        /// Obtiene la información completa del vuelo en formato de texto.
        /// </summary>
        private string ObtenerInformacionVuelo
        {
            get
            {
                string info = $"Origen: {CiudadPartida} | ";

                if (vueloNacional)
                {
                    info += $"Destino: {CiudadDestinoNacional} | ";
                  //  info += $"\nTipo de vuelo: Nacional, ";
                }
                else
                {
                    info += $"Destino: {CiudadDestinoInternacional} | ";
                  //  info += $"\nTipo de vuelo: Internacional, ";
                }

              /*  if (Avion != null)
                {
                    info += $"\nAvión: {Avion.Matricula}, ";
                }*/

                info += $"Fecha: {FechaVuelo.ToString("dd/MM/yyyy")} | ";
             //   info += $"\nCant. pasajeros: {CantidadPasajeros}, ";
             //   info += $"\nDuración: {DuracionVuelo.ToString()}, ";
                info += $"\nAsientos disponibles: Turistas: {AsientosTuristaDisponibles} | ";
                info += $"\nPremium: {AsientosPremiumDisponibles}";
             //   info += $"\nCosto premium: ${CostoPremium.ToString()}, ";
             //   info += $"\nCosto turista: ${CostoTurista.ToString()}";

                return info;
            }
        }

        /// <summary>
        /// Obtiene la información resumida del vuelo en formato de texto.
        /// </summary>
        public string ObtenerInformacionVueloResumida
        {
            get
            {
                string info = $"Origen: {CiudadPartida}  | ";

                if (vueloNacional)
                {
                    info += $"  Destino: {CiudadDestinoNacional}  | ";
                }
                else
                {
                    info += $"  Destino: {CiudadDestinoInternacional}  | ";
                }

                if (Avion != null)
                {
                    info += $"  Avión: {Avion.Matricula}  | ";
                }

                info += $"  Fecha: {FechaVuelo.ToString("dd/MM/yyyy")}";

                return info;
            }
        }

        /// <summary>
        /// Devuelve una cadena que representa el estado del vuelo.
        /// </summary>
        /// <returns>Una cadena que representa el estado actual del vuelo.</returns>
        public override string ToString()
        {
            return ObtenerInformacionVuelo;
        }

      }
}
