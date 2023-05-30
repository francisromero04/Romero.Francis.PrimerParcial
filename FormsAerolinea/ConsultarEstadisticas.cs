using BibliotecaAerolineasCompleto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsAerolinea
{
    /// <summary>
    /// Representa un formulario para consultar estadísticas relacionadas con una aerolínea.
    /// </summary>
    public partial class ConsultarEstadisticas : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ConsultarEstadisticas"/>.
        /// </summary>
        /// <param name="usuario">El usuario que accede a las estadísticas.</param>
        /// <param name="aerolinea">La aerolínea para la cual se están consultando las estadísticas.</param>
        public ConsultarEstadisticas(Persona usuario, Aerolinea aerolinea)
        {
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            InitializeComponent();
            ActualizarListas();
            lblDineroTotal.Text += "Nacional: " + aerolinea.DineroTotalNacional + " | Internacional: " + aerolinea.DineroTotalInternacional;
            lblDestino.Text += aerolinea.DestinoMasSeleccionado();
        }

        /// <summary>
        /// Actualiza las listas y los ComboBox mostrados en el formulario.
        /// </summary> 
        private void ActualizarListas()
        {
            var vuelosRealizados = new List<Vuelo>();
            foreach (var vuelo in aerolinea.ListaVuelos)
            {
                if (vuelo.FechaVuelo < DateTime.Now)
                {
                    vuelosRealizados.Add(vuelo);
                }
            }

            cmbxListaViajesRealizados.DataSource = null;
            cmbxListaViajesRealizados.DataSource = vuelosRealizados;
            cmbxListaViajesRealizados.DisplayMember = "ObtenerInformacionVueloResumida";
            cmbxListaViajesRealizados.Refresh();

            cmbxAviones.DataSource = null;
            cmbxAviones.DataSource = aerolinea.ListaAviones;
            cmbxAviones.DisplayMember = nameof(Avion.ToString);
            cmbxAviones.Refresh();

            List<Pasajero> pasajerosOrdenados = aerolinea.ListaPasajeros.OrderByDescending(p => p.CantidadVuelosHistoricos).ToList();
            lstPasajerosOrdenados.DataSource = null;
            lstPasajerosOrdenados.DataSource = pasajerosOrdenados;
            lstPasajerosOrdenados.DisplayMember = "NombreCompletoyDniyViajes";
            lstPasajerosOrdenados.Refresh();

            var elementosOrdenados = aerolinea.gananciaInternacional.OrderByDescending(x => x.Value);
            var elementosOrdenadosDos = aerolinea.gananciaNacional.OrderByDescending(x => x.Value);

            foreach (var elemento in elementosOrdenados)
            {
                lstDestinos.Items.Add(elemento.Key + ": " + elemento.Value);
            }

            foreach (var elemento in elementosOrdenadosDos)
            {
                lstDestinos.Items.Add(elemento.Key + ": " + elemento.Value);
            }
        }

        /// <summary>
        /// Se ejecuta cuando se selecciona un elemento en el ComboBox de viajes realizados.
        /// Actualiza la etiqueta lblPasajeros con la cantidad de pasajeros del vuelo seleccionado.
        /// </summary>
        private void cmbxListaViajesRealizados_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vuelo vueloSeleccionado = (Vuelo)cmbxListaViajesRealizados.SelectedItem;
            lblPasajeros.Text = "Pasajeros del vuelo seleccionado: " + vueloSeleccionado.CantidadPasajeros.ToString();
        }

        /// <summary>
        /// Se ejecuta cuando se selecciona un elemento en el ComboBox de aviones.
        /// Actualiza la etiqueta lblHorasVuelo con las horas de vuelo históricas del avión seleccionado.
        /// </summary>
        private void cmbxAviones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Avion avionSeleccionado = (Avion)cmbxAviones.SelectedItem;
            lblHorasVuelo.Text = "Horas Vuelo del Avion seleccionado: " + avionSeleccionado.HorasVueloHistoricas;
        }
    }
}
