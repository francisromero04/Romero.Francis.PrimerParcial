﻿using System;
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

        private Aerolinea aerolinea;

        public Vuelo(Aerolinea aerolinea)
        {
            this.aerolinea = aerolinea;
        }

        public Vuelo CrearVueloAleatorio(Aerolinea aerolinea)
        {
            Random random = new Random();
            // Generar destino aleatorio
            DestinosNacionales destinoNacional = (DestinosNacionales)random.Next(Enum.GetNames(typeof(DestinosNacionales)).Length);
            DestinosInternacionales destinoInternacional = (DestinosInternacionales)random.Next(Enum.GetNames(typeof(DestinosInternacionales)).Length);
            bool vueloNacional = random.NextDouble() < 0.75;

            // Verificar si hay aviones y pasajeros creados
            if (aerolinea.listaAviones.Count == 0)
            {
                throw new Exception("Primero debe dar de alta aviones para poder crear un vuelo.");
            }
            else
            {
                // Verificar si hay aviones disponibles
                bool hayAvionesDisponibles = false;
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
                    MessageBox.Show("No hay aviones disponibles para crear un vuelo.");
                    return null;
                }
                else
                {
                    // Crear vuelo
                    Vuelo vuelo = new Vuelo(aerolinea)
                    {
                        CiudadPartida = "Buenos Aires", // Ciudad de partida fija
                        CiudadDestinoNacional = vueloNacional ? destinoNacional : DestinosNacionales.SantaRosa, // Si es internacional, asignar Santa Rosa como destino nacional
                        CiudadDestinoInternacional = vueloNacional ? DestinosInternacionales.RecifeBrasil : destinoInternacional, // Si es nacional, asignar Recife como destino internacional
                        FechaVuelo = DateTime.Now.AddDays(random.Next(1, 30)), // Fecha de vuelo aleatoria en los próximos 30 días
                        AsientosPremiumDisponibles = random.Next(10, 21), // Asientos premium aleatorios entre 10 y 20
                        AsientosTuristaDisponibles = random.Next(100, 201), // Asientos turista aleatorios entre 100 y 200
                        CostoPremium = (decimal)(random.NextDouble() * 500 + 1000), // Costo premium aleatorio entre 1000 y 1500
                        CostoTurista = (decimal)(random.NextDouble() * 300 + 500), // Costo turista aleatorio entre 500 y 800
                        DuracionVuelo = new TimeSpan(random.Next(1, 5), random.Next(0, 60), 0), // Duración de vuelo aleatoria entre 1 y 5 horas
                        Pasajeros = new List<Pasajero>(), // Lista de pasajeros vacía
                        vueloNacional = vueloNacional // Asignar si es un vuelo nacional o internacional
                    };

                    Avion avionSeleccionado = new Avion();

                    do
                    {
                        int indexAvion = random.Next(aerolinea.listaAviones.Count);
                        avionSeleccionado = aerolinea.listaAviones[indexAvion];
                    } while (avionSeleccionado.OcupadoEnVuelo == true);

                    // Asignar avión al vuelo y marcar como ocupado
                    vuelo.Avion = avionSeleccionado;
                    avionSeleccionado.OcupadoEnVuelo = true;

                    return vuelo;
                }
            }
        }

        public void VenderPasaje(Pasajero pasajero, bool esPremium)
        {
            if (esPremium && AsientosPremiumDisponibles > 0 && Avion.CapacidadBodega > pasajero.pesoEquipaje)
            {
                Pasajeros.Add(pasajero);
                aerolinea.listaPasajeros.Add(pasajero);
                AsientosPremiumDisponibles--;
                aerolinea.dineroTotal += CostoPremium;
                CantidadPasajeros++;
            }
            else if (!esPremium && AsientosTuristaDisponibles > 0 && Avion.CapacidadBodega > pasajero.pesoEquipaje)
            {
                Pasajeros.Add(pasajero);
                aerolinea.listaPasajeros.Add(pasajero);
                AsientosTuristaDisponibles--;
                aerolinea.dineroTotal += CostoTurista;
                CantidadPasajeros++;
            }
            else
            {
                throw new Exception("No se puede vender el pasaje.");
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

                if (Avion != null)
                {
                    info += $"\nAvión: {Avion.Matricula}, ";
                }

                info += $"\nCant. pasajeros: {CantidadPasajeros}, ";
                info += $"\nFecha: {FechaVuelo.ToString("dd/MM/yyyy")}, ";
                info += $"\nDuración: {DuracionVuelo.ToString()}, ";
                info += $"\nAsientos premium disponibles: {AsientosPremiumDisponibles}, ";
                info += $"\nAsientos turista disponibles: {AsientosTuristaDisponibles}, ";
                info += $"\nCosto premium: ${CostoPremium.ToString()}, ";
                info += $"\nCosto turista: ${CostoTurista.ToString()}";

                return info;
            }
        }
    }
}
