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
    public partial class CrudPasajeros : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        public CrudPasajeros(Persona usuario, Aerolinea aerolinea)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            ActualizarListas();

            gbxCrearPasajero.Visible = false;
            gbxModificarPasajero.Visible = false;
            gbxEliminarPasajero.Visible = false;
        }

        #region CONFIGURACION GROUPBOX

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
                txtNombrePasajeroDos.Text = pasajeroSeleccionado.nombre;
                txtApellidoDos.Text = pasajeroSeleccionado.apellido;
                txtDniPasajeroDos.Text = pasajeroSeleccionado.dni.ToString();
            }
        }

        private void btnOpcionDos_Click(object sender, EventArgs e)
        {
            btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            int posX = (Width - gbxModificarPasajero.Width) / 2;
            int posY = (Height - gbxModificarPasajero.Height) / 2;
            gbxModificarPasajero.Location = new Point(posX, posY);
            gbxModificarPasajero.Visible = true;
        } 

        private void btnOpcionTres_Click(object sender, EventArgs e)
        {
            btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            int posX = (Width - gbxEliminarPasajero.Width) / 2;
            int posY = (Height - gbxEliminarPasajero.Height) / 2;
            gbxEliminarPasajero.Location = new Point(posX, posY);
            gbxEliminarPasajero.Visible = true;
            gbxEliminarPasajero.Visible = true;
        }
        
        private void btnOpcionCuatro_Click_1(object sender, EventArgs e)
        {
            btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            int posX = (Width - gbxCrearPasajero.Width) / 2;
            int posY = (Height - gbxCrearPasajero.Height) / 2;
            gbxCrearPasajero.Location = new Point(posX, posY);
            gbxCrearPasajero.Visible = true;
        }

        #endregion

        #region ACCIONES CLICK BOTONES

        private void btnCrearAleatorio_Click(object sender, EventArgs e)
        {
            Random random = new Random();

         /*   for (int i = 0; i < 50; i++)
            {
                Pasajero pasajero = new Pasajero().GenerarPasajeroAleatorio(random);
                
                if (aerolinea.VerificarDniExistente(pasajero.dni) == false)
                {
                    aerolinea.agregarPasajero(pasajero);
                }
                else
                {
                    MessageBox.Show("El pasajero tiene un dni perteneciente a otro pasajero.");
                }
            }
            ActualizarListas();*/
        }
        
        private void btnCrearPasajero_Click(object sender, EventArgs e)
        {
          /*  string nombrePasajero = txtNombrePasajerotres.Text;
            string apellidoPasajero = txtApellidoPasajeroTres.Text;
            string dniPasajero = txtDniPasajeroTres.Text;

            if (int.TryParse(dniPasajero, out int dni) && Validador.ValidarCadena(nombrePasajero) && Validador.ValidarCadena(apellidoPasajero))
            {
                Pasajero pasajero = new Pasajero(dni, nombrePasajero, apellidoPasajero);

                if (!aerolinea.VerificarDniExistente(pasajero.dni))
                {
                    if(Validador.ValidarDNI(dni))
                    {
                        aerolinea.agregarPasajero(pasajero);
                        MessageBox.Show("El pasajero ha sido dado de alta.", "¡Felicitaciones!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarListas();
                    }
                    else
                    {
                        MessageBox.Show("El Dni no esta dentro del rango permitido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El pasajero tiene un dni perteneciente a otro pasajero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese valores válidos para el nombre, apellido y dni del pasajero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } */
        }        

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Pasajero pasajeroSeleccionado = (Pasajero)cmbxPasajeros.SelectedItem;

            if (pasajeroSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un pasajero para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool nombreActualizado = ActualizarNombre(pasajeroSeleccionado);
            bool apellidoActualizado = ActualizarApellido(pasajeroSeleccionado);
            bool dniActualizado = ActualizarDni(pasajeroSeleccionado);

            if(nombreActualizado == false ||  apellidoActualizado == false || dniActualizado == false)
            {
                return;
            }else
            {
                aerolinea.ReemplazarPasajeroSeleccionado(pasajeroSeleccionado);
                MessageBox.Show("Modificación Exitosa", "¡Felicitaciones!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarListas();
                LimpiarTextBoxes();
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
                MessageBox.Show("El pasajero ha sido eliminado.", "¡Felicitaciones!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarListas();
            }
            else
            {
                MessageBox.Show("No se encontró ningún pasajero con el nombre seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region VISIBILIDAD BOTONES
        
        private void btnCerrarDos_Click(object sender, EventArgs e)
        {
            gbxModificarPasajero.Visible = false;
            btnOpcionDos.Visible = true;
            btnOpcionTres.Visible = true;
            btnOpcionCuatro.Visible = true;
        }
        
        private void btnCerrarTres_Click(object sender, EventArgs e)
        {
            gbxEliminarPasajero.Visible = false;
            btnOpcionDos.Visible = true;
            btnOpcionTres.Visible = true;
            btnOpcionCuatro.Visible = true;
        }
        
        private void btnCerrarCuatro_Click(object sender, EventArgs e)
        {
            gbxCrearPasajero.Visible = false;
            btnOpcionDos.Visible = true;
            btnOpcionTres.Visible = true;
            btnOpcionCuatro.Visible = true;
        }

        #endregion
        
        #region ACTUALIZADORES
     
        private bool ActualizarNombre(Pasajero pasajero)
        {
            if (Validador.ValidarCadena(txtNombrePasajeroDos.Text))
            {
                pasajero.nombre = txtNombrePasajeroDos.Text;
                return true;
            }
            else
            {
                MessageBox.Show("Error al introducir el nombre.");
                return false;
            }
        }

        private bool ActualizarApellido(Pasajero pasajero)
        {
            if (Validador.ValidarCadena(txtApellidoDos.Text))
            {
                pasajero.apellido = txtApellidoDos.Text;
                return true;
            }
            else
            {
                MessageBox.Show("Error al introducir el apellido.");
                return false;
            }
        }

        private bool ActualizarDni(Pasajero pasajero)
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
