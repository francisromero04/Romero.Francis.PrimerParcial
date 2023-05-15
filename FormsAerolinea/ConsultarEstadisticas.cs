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
    public partial class ConsultarEstadisticas : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        public ConsultarEstadisticas(Persona usuario, Aerolinea aerolinea)
        {
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            InitializeComponent();
            ActualizarListas();
            lblDineroTotal.Text = "Dinero recaudado:: " + aerolinea.dineroTotal;
            lblDestino.Text = "Destino mas seleccionado es: " + aerolinea.DestinoMasSeleccionado();
        }

        public void ActualizarListas()
        {
            var vuelosRealizados = new List<Vuelo>();
            foreach (var vuelo in aerolinea.listaVuelos)
            {
                if (vuelo.FechaVuelo < DateTime.Now)
                {
                    vuelosRealizados.Add(vuelo);
                }
            }

            cmbxListaViajesRealizados.DataSource = null;
            cmbxListaViajesRealizados.DataSource = vuelosRealizados;
            cmbxListaViajesRealizados.DisplayMember = "ObtenerInformacionVuelo";
            cmbxListaViajesRealizados.Refresh();
        }

        private void cmbxListaViajesRealizados_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vuelo vueloSeleccionado = (Vuelo)cmbxListaViajesRealizados.SelectedItem;
            lblPasajeros.Text = "Cantidad de Pasajeros: " + vueloSeleccionado.CantidadPasajeros.ToString();
        }
    }
}
