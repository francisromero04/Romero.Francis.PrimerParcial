using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            Debug.WriteLine("mensaje de prueba");
            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("Debe ingresar un correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            string correo = txtCorreo.Text;
            string contraseña = txtContraseña.Text;
            Console.WriteLine(correo);
            Console.WriteLine(contraseña);

            // Verificar si los valores de correo y contraseña son correctos
            if(baseDeDatos.buscarUsuario(correo, contraseña) != null)
            {
                // Los valores de correo y contraseña son correctos
                // Realizar la acción correspondiente, como abrir una nueva ventana o mostrar un mensaje de bienvenida
                MessageBox.Show("CORREO INGRESADO CORRECTAMENTE", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
