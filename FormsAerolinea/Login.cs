using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaAerolineasCompleto;

namespace FormsAerolinea
{
    public partial class Login : Form
    {
        private BaseDeDatos baseDeDatos = new BaseDeDatos();
        private static Aerolinea aerolinea = new Aerolinea(); //mantiene siempre la misma aerolinea

        public Login()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

         private void btnIniciarSesion_Click(object sender, EventArgs e)
         {
             if (string.IsNullOrEmpty(txtCorreo.Text))
             {
                 MessageBox.Show("Debe ingresar un correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;

             }

             string correo = txtCorreo.Text;
             string contraseña = txtContraseña.Text;

             // Verificar si los valores de correo y contraseña son correctos
             if(baseDeDatos.buscarUsuario(correo, contraseña) != null)
             {
                 MessageBox.Show("CORREO INGRESADO CORRECTAMENTE", "SESION INICIADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 this.Hide();
                 MenuPrincipal menuPrincipal = new MenuPrincipal(baseDeDatos.buscarUsuario(correo, contraseña), aerolinea);
                 menuPrincipal.Show();
             } 
             else
             {
                 // Si se llega a este punto, los valores de correo y contraseña no son correctos
                 MessageBox.Show("El correo o la contraseña son incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
         }

        #region MANEJO FORMULARIO

        private void btnCerrarPestaña_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizarPestaña_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "USUARIO")
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.LightGray;
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if(txtCorreo.Text == "")
            {
                txtCorreo.Text = "USUARIO";
                txtCorreo.ForeColor = Color.DimGray;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelContenedor_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void barraVertical_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion
    }
}
