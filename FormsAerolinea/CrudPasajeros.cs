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
            lstPasajeros.Visible = false;
        }

        #region CONFIGURACION GROUPBOX

        private void cmbxPasajeros_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pasajero pasajeroSeleccionado = (Pasajero)cmbxPasajeros.SelectedItem;

            if (pasajeroSeleccionado != null)
            {
                cmbxGeneroDos.Text = pasajeroSeleccionado.Genero ? "Masculino" : "Femenino";
                txtNombreDos.Text = pasajeroSeleccionado.nombre;
                txtSegundoNombreDos.Text = pasajeroSeleccionado.segundoNombre;
                txtApellidoDos.Text = pasajeroSeleccionado.apellido;
                txtSegundoApellidoDos.Text = pasajeroSeleccionado.segundoApellido;
                txtDniDos.Text = pasajeroSeleccionado.dni.ToString();
            }
        }

        private void btnOpcionUno_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            gbxCrearPasajero.Location = new Point(665, 365);
            gbxCrearPasajero.Visible = true;
        }

        private void btnOpcionDos_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            gbxModificarPasajero.Location = new Point(665, 365);
            gbxModificarPasajero.Visible = true;
        }

        private void btnOpcionTres_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            gbxEliminarPasajero.Location = new Point(640, 375);
            gbxEliminarPasajero.Visible = true;
        }

        private void btnOpcionCuatro_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            lstPasajeros.Location = new Point(580, 365);
            lstPasajeros.Visible = true;
        }

        #endregion

        #region ACCIONES CLICK BOTONES

        private void btnCrearPasajero_Click(object sender, EventArgs e)
        {
            string nombrePasajero = txtNombre.Text;
            string segundoNombre = !string.IsNullOrEmpty(txtSegundoNombre.Text) ? txtSegundoNombre.Text : null;
            string apellidoPasajero = txtApellido.Text;
            string segundoApellido = !string.IsNullOrEmpty(txtSegundoApellido.Text) ? txtSegundoApellido.Text : null;
            string dniPasajero = txtDni.Text;
            bool genero = false; // por defecto se inicializa en femenino

            if (cmbxGenero.Text == "Masculino")
            {
                genero = true; // hombres
            }

            if (int.TryParse(dniPasajero, out int dni) &&
                Validador.ValidarCadena(nombrePasajero) && Validador.ValidarCadena(apellidoPasajero) &&
                (string.IsNullOrEmpty(segundoNombre) || Validador.ValidarCadena(segundoNombre)) &&
                (string.IsNullOrEmpty(segundoApellido) || Validador.ValidarCadena(segundoApellido)))
            {
                Pasajero pasajero = new Pasajero(dni, nombrePasajero, apellidoPasajero, genero, true, segundoNombre, segundoApellido, 0);

                if (!aerolinea.VerificarDniExistente(pasajero.dni))
                {
                    if (Validador.ValidarDNI(dni))
                    {
                        aerolinea.agregarPasajero(pasajero);
                        MessageBox.Show("El pasajero ha sido dado de alta.", "¡Felicitaciones!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarListas();
                    }
                    else
                    {
                        MessageBox.Show("El Dni no esta dentro del rango permitido (9000000 - 50000000).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El pasajero tiene un dni perteneciente a otro pasajero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese valores válidos para los datos del pasajero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Pasajero pasajeroSeleccionado = (Pasajero)cmbxPasajeros.SelectedItem;

            if (pasajeroSeleccionado == null)
            {
                MessageBox.Show("Por favor, seleccione un pasajero para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool modificado = ActualizarPasajero(pasajeroSeleccionado, txtNombreDos.Text, txtSegundoNombreDos.Text, txtApellidoDos.Text,
                txtSegundoApellidoDos.Text, txtDniDos.Text, cmbxGeneroDos.SelectedItem.ToString());

            if (modificado)
            {
                aerolinea.ReemplazarPasajeroSeleccionado(pasajeroSeleccionado);
                MessageBox.Show("El pasajero ha sido modificado correctamente.", "¡Felicitaciones!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTextBoxes();
                ActualizarListas();
            }
            else
            {
                MessageBox.Show("No se ha modificado ningún dato del pasajero.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string nombreAEliminar = cmbxPasajerosDos.Text; // Obtener el nombre de la combobox
            Pasajero pasajeroAEliminar = null; //buscar el pasajero con el nombre seleccionado en la cmbx

            foreach (Pasajero pasajero in aerolinea.listaPasajeros)
            {
                if (pasajero.NombreCompletoyDni == nombreAEliminar)
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

        private void btnCerrarUno_Click(object sender, EventArgs e)
        {
            gbxCrearPasajero.Visible = false;
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = true;
        }

        private void btnCerrarDos_Click(object sender, EventArgs e)
        {
            gbxModificarPasajero.Visible = false;
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = true;
        }

        private void btnCerrarTres_Click(object sender, EventArgs e)
        {
            gbxEliminarPasajero.Visible = false;
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = true;
        }

        private void btnCerrarCuatro_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region ACTUALIZADORES

        public bool ActualizarPasajero(Pasajero pasajeroSeleccionado, string nombre, string segundoNombre, string apellido, string segundoApellido, string dni, string genero)
        {
            bool modificado = false;

            if (ActualizarNombre(pasajeroSeleccionado, nombre) && ActualizarSegundoNombre(pasajeroSeleccionado, segundoNombre) &&
                ActualizarApellido(pasajeroSeleccionado, apellido) && ActualizarSegundoApellido(pasajeroSeleccionado, segundoApellido) &&
                ActualizarDni(pasajeroSeleccionado, dni) && ActualizarGenero(pasajeroSeleccionado, genero.ToString()))
            {
                modificado = true;
            }

            return modificado;
        }

        private bool ActualizarNombre(Pasajero pasajeroSeleccionado, string nuevoNombre)
        {
            if (!string.IsNullOrEmpty(nuevoNombre) && Validador.ValidarCadena(nuevoNombre, false))
            {
                pasajeroSeleccionado.nombre = nuevoNombre;
                return true;
            }

            return false;
        }

        private bool ActualizarSegundoNombre(Pasajero pasajeroSeleccionado, string nuevoSegundoNombre)
        {
            if (string.IsNullOrEmpty(nuevoSegundoNombre))
            {
                pasajeroSeleccionado.segundoNombre = null;
                return true;
            }
            else if (Validador.ValidarCadena(nuevoSegundoNombre, false))
            {
                pasajeroSeleccionado.segundoNombre = nuevoSegundoNombre;
                return true;
            }
            return false;
        }

        private bool ActualizarApellido(Pasajero pasajeroSeleccionado, string nuevoApellido)
        {
            if (!string.IsNullOrEmpty(nuevoApellido) && Validador.ValidarCadena(nuevoApellido))
            {
                pasajeroSeleccionado.apellido = nuevoApellido;
                return true;
            }

            return false;
        }

        private bool ActualizarSegundoApellido(Pasajero pasajeroSeleccionado, string nuevoSegundoApellido)
        {
            if (string.IsNullOrEmpty(nuevoSegundoApellido))
            {
                pasajeroSeleccionado.segundoApellido = null;
                return true;
            }
            else if (Validador.ValidarCadena(nuevoSegundoApellido))
            {
                pasajeroSeleccionado.segundoApellido = nuevoSegundoApellido;
                return true;
            }
            return false;
        }

        private bool ActualizarDni(Pasajero pasajeroSeleccionado, string nuevoDni)
        {
            if (!string.IsNullOrEmpty(nuevoDni) && int.TryParse(nuevoDni, out int dni) && Validador.ValidarDNI(dni))
            {
                pasajeroSeleccionado.dni = dni;
                return true;
            }

            return false;
        }

        private bool ActualizarGenero(Pasajero pasajeroSeleccionado, string nuevoGenero)
        {
            if (!string.IsNullOrEmpty(nuevoGenero))
            {
                pasajeroSeleccionado.Genero = nuevoGenero == "Masculino";
                return true;
            }

            return false;
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

            cmbxGenero.DataSource = null;
            if (cmbxGenero.Items.Count == 0)
            {
                cmbxGenero.Items.Add("Masculino");
                cmbxGenero.Items.Add("Femenino");
            }
            cmbxGenero.Refresh();

            cmbxGeneroDos.DataSource = null;
            if (cmbxGeneroDos.Items.Count == 0)
            {
                cmbxGeneroDos.Items.Add("Masculino");
                cmbxGeneroDos.Items.Add("Femenino");
            }
            cmbxGeneroDos.Refresh();
        }

        private void LimpiarTextBoxes()
        {
            txtNombreDos.Text = "";
            txtSegundoNombreDos.Text = "";
            txtApellidoDos.Text = "";
            txtSegundoApellidoDos.Text = "";
            txtDniDos.Text = "";
            cmbxGeneroDos.Text = "";
        }

        private void gbxModificarPasajero_VisibleChanged(object sender, EventArgs e)
        {
            if (gbxModificarPasajero.Visible)
            {
                ActualizarListas();
            }
        }

        #endregion
    }
}
