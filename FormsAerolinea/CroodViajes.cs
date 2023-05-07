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
    public partial class CroodViajes : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        public CroodViajes(Persona usuario, Aerolinea aerolinea)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            lbldentificador.Text = usuario.cargo + " - " + DateTime.Now.ToString();

            lstViajes.DataSource = null;
            lstViajes.DataSource = aerolinea.listaVuelos;
            lstViajes.DisplayMember = "ObtenerInformacionVuelo";
            lstViajes.Refresh();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPrincipal formMenuP = new MenuPrincipal(usuario, aerolinea);
            formMenuP.Show();
        }

        private void btnOpcionUno_Click(object sender, EventArgs e)
        {
            Vuelo vuelo = new Vuelo().CrearVueloAleatorio(aerolinea.listaAviones);
            aerolinea.agregarVuelo(vuelo);

            lstViajes.DataSource = null;
            lstViajes.DataSource = aerolinea.listaVuelos;
            lstViajes.DisplayMember = "ObtenerInformacionVuelo";
            lstViajes.Refresh();
        }
    }
}
