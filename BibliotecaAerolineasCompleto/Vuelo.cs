using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public bool vueloNacional { get; set; }

        public Vuelo CrearVueloAleatorio(List<Avion> listaAviones)
        {
            Random random = new Random();
            // Generar destino aleatorio
            DestinosNacionales destinoNacional = (DestinosNacionales)random.Next(Enum.GetNames(typeof(DestinosNacionales)).Length);
            DestinosInternacionales destinoInternacional = (DestinosInternacionales)random.Next(Enum.GetNames(typeof(DestinosInternacionales)).Length);
            bool vueloNacional = random.NextDouble() < 0.75;

            // Crear vuelo
            Vuelo vuelo = new Vuelo
            {
                CiudadPartida = "Buenos Aires", // Ciudad de partida fija
                CiudadDestinoNacional = vueloNacional ? destinoNacional : DestinosNacionales.SantaRosa, // Si es internacional, asignar Santa Rosa como destino nacional
                //CiudadDestinoInternacional = vueloNacional ? DestinosInternacionales.RecifeBrasil : destinoInternacional, // Si es nacional, asignar Recife como destino internacional
                FechaVuelo = DateTime.Now.AddDays(random.Next(1, 30)), // Fecha de vuelo aleatoria en los próximos 30 días
                AsientosPremiumDisponibles = random.Next(10, 21), // Asientos premium aleatorios entre 10 y 20
                AsientosTuristaDisponibles = random.Next(100, 201), // Asientos turista aleatorios entre 100 y 200
                CostoPremium = (decimal)(random.NextDouble() * 500 + 1000), // Costo premium aleatorio entre 1000 y 1500
                CostoTurista = (decimal)(random.NextDouble() * 300 + 500), // Costo turista aleatorio entre 500 y 800
                DuracionVuelo = new TimeSpan(random.Next(1, 5), random.Next(0, 60), 0), // Duración de vuelo aleatoria entre 1 y 5 horas
                Pasajeros = new List<Pasajero>(), // Lista de pasajeros vacía
                vueloNacional = vueloNacional // Asignar si es un vuelo nacional o internacional
            };

            Avion avion = new Avion();

            do
            {
                int indexAvion = random.Next(listaAviones.Count);
                avion = listaAviones[indexAvion]; //da error si no se crearon aviones ni pasajeros

            } while (avion.OcupadoEnVuelo == true);


            // Verificar si el avión está disponible
            if (avion.OcupadoEnVuelo)
            {
                Console.WriteLine("El avión seleccionado ya está en uso."); //usar en carga manual
                return null;
            }

            //SI LA FECHA ES HOY ESTA OCUPADO EN VUELO, SI LA FECHA ES FUTURA NO ESTA OCUPADO, SI LA FECHA ES PASADA YA SE REALIZO EL VUELO

            // Asignar avión al vuelo y marcar como ocupado
            vuelo.Avion = avion;
            avion.OcupadoEnVuelo = true;

            return vuelo;
        }

        public string ObtenerInformacionVuelo
        {
            get{ 
                string info = $"Origen: {CiudadPartida}, ";
         
                if (vueloNacional)
                {
                    info += $"Destino: {CiudadDestinoNacional}, ";
                }
                else
                {
                    info += $"Destino: {CiudadDestinoInternacional}, ";
                }

                info += $"Fecha: {FechaVuelo.ToString("dd/MM/yyyy")}, ";
                info += $"Duración: {DuracionVuelo.ToString()}, ";
                info += $"Asientos premium disponibles: {AsientosPremiumDisponibles}, ";
                info += $"Asientos turista disponibles: {AsientosTuristaDisponibles}, ";
                info += $"Costo premium: ${CostoPremium.ToString()}, ";
                info += $"Costo turista: ${CostoTurista.ToString()}, ";

                if (Avion != null)
                {
                    info += $"Avión: {Avion.Matricula}";
                }

                return info;
            }
        }
    }
}
