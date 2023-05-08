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
            lbldentificador.Text = usuario.cargo + " - " + DateTime.Now.ToString();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPrincipal formMenuP = new MenuPrincipal(usuario, aerolinea);
            formMenuP.Show();
        }
    }
}
