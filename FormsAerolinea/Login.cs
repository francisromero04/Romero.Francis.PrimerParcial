using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaAerolineasCompleto;

namespace FormsAerolinea
{
    /// <summary>
    /// Clase que representa la ventana de inicio de sesión.
    /// </summary>
    public partial class Login : Form
    {
        private BaseDeDatos baseDeDatos = new BaseDeDatos();
        private static Aerolinea aerolinea = new Aerolinea(); //mantiene siempre la misma aerolinea

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Login"/>.
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }       

        #region MANEJO FORMULARIO      
        
        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Iniciar sesión".
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string contraseña = txtContraseña.Text;

            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("Debe ingresar un correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si los valores de correo y contraseña son correctos
            if(baseDeDatos.BuscarUsuario(correo, contraseña) != null)
            {
            // Escribir el correo y contraseña del usuario que inició sesión en el archivo de registro
            string logMessage = $"{baseDeDatos.DevolverUsuario(correo, contraseña)}-{DateTime.Now:dd/MM/yyyy HH:mm:ss}\n-----------------------------------------\n";
            using (StreamWriter writer = new StreamWriter("usuarios.log", true))
            {
                writer.WriteLine(logMessage);
            }

            MessageBox.Show("CORREO INGRESADO CORRECTAMENTE", "SESION INICIADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                MenuPrincipal menuPrincipal = new MenuPrincipal(baseDeDatos.BuscarUsuario(correo, contraseña), aerolinea);
                menuPrincipal.Show();
        } 
            else
            {
                // Si se llega a este punto, los valores de correo y contraseña no son correctos
                MessageBox.Show("El correo o la contraseña son incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Cerrar pestaña".
        /// Cierra la aplicación.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnCerrarPestaña_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Maneja el evento de hacer clic en el botón "Minimizar pestaña".
        /// Minimiza la ventana actual.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnMinimizarPestaña_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Maneja el evento cuando el cuadro de texto "Correo" obtiene el foco.
        /// Si el texto es igual a "USUARIO", se borra y se cambia el color de fuente a LightGray.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "USUARIO")
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.LightGray;
            }
        }

        /// <summary>
        /// Maneja el evento cuando el cuadro de texto "Correo" pierde el foco.
        /// Si el texto está vacío, se establece como "USUARIO" y se cambia el color de fuente a DimGray.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if(txtCorreo.Text == "")
            {
                txtCorreo.Text = "USUARIO";
                txtCorreo.ForeColor = Color.DimGray;
            }
        }

        /// <summary>
        /// Maneja el evento cuando el cuadro de texto "Contraseña" obtiene el foco.
        /// Si el texto es igual a "CONTRASEÑA", se borra, se cambia el color de fuente a LightGray y se muestra como carácter de contraseña.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        /// <summary>
        /// Maneja el evento cuando el cuadro de texto "Contraseña" pierde el foco.
        /// Si el texto está vacío, se establece como "CONTRASEÑA", se cambia el color de fuente a DimGray y se muestra como texto normal.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        /// <summary>
        /// Maneja el evento cuando se presiona el botón del mouse mientras el cursor está sobre el formulario de inicio de sesión.
        /// Libera la captura del mouse y envía un mensaje para arrastrar la ventana.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// Maneja el evento cuando se presiona el botón del mouse mientras el cursor está sobre el panel contenedor.
        /// Libera la captura del mouse y envía un mensaje para arrastrar la ventana.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void panelContenedor_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /// <summary>
        /// Maneja el evento cuando se presiona el botón del mouse mientras el cursor está sobre la barra vertical.
        /// Libera la captura del mouse y envía un mensaje para arrastrar la ventana.
        /// </summary>
        /// <param name="sender">Objeto que genera el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void barraVertical_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion
    }
}
