using BibliotecaAerolineasCompleto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsAerolinea
{
    public partial class MenuPrincipal : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        public MenuPrincipal(Persona usuario, Aerolinea aerolinea)
        {
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            InitializeComponent();
            ActualizarFechaHora();
            InhabilitarBotones();

            //CREAR CLASE PARA TIMER
            // Inicializar el temporizador para actualizar la fecha y hora cada segundo
            Timer timer = new Timer();
            timer.Interval = 1000; // Intervalo en milisegundos
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ActualizarFechaHora();
        }

        private void ActualizarFechaHora()
        {
            lbldentificador.Text = usuario.cargo + " - " + DateTime.Now.ToString();
        }

        private void InhabilitarBotones()
        {
            switch (usuario.cargo)
            {
                case "Administrador":
                  /*  btnOpcionUno.Enabled = false;
                    btnOpcionDos.Enabled = false;
                    btnOpcionTres.Enabled = false;
                    btnOpcionCinco.Enabled = false;
                    btnOpcionUno.ForeColor = btnOpcionDos.ForeColor = btnOpcionTres.ForeColor = btnOpcionCinco.ForeColor = Color.Gray;*/
                    break;
                case "Supervisor":
                    btnOpcionUno.Enabled = false;
                    btnOpcionDos.Enabled = false;
                    btnOpcionCuatro.Enabled = false;
                    btnOpcionSeis.Enabled = false;
                    btnOpcionUno.ForeColor = btnOpcionDos.ForeColor = btnOpcionCuatro.ForeColor = btnOpcionSeis.ForeColor = Color.Gray;
                    break;
                case "Vendedor 1":
                case "Vendedor 2":
                case "Vendedor 3":
                    btnOpcionCuatro.Enabled = false;
                    btnOpcionSeis.Enabled = false;
                    btnOpcionCuatro.ForeColor = btnOpcionCuatro.ForeColor = btnOpcionSeis.ForeColor = Color.Gray;
                    break;
            }
        }

        private void AbrirFormulario(Form formulario)
        {
            this.Hide();
            formulario.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login();
            AbrirFormulario(formLogin);
        }

        #region

        private void btnOpcionUno_Click(object sender, EventArgs e)
        {
            ViajesDisponibles formListaViajes = new ViajesDisponibles(usuario);
            AbrirFormulario(formListaViajes);
        }

        private void btnOpcionDos_Click(object sender, EventArgs e)
        {
            VenderViaje formVender = new VenderViaje(usuario);
            AbrirFormulario(formVender);
        }

        private void btnOpcionTres_Click(object sender, EventArgs e)
        {
            ConsultarEstadisticas formConsultar = new ConsultarEstadisticas(usuario);
            AbrirFormulario(formConsultar);
        }

        private void btnOpcionCuatro_Click(object sender, EventArgs e)
        {
            CroodViajes formCroodUno = new CroodViajes(usuario, aerolinea);
            AbrirFormulario(formCroodUno);
        }
        private void btnOpcionCinco_Click(object sender, EventArgs e)
        {
            CroodPasajeros formCroodDos = new CroodPasajeros(usuario, aerolinea);
            AbrirFormulario(formCroodDos);
        }

        private void btnOpcionSeis_Click(object sender, EventArgs e)
        {
            CroodAeronaves formCroodTres = new CroodAeronaves(usuario, aerolinea);
            AbrirFormulario(formCroodTres);
        }

        #endregion
    }
}
