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
    public partial class ViajesDisponibles : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        public ViajesDisponibles(Persona usuario, Aerolinea aerolinea)
        {
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            InitializeComponent();
            ActualizarListas();
        }

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

        private void cmbxListaViajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vuelo viajeSeleccionado = (Vuelo)cmbxListaViajes.SelectedItem;

            txtPrecio.Text = "Costo Turista: US$" + viajeSeleccionado.CostoTurista.ToString() + ", Costo Premium: US$" + viajeSeleccionado.CostoPremium.ToString();
            txtOrigen.Text = "Origen: " + viajeSeleccionado.CiudadPartida;
            txtDestino.Text = "Destino: " + (viajeSeleccionado.vueloNacional ? viajeSeleccionado.CiudadDestinoNacional.ToString() : viajeSeleccionado.CiudadDestinoInternacional.ToString());
            txtFecha.Text = "Fecha: " + viajeSeleccionado.FechaVuelo.ToString();
            txtCantidadPasajeros.Text = "Pasajeros: " + viajeSeleccionado.CantidadPasajeros.ToString();
        }
    }
}
