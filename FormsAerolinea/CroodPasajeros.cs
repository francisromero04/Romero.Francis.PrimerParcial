using BibliotecaAerolineasCompleto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FormsAerolinea
{
    public partial class CroodPasajeros : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        public CroodPasajeros(Persona usuario, Aerolinea aerolinea)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            lbldentificador.Text = $"{usuario.cargo} - {DateTime.Now:G}";
            ActualizarListas();

            gbxCrearPasajero.Visible = false;
            gbxCrearPasajeroAleatorio.Visible = false;
            gbxModificarPasajero.Visible = false;
            gbxEliminarPasajero.Visible = false;
        }

        #region

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal(usuario, aerolinea).Show(); 
        }

        private void cmbxPasajeros_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pasajero pasajeroSeleccionado = (Pasajero)cmbxPasajeros.SelectedItem;

            if (pasajeroSeleccionado != null)
            {
                txtNombrePasajeroDos.Text = pasajeroSeleccionado.nombres;
                txtApellidoDos.Text = pasajeroSeleccionado.apellidos;
                txtDniPasajeroDos.Text = pasajeroSeleccionado.dni.ToString();
            }
        }

        private void btnOpcionUno_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = btnRegresar.Visible = false;
            int posX = (Width - gbxCrearPasajeroAleatorio.Width) / 2;
            int posY = (Height - gbxCrearPasajeroAleatorio.Height) / 2;
            gbxCrearPasajeroAleatorio.Location = new Point(posX, posY);
            gbxCrearPasajeroAleatorio.Visible = true;
        }

        private void btnOpcionDos_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = btnRegresar.Visible = false;
            int posX = (Width - gbxModificarPasajero.Width) / 2;
            int posY = (Height - gbxModificarPasajero.Height) / 2;
            gbxModificarPasajero.Location = new Point(posX, posY);
            gbxModificarPasajero.Visible = true;
        } 

        private void btnOpcionTres_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = btnRegresar.Visible = false;
            int posX = (Width - gbxEliminarPasajero.Width) / 2;
            int posY = (Height - gbxEliminarPasajero.Height) / 2;
            gbxEliminarPasajero.Location = new Point(posX, posY);
            gbxEliminarPasajero.Visible = true;
            gbxEliminarPasajero.Visible = true;
        }
        
        private void btnOpcionCuatro_Click_1(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = btnRegresar.Visible = false;
            int posX = (Width - gbxCrearPasajero.Width) / 2;
            int posY = (Height - gbxCrearPasajero.Height) / 2;
            gbxCrearPasajero.Location = new Point(posX, posY);
            gbxCrearPasajero.Visible = true;
        }

        #endregion

        #region

        private void btnCrearAleatorio_Click(object sender, EventArgs e)
        {
            Pasajero pasajero = new Pasajero().GenerarPasajeroAleatorio();
            if (aerolinea.VerificarDniExistente(pasajero.dni) == false)
            {
                aerolinea.agregarPasajero(pasajero);
                ActualizarListas();
            }
            else
            {
                MessageBox.Show("El pasajero tiene un dni perteneciente a otro pasajero.");
            }
        }
        
        private void btnCrearPasajero_Click(object sender, EventArgs e)
        {
            string nombrePasajero = txtNombrePasajerotres.Text;
            string apellidoPasajero = txtApellidoPasajeroTres.Text;
            string dniPasajero = txtDniPasajeroTres.Text;

            if (int.TryParse(dniPasajero, out int dni))
            {
                Pasajero pasajero = new Pasajero(dni, nombrePasajero, apellidoPasajero);
                if (aerolinea.VerificarDniExistente(pasajero.dni) == false)
                { 
                    aerolinea.agregarPasajero(pasajero);
                    MessageBox.Show("El pasajero ha sido dado de alta.");
                    ActualizarListas();
                }
                else
                {
                    MessageBox.Show("El pasajero tiene un dni perteneciente a otro pasajero.");
                }
            }
        }        

        private void btnModificar_Click(object sender, EventArgs e)
        {

            // Obtener el objeto pasajero seleccionado en el ComboBox
            Pasajero pasajeroSeleccionado = (Pasajero)cmbxPasajeros.SelectedItem;
            // Verificar si el nuevo DNI ingresado ya existe en la lista de pasajeros
            bool dniExistente = aerolinea.VerificarDniExistente(pasajeroSeleccionado.dni);
            int dni;
            int.TryParse(txtDniPasajeroDos.Text, out dni);

            if (dniExistente && pasajeroSeleccionado.dni != dni)
            {
                MessageBox.Show("El pasajero tiene un DNI perteneciente a otro pasajero.");
            }
            else if ((pasajeroSeleccionado.nombres != txtNombrePasajeroDos.Text || pasajeroSeleccionado.apellidos != txtApellidoDos.Text) && pasajeroSeleccionado.dni == dni)
            {
                // Actualizar las propiedades del objeto con los valores de los TextBoxes y CheckBoxes
                if (actualizarNombre(pasajeroSeleccionado) && actualizarApellido(pasajeroSeleccionado))
                {
                    aerolinea.ReemplazarPasajeroSeleccionado(pasajeroSeleccionado);
                    ActualizarListas();
                    LimpiarTextBoxes();
                    MessageBox.Show("Modificacion Exitosa");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string nombreAEliminar = cmbxPasajerosDos.Text; // Obtener el nombre de la combobox
            Pasajero pasajeroAEliminar = null; //buscar el pasajero con el nombre seleccionado en la cmbx


            foreach (Pasajero pasajero in aerolinea.listaPasajeros)
            {
                if (pasajero.nombreCompletoyDni == nombreAEliminar)
                {
                    pasajeroAEliminar = pasajero;
                    break;
                }
            }

            // Si se encontró el avión, eliminarlo de la lista
            if (pasajeroAEliminar != null)
            {
                aerolinea.eliminarPasajero(pasajeroAEliminar);
                cmbxPasajerosDos.Items.Remove(nombreAEliminar);
                MessageBox.Show("El pasajero ha sido eliminado.");
                ActualizarListas();
            }
            else
            {
                MessageBox.Show("No se encontró ningún pasajero con el nombre seleccionado.");
            }
        }

        #endregion

        #region

        private void btnCerrarUno_Click(object sender, EventArgs e)
        {
            gbxCrearPasajeroAleatorio.Visible = false;
            btnOpcionUno.Visible = true;
            btnOpcionDos.Visible = true;
            btnOpcionTres.Visible = true;
            btnOpcionCuatro.Visible = true;
            btnRegresar.Visible = true;
        }
        
        private void btnCerrarDos_Click(object sender, EventArgs e)
        {
            gbxModificarPasajero.Visible = false;
            btnOpcionUno.Visible = true;
            btnOpcionDos.Visible = true;
            btnOpcionTres.Visible = true;
            btnOpcionCuatro.Visible = true;
            btnRegresar.Visible = true;
        }
        
        private void btnCerrarTres_Click(object sender, EventArgs e)
        {
            gbxEliminarPasajero.Visible = false;
            btnOpcionUno.Visible = true;
            btnOpcionDos.Visible = true;
            btnOpcionTres.Visible = true;
            btnOpcionCuatro.Visible = true;
            btnRegresar.Visible = true;
        }
        
        private void btnCerrarCuatro_Click(object sender, EventArgs e)
        {
            gbxCrearPasajero.Visible = false;
            btnOpcionUno.Visible = true;
            btnOpcionDos.Visible = true;
            btnOpcionTres.Visible = true;
            btnOpcionCuatro.Visible = true;
            btnRegresar.Visible = true;
        }

        #endregion
        
        #region
     
        private bool actualizarNombre(Pasajero pasajero)
        {
            if (Validador.ValidarCadena(txtNombrePasajeroDos.Text))
            {
                pasajero.nombres = txtNombrePasajeroDos.Text;
                return true;
            }
            else
            {
                MessageBox.Show("Error al introducir el nombre.");
                return false;
            }
        }

        private bool actualizarApellido(Pasajero pasajero)
        {
            if (Validador.ValidarCadena(txtApellidoDos.Text))
            {
                pasajero.apellidos = txtApellidoDos.Text;
                return true;
            }
            else
            {
                MessageBox.Show("Error al introducir el apellido.");
                return false;
            }
        }

        private bool actualizarDni(Pasajero pasajero)
        {
            int dni;

            if (int.TryParse(txtDniPasajeroDos.Text, out dni) && Validador.ValidarDNI(dni))
            {
                pasajero.dni = dni;
                return true; 
            }
            else
            {
                MessageBox.Show("Error al introducir DNI.");
                return false;
            }
        }

        private void ActualizarListas()
        {
            lstPasajeros.DataSource = null;
            cmbxPasajeros.DataSource = null;
            cmbxPasajerosDos.DataSource = null;

            lstPasajeros.DataSource = aerolinea.listaPasajeros;
            cmbxPasajeros.DataSource = aerolinea.listaPasajeros;
            cmbxPasajerosDos.DataSource = aerolinea.listaPasajeros;

            lstPasajeros.DisplayMember = "nombreCompletoYdni";
            cmbxPasajeros.DisplayMember = "nombreCompletoYdni";
            cmbxPasajerosDos.DisplayMember = "nombreCompletoYdni";

            lstPasajeros.Refresh();
            cmbxPasajeros.Refresh();
            cmbxPasajerosDos.Refresh();
        }

        private void LimpiarTextBoxes()
        {
            txtApellidoDos.Text = "";
            txtNombrePasajeroDos.Text = "";
            txtDniPasajeroDos.Text = "";
        }

        #endregion
    }
}
