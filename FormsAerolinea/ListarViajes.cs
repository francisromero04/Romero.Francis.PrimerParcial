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
    /// Representa la ventana de la aplicación que muestra los viajes disponibles de una aerolínea para un usuario específico.
    /// </summary>
    public partial class ViajesDisponibles : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        /// <summary>
        /// Inicializa una nueva instancia de la clase ViajesDisponibles.
        /// </summary>
        /// <param name="usuario">El objeto Persona que representa al usuario actual.</param>
        /// <param name="aerolinea">El objeto Aerolinea que representa la aerolínea.</param>
        public ViajesDisponibles(Persona usuario, Aerolinea aerolinea)
        {
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            InitializeComponent();
            ActualizarListas();
        }

        /// <summary>
        /// Actualiza las listas de vuelos disponibles.
        /// </summary>
        public void ActualizarListas()
        {
            var vuelosFuturos = new List<Vuelo>();
            foreach (var vuelo in aerolinea.listaVuelos)
            {
                if (vuelo.FechaVuelo > DateTime.Now)
                {
                    vuelosFuturos.Add(vuelo);
                }
            }
            cmbxListaViajes.DataSource = null;
            cmbxListaViajes.DataSource = vuelosFuturos;
            cmbxListaViajes.DisplayMember = "ObtenerInformacionVuelo";
            cmbxListaViajes.Refresh();
        }

        /// <summary>
        /// Se ejecuta cuando se selecciona un viaje en el combobox.
        /// Actualiza los campos de texto con la información del viaje seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void cmbxListaViajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vuelo viajeSeleccionado = (Vuelo)cmbxListaViajes.SelectedItem;

            txtPrecio.Text = "El Costo Turista es de US$" + viajeSeleccionado.CostoTurista.ToString() + " y el Costo Premium es de US$" + viajeSeleccionado.CostoPremium.ToString();
            txtOrigen.Text = "Origen: " + viajeSeleccionado.CiudadPartida;
            txtDestino.Text = "Destino: " + (viajeSeleccionado.vueloNacional ? viajeSeleccionado.CiudadDestinoNacional.ToString() : viajeSeleccionado.CiudadDestinoInternacional.ToString());
            txtFecha.Text = "Fecha: " + viajeSeleccionado.FechaVuelo.ToString("dd/MM/yyyy");
            txtCantidadPasajeros.Text = "Pasajeros: " + viajeSeleccionado.CantidadPasajeros.ToString();
            lstPasajerosViaje.DataSource = null;
            lstPasajerosViaje.DataSource = viajeSeleccionado.Pasajeros;
            lstPasajerosViaje.DisplayMember = "NombreCompletoyDni";
            lstPasajerosViaje.Refresh();
        }
    }
}
