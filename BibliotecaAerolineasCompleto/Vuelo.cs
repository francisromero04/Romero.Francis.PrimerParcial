using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public int CantidadPasajeros { get; set; }
        public decimal CostoPremium { get; set; }
        public decimal CostoTurista { get; set; }
        public TimeSpan DuracionVuelo { get; set; }
        public List<Pasajero> Pasajeros { get; set; }
        public bool vueloNacional { get; set; }
        public decimal IVA { get; set; }
        public bool VueloPasado {get; set;}    

        private Aerolinea aerolinea;

        public Vuelo(Aerolinea aerolinea)
        {
            this.aerolinea = aerolinea;
            Pasajeros = new List<Pasajero>();
            IVA = 1.21m;
        }

        public Vuelo GenerarVueloAleatorio(Aerolinea aerolinea)
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

                    if (VerificarDniExistente(pasajero.dni) == false)
                    {
                        if(pasajero.tipoPasajero == false && AsientosPremiumDisponibles > 0)
                        {
                            Pasajeros.Add(pasajero);
                            CantidadPasajeros++;
                            AsientosPremiumDisponibles--;
                        }
                        else if (pasajero.tipoPasajero == true && AsientosTuristaDisponibles > 0)
                        {
                            Pasajeros.Add(pasajero);
                            CantidadPasajeros++;
                            AsientosTuristaDisponibles--;
                        }
                    }
                }
                CalcularDuracionVuelo(this, vueloNacional, random);
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

                    if (VerificarDniExistente(pasajero.dni) == false)
                    {
                        if (pasajero.tipoPasajero == false && AsientosPremiumDisponibles > 0)
                        {
                            Pasajeros.Add(pasajero);
                            AsientosPremiumDisponibles--;
                            CantidadPasajeros++;
                        }
                        else if (pasajero.tipoPasajero == true && AsientosTuristaDisponibles > 0)
                        {
                            Pasajeros.Add(pasajero);
                            AsientosTuristaDisponibles--;
                            CantidadPasajeros++;
                        }
                    }
                }
                CalcularDuracionVuelo(this, vueloNacional, random);
                CalcularCostoVuelo(this, vueloNacional);
            }

            return this;
        }

        public bool ContienePasajero(Pasajero pasajero)
        {
            foreach(Pasajero p in Pasajeros)
            {
                if(p == pasajero)
                {
                    return true;
                    MessageBox.Show("El pasajero ya fue incorporado a la lista de pasajeros perteneciente al vuelo seleccionado.");
                    break;
                }
            }
            
            return false;
        }

        public void VenderPasaje(Pasajero pasajero, bool esPremium)
        {
            if (pasajero == null)
            {
                throw new ArgumentNullException("El objeto pasajero es nulo.");
            }

            if (esPremium && AsientosPremiumDisponibles > 0 && Avion.CapacidadBodega > pasajero.pesoEquipaje) //verificar con el avion
            {
                CantidadPasajeros++;
                AsientosPremiumDisponibles--;
            }
            else if (!esPremium && AsientosTuristaDisponibles > 0 && Avion.CapacidadBodega > pasajero.pesoEquipaje)
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
                string info = $"\nOrigen: {CiudadPartida}, ";

                if (vueloNacional)
                {
                    info += $"\nDestino: {CiudadDestinoNacional}, ";
                    info += $"\nTipo de vuelo: Nacional, ";
                }
                else
                {
                    info += $"\nDestino: {CiudadDestinoInternacional}, ";
                    info += $"\nTipo de vuelo: Internacional, ";
                }

               /* if (Avion != null)
                {
                    info += $"\nAvión: {Avion.Matricula}, ";
                }

                info += $"\nCant. pasajeros: {CantidadPasajeros}, ";*/
                info += $"\nFecha: {FechaVuelo.ToString("dd/MM/yyyy")}, ";
                //info += $"\nDuración: {DuracionVuelo.ToString()}, ";
                //info += $"\nAsientos premium disponibles: {AsientosPremiumDisponibles}, ";
                //info += $"\nAsientos turista disponibles: {AsientosTuristaDisponibles}, ";
                info += $"\nCosto premium: ${CostoPremium.ToString()}, ";
                info += $"\nCosto turista: ${CostoTurista.ToString()}";

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

        public void CalcularDuracionVuelo(Vuelo vuelo, bool vueloNacional, Random random)
        {
            double duracionVueloHoras;

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
            vuelo.DuracionVuelo = TimeSpan.FromHours(duracionVueloHoras);
        }

        public void CalcularCostoVuelo(Vuelo vuelo, bool vueloNacional)
        {
            // Calcular costos del vuelo
            decimal costoTurista, costoPremium;

            if (vueloNacional == true)
            {
                costoTurista = 50 * (decimal)vuelo.DuracionVuelo.TotalHours;
                costoPremium = 100 * (decimal)vuelo.DuracionVuelo.TotalHours;
            }
            else
            {
                costoTurista = (50 * (decimal)vuelo.DuracionVuelo.TotalHours) * 1.35m;
                costoPremium = (100 * (decimal)vuelo.DuracionVuelo.TotalHours) * 1.35m;
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
                if (pasajero.dni == dni)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
