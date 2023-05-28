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
using System.Runtime.InteropServices;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace FormsAerolinea
{
    /// <summary>
    /// Representa el formulario principal del menú de la aplicación.
    /// </summary>
    public partial class MenuPrincipal : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        /// <summary>
        /// Crea una nueva instancia de la clase MenuPrincipal.
        /// </summary>
        /// <param name="usuario">El objeto Persona que representa al usuario actual.</param>
        /// <param name="aerolinea">El objeto Aerolinea que representa la aerolínea utilizada.</param>
        public MenuPrincipal(Persona usuario, Aerolinea aerolinea)
        {
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            ActualizarFecha();
            InhabilitarBotones();
        }

        #region OPCIONES CLICK

        /// <summary>
        /// Maneja el evento de clic del botón "Opción Uno".
        /// Abre el formulario de ViajesDisponibles.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnOpcionUno_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new ViajesDisponibles(usuario, aerolinea));
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Opción Dos".
        /// Abre el formulario de VenderViaje.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnOpcionDos_Click(object sender, EventArgs e)
        {
            VenderViaje formVender = new VenderViaje(usuario, aerolinea);
            AbrirFormularios(formVender);
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Opción Tres".
        /// Abre el formulario de ConsultarEstadisticas.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnOpcionTres_Click(object sender, EventArgs e)
        {
            ConsultarEstadisticas formConsultar = new ConsultarEstadisticas(usuario, aerolinea);
            AbrirFormularios(formConsultar);
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Opción Cuatro".
        /// Abre el formulario de CrudViajes.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnOpcionCuatro_Click(object sender, EventArgs e)
        {
            CrudViajes formCroodUno = new CrudViajes(usuario, aerolinea);
            AbrirFormularios(formCroodUno);
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Opción Cinco".
        /// Abre el formulario de CrudPasajeros.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnOpcionCinco_Click(object sender, EventArgs e)
        {
            CrudPasajeros formCroodDos = new CrudPasajeros(usuario, aerolinea);
            AbrirFormularios(formCroodDos);
        }

        /// <summary>
        /// Maneja el evento de clic del botón "Opción Seis".
        /// Abre el formulario de CrudAviones.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnOpcionSeis_Click(object sender, EventArgs e)
        {
            CrudAviones formCroodTres = new CrudAviones(usuario, aerolinea);
            AbrirFormularios(formCroodTres);
        }

        #endregion

        #region MANEJO FORMULARIO

        /// <summary>
        /// Inhabilita los botones según el cargo del usuario.
        /// </summary>
        private void InhabilitarBotones()
        {
            switch (usuario.cargo)
            {
                case "Administrador":
                 /*   btnOpcionUno.Enabled = false;
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

        /// <summary>
        /// Actualiza la fecha en un control de etiqueta (label).
        /// </summary>
        private void ActualizarFecha()
        {
            lblIdentificador.Text = usuario.cargo + "\n" + usuario.nombre + "\n" + DateTime.Now.ToShortDateString();
        }

        /// <summary>
        /// Cierra la aplicación y guarda los archivos JSON y XML.
        /// </summary>
        private void btnCerrarPestaña_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea cerrar la aplicación?", "Confirmación de cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                string json = JsonConvert.SerializeObject(aerolinea.listaAviones);
                File.WriteAllText("avionesDeAerolinea.json", json);

                XmlSerializer serializer = new XmlSerializer(typeof(SerializarVuelos));
                SerializarVuelos listaVuelosSerializar = new SerializarVuelos()
                {
                    Vuelos = aerolinea.listaVuelos,
                };

                using (TextWriter writer = new StreamWriter("vuelosDeAerolinea.xml"))
                {
                    serializer.Serialize(writer, listaVuelosSerializar);
                }

                XmlSerializer serializerDos = new XmlSerializer(typeof(SerializarPersonas));
                SerializarPersonas listaPasajerosSerializar = new SerializarPersonas()
                {
                    Pasajeros = aerolinea.listaPasajeros,
                };

                using (TextWriter writer = new StreamWriter("pasajeros.xml"))
                {
                    serializerDos.Serialize(writer, listaPasajerosSerializar);
                } 

                Application.Exit();
            } 
        }

        /// <summary>
        /// Maximiza la aplicación si la pestaña esta reducida.
        /// </summary>
        private void btnMaximizarPestaña_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        /// <summary>
        /// Restaura la aplicación si la pestaña esta completa.
        /// </summary>
        private void btnRestaurarPestaña_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        /// <summary>
        /// Minimiza la aplicación.
        /// </summary>
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Maneja el evento MouseDown del control barraTop.
        /// Permite arrastrar la ventana cuando se hace clic y se arrastra en la barra superior.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento MouseEventArgs.</param>
        private void barraTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// Abre el formulario especificado dentro del panel de contenido.
        /// Si ya hay un formulario abierto, se elimina antes de agregar el nuevo formulario.
        /// </summary>
        /// <param name="formAUtilizar">El formulario a abrir.</param>
        public void AbrirFormularios(object formAUtilizar)
        {
           if(this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form fh = formAUtilizar as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            fh.Show();
        }

        /// <summary>
        /// Maneja el evento Click del control pictureBox8 (cerrar sesión).
        /// Muestra el formulario de inicio de sesión (Login) y oculta el formulario actual.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento EventArgs.</param>
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login();
            this.Hide();
            formLogin.Show();
        }

        //CODIGO PARA MOVER EL FORMULARIO CON EL MOUSE
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        /// <summary>
        /// Maneja el evento Resize del control panelContenedor.
        /// Ajusta la ubicación del formulario cuando se cambia el tamaño del panelContenedor.
        /// Si el formulario está maximizado, establece la ubicación en la esquina superior izquierda (0, 0).
        /// Si el formulario no está maximizado, restaura la ubicación original del formulario secundario
        /// estableciendo la ubicación en una posición deseada (por ejemplo, 100, 100).
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento EventArgs.</param>
        private void panelContenedor_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Location = new Point(0, 0);
            }
            else
            {
                // Restaurar la ubicación original del formulario secundario
                Location = new Point(100, 100); // Establece la ubicación deseada
            }
        }

        #endregion
    }
}
