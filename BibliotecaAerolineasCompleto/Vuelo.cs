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

        public Vuelo()
        {
            Pasajeros = new List<Pasajero>();
            IVA = 1.21m;
        }

        #region GETTERS Y SETTERS

        [XmlElement("CiudadPartida")]
        public string CiudadPartida
        {
            get {return ciudadPartida; }
            set { ciudadPartida = value; }
        }

        [XmlElement("CiudadDestinoNacional")]
        public DestinosNacionales CiudadDestinoNacional 
        {
            get { return ciudadDestinoNacional; }
            set { ciudadDestinoNacional = value; }
        }

        [XmlElement("CiudadDestinoInternacional")]
        public DestinosInternacionales CiudadDestinoInternacional 
        {
            get { return ciudadDestinoInteracional; }
            set { ciudadDestinoInteracional = value; }
        }

        [XmlElement("FechaVuelo")]
        public DateTime FechaVuelo 
        {
            get { return fechaVuelo; }
            set { fechaVuelo = value; }
        }

        [XmlElement("Avion")]
        public Avion Avion 
        {
            get { return avion; }
            set { avion = value; }
        }

        [XmlElement("AsientosPremiumDisponibles")]
        public int AsientosPremiumDisponibles 
        {
            get { return asientosPremiumDisponibles; }
            set { asientosPremiumDisponibles = value; }
        }

        [XmlElement("AsientosTuristaDisponibles")]
        public int AsientosTuristaDisponibles 
        {
            get { return asientosTuristaDisponibles; }
            set { asientosTuristaDisponibles = value; }
        }

        [XmlElement("CantidadPasajeros")]
        public int CantidadPasajeros
        {
            get { return cantidadPasajeros; }
            set { cantidadPasajeros = value; }
        }

        [XmlElement("CostoPremium")]
        public decimal CostoPremium
        {
            get { return costoPremium; }
            set { costoPremium = value; }
        }

        [XmlElement("CostoTurista")]
        public decimal CostoTurista
        {
            get { return costoTurista; }
            set { costoTurista = value; }
        }

        [XmlElement("DuracionVuelo")]
        public int DuracionVuelo
        {
            get { return duracionVuelo; }
            set { duracionVuelo = value; }
        }

        [XmlElement("Pasajeros")]
        public List<Pasajero> Pasajeros
        {
            get { return pasajeros; }
            set { pasajeros = value; }
        }

        [XmlElement("VueloNacional")]
        public bool VueloNacional
        {
            get { return vueloNacional; }
            set { vueloNacional = value; }
        }

        [XmlElement("IVA")]
        public decimal IVA
        {
            get { return iva; }
            set { iva = value; }
        }

        [XmlElement("VueloPasado")]
        public bool VueloPasado
        {
            get { return vueloPasado; }
            set { vueloPasado = value; }
        }

        #endregion

        public Vuelo GenerarVueloAleatorio(Aerolinea aerolinea) //ELIMINAR
        {
            Random random = new Random();
            Avion avionSeleccionado = new Avion(); // Crear objeto Avion
            bool hayAvionesDisponibles = false; // Verificar si hay aviones disponibles
            DateTime fechaPartidaAleatoria;

            if (random.NextDouble() < 0.1)
            {
                DateTime hoy = DateTime.Today;
                fechaPartidaAleatoria = hoy.AddDays(random.Next(30));
                // Hacer algo con la fecha aleatoria...
                VueloPasado = false;
            }
            // Generar fecha aleatoria entre hoy y 3 años atrás (80% de las veces)
            else
            {
                DateTime hoy_anterior = DateTime.Today;
                fechaPartidaAleatoria = hoy_anterior.AddDays(-random.Next(1095));
                // Hacer algo con la fecha aleatoria...
                VueloPasado = true;
            }

            if(VueloPasado == false)
            {
                foreach (Avion avion in aerolinea.listaAviones)
                {
                    if (!avion.OcupadoEnVuelo)
                    {
                        hayAvionesDisponibles = true;
                        break;
                    }
                }

                if (!hayAvionesDisponibles)
                {
                    MessageBox.Show("No hay aviones disponibles para asignar al vuelo.");
                }
            }
            
            vueloNacional = random.NextDouble() < 0.75; // Seleccionar un 75% de probabilidad de vuelo nacional
            SeleccionarDestino(vueloNacional, random); //Seleccionamos el destino

            if(VueloPasado == false)
            {
                SeleccionarAvion(aerolinea, avionSeleccionado, random);
                avionSeleccionado = this.Avion;
                CalcularAsientosDisponibles(this);
                Random rnd = new Random(DateTime.Now.Millisecond);
                double porcentaje = rnd.Next(0, 41) / 100.0;
                int limite = (int)(avionSeleccionado.CantidadAsientos * porcentaje);
                FechaVuelo = fechaPartidaAleatoria;

                for (int i = 0; i < limite; i++)
                {
                    System.Threading.Thread.Sleep(1);
                    random = new Random(DateTime.Now.Millisecond); //lee los milisegundos de la pc y en base a eso genera el random
                    Pasajero pasajero = new Pasajero().GenerarPasajeroAleatorio(random);

                    if (VerificarDniExistente(pasajero.Dni) == false)
                    {
                        if(pasajero.TipoPasajero == false && AsientosPremiumDisponibles > 0)
                        {
                            Pasajeros.Add(pasajero);
                            CantidadPasajeros++;
                            AsientosPremiumDisponibles--;
                        }
                        else if (pasajero.TipoPasajero == true && AsientosTuristaDisponibles > 0)
                        {
                            Pasajeros.Add(pasajero);
                            CantidadPasajeros++;
                            AsientosTuristaDisponibles--;
                        }
                    }
                }
                CalcularDuracionVuelo(vueloNacional, avionSeleccionado, true);
                CalcularCostoVuelo(this, vueloNacional);
            }
            else
            {
                SeleccionarAvion(aerolinea, avionSeleccionado, random);
                avionSeleccionado = this.Avion;
                CalcularAsientosDisponibles(this);
                Random rnd = new Random(DateTime.Now.Millisecond);
                double porcentaje = rnd.Next(80, 101) / 100.0;
                int limite = (int)(avionSeleccionado.CantidadAsientos * porcentaje);
                FechaVuelo = fechaPartidaAleatoria;

                for (int i = 0; i < limite; i++)
                {
                    System.Threading.Thread.Sleep(1);
                    random = new Random(DateTime.Now.Millisecond); //lee los milisegundos de la pc y en base a eso genera el random
                    Pasajero pasajero = new Pasajero().GenerarPasajeroAleatorio(random);

                    if (VerificarDniExistente(pasajero.Dni) == false)
                    {
                        if (pasajero.TipoPasajero == false && AsientosPremiumDisponibles > 0)
                        {
                            Pasajeros.Add(pasajero);
                            AsientosPremiumDisponibles--;
                            CantidadPasajeros++;
                        }
                        else if (pasajero.TipoPasajero == true && AsientosTuristaDisponibles > 0)
                        {
                            Pasajeros.Add(pasajero);
                            AsientosTuristaDisponibles--;
                            CantidadPasajeros++;
                        }
                    }
                }
                CalcularDuracionVuelo(vueloNacional, avionSeleccionado, false);
                CalcularCostoVuelo(this, vueloNacional);
            }

            return this;
        } 

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

        public string ObtenerInformacionVuelo
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

        #region GENERADORES

        public void SeleccionarDestino(bool vueloNacional, Random random)
        {
            // Seleccionar destino
            if (vueloNacional)
            {
                // Seleccionar ciudad de partida
                int indexCiudadPartida = random.Next(Enum.GetNames(typeof(DestinosNacionales)).Length);
                this.CiudadPartida = ((DestinosNacionales)indexCiudadPartida).ToString();

                // Seleccionar ciudad de destino
                int indexCiudadDestino;
                do
                {
                    indexCiudadDestino = random.Next(Enum.GetNames(typeof(DestinosNacionales)).Length);
                } while (indexCiudadDestino == indexCiudadPartida);

                this.CiudadDestinoNacional = (DestinosNacionales)indexCiudadDestino;
                this.vueloNacional = true;
            }            
            else
            {
                this.CiudadPartida = "Buenos Aires";
                // Destino internacional
                int indexDestinoInternacional = random.Next(Enum.GetNames(typeof(DestinosInternacionales)).Length);
                this.CiudadDestinoInternacional = (DestinosInternacionales)indexDestinoInternacional;
                this.vueloNacional = false;
            }
        }

        public void SeleccionarAvion(Aerolinea aerolinea, Avion avionSeleccionado, Random random)
        {
            int indexAvion;
            // Asignar avión al vuelo y marcar como ocupado

            if (this.VueloPasado == true)
            {
                indexAvion = random.Next(aerolinea.listaAviones.Count);
                avionSeleccionado = aerolinea.listaAviones[indexAvion];
                avionSeleccionado.OcupadoEnVuelo = false;
            }
            else
            {
                do
                {
                    indexAvion = random.Next(aerolinea.listaAviones.Count);
                    avionSeleccionado = aerolinea.listaAviones[indexAvion];
                } while (avionSeleccionado.OcupadoEnVuelo == true);
                avionSeleccionado.OcupadoEnVuelo = true;
            }
            this.Avion = avionSeleccionado;
        }

        public void CalcularAsientosDisponibles(Vuelo vuelo)
        {
            // Calcular cantidad de asientos turista y premium
            int totalAsientos = vuelo.Avion.CantidadAsientos;
            vuelo.AsientosTuristaDisponibles = (int)Math.Ceiling(totalAsientos * 0.8);
            vuelo.AsientosPremiumDisponibles = totalAsientos - vuelo.AsientosTuristaDisponibles;
        }

        public void CalcularDuracionVuelo(bool vueloNacional, Avion avion, bool esFuturo)
        {
            int duracionVueloHoras;
            Random random = new Random(DateTime.Now.Millisecond);
            System.Threading.Thread.Sleep(300);

            // Calcular duración del vuelo en horas
            if (vueloNacional == true)
            {
                // Duración de vuelo nacional entre 2 y 4 horas
                duracionVueloHoras = random.Next(2, 5);
            }
            else
            {
                // Duración de vuelo internacional entre 8 y 12 horas
                duracionVueloHoras = random.Next(8, 13);
            }

            // Asignar duración del vuelo
            DuracionVuelo = duracionVueloHoras;
        }

        public void CalcularCostoVuelo(Vuelo vuelo, bool vueloNacional)
        {
            // Calcular costos del vuelo
            decimal costoTurista, costoPremium;

            if (vueloNacional == true)
            {
                costoTurista = 50 * (decimal)vuelo.DuracionVuelo;
                costoPremium = costoTurista * 1.35m;
            }
            else
            {
                costoTurista = (100 * (decimal)vuelo.DuracionVuelo);
                costoPremium = costoTurista * 1.35m;
            }

            // Asignar costos al vuelo
            vuelo.CostoTurista = costoTurista;
            vuelo.CostoPremium = costoPremium;
        }

        public bool VerificarDniExistente(int dni)
        {
            // Verificar si el DNI ya existe en la lista de pasajeros
            foreach (Pasajero pasajero in Pasajeros)
            {
                if (pasajero.Dni == dni)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
