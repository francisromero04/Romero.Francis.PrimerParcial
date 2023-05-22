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
    /// <summary>
    /// Formulario para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) de pasajeros.
    /// </summary>
    public partial class CrudPasajeros : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        /// <summary>
        /// Inicializa una nueva instancia de la clase CrudPasajeros.
        /// </summary>
        /// <param name="usuario">La persona que está utilizando el formulario.</param>
        /// <param name="aerolinea">La aerolínea asociada a los pasajeros.</param>
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

        /// <summary>
        /// Evento que se activa cuando se selecciona un elemento en el ComboBox de pasajeros.
        /// Muestra la información del pasajero seleccionado en los campos correspondientes.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
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

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Opción Uno".
        /// Oculta los demás botones y muestra el grupo de crear pasajero.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnOpcionUno_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            gbxCrearPasajero.Location = new Point(665, 365);
            gbxCrearPasajero.Visible = true;
        }

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Opción Dos".
        /// Oculta los demás botones y muestra el grupo de modificar pasajero.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnOpcionDos_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            gbxModificarPasajero.Location = new Point(665, 365);
            gbxModificarPasajero.Visible = true;
        }

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Opción Tres".
        /// Oculta los demás botones y muestra el grupo de eliminar pasajero.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnOpcionTres_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            gbxEliminarPasajero.Location = new Point(640, 375);
            gbxEliminarPasajero.Visible = true;
        }

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Opción Cuatro".
        /// Oculta los demás botones y muestra la lista de pasajeros.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnOpcionCuatro_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            lstPasajeros.Location = new Point(580, 365);
            lstPasajeros.Visible = true;
        }

        #endregion

        #region ACCIONES CLICK BOTONES

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Crear Pasajero".
        /// Crea un nuevo pasajero con los datos ingresados y lo agrega a la aerolínea.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
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

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Modificar".
        /// Actualiza la información del pasajero seleccionado con los nuevos datos ingresados.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
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

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Eliminar".
        /// Elimina el pasajero seleccionado de la lista de pasajeros de la aerolínea.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
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

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Cerrar" en la sección de creación de pasajero.
        /// Oculta el grupo de creación de pasajero y muestra nuevamente las opciones disponibles.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnCerrarUno_Click(object sender, EventArgs e)
        {
            gbxCrearPasajero.Visible = false;
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = true;
        }

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Cerrar" en la sección de modificación de pasajero.
        /// Oculta el grupo de modificación de pasajero y muestra nuevamente las opciones disponibles.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnCerrarDos_Click(object sender, EventArgs e)
        {
            gbxModificarPasajero.Visible = false;
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = true;
        }

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Cerrar" en la sección de eliminación de pasajero.
        /// Oculta el grupo de eliminación de pasajero y muestra nuevamente las opciones disponibles.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnCerrarTres_Click(object sender, EventArgs e)
        {
            gbxEliminarPasajero.Visible = false;
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = true;
        }

        #endregion

        #region ACTUALIZADORES

        /// <summary>
        /// Actualiza los datos de un pasajero seleccionado con los nuevos valores proporcionados.
        /// </summary>
        /// <param name="pasajeroSeleccionado">El pasajero seleccionado que se va a actualizar.</param>
        /// <param name="nombre">El nuevo nombre del pasajero.</param>
        /// <param name="segundoNombre">El nuevo segundo nombre del pasajero.</param>
        /// <param name="apellido">El nuevo apellido del pasajero.</param>
        /// <param name="segundoApellido">El nuevo segundo apellido del pasajero.</param>
        /// <param name="dni">El nuevo DNI del pasajero.</param>
        /// <param name="genero">El nuevo género del pasajero.</param>
        /// <returns>Devuelve un valor booleano que indica si se ha modificado correctamente el pasaje
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

        /// <summary>
        /// Actualiza el nombre de un pasajero seleccionado con el nuevo valor proporcionado.
        /// </summary>
        /// <param name="pasajeroSeleccionado">El pasajero seleccionado que se va a actualizar.</param>
        /// <param name="nuevoNombre">El nuevo nombre del pasajero.</param>
        /// <returns>Devuelve un valor booleano que indica si se ha actualizado correctamente el nombre del pasajero.</returns>
        private bool ActualizarNombre(Pasajero pasajeroSeleccionado, string nuevoNombre)
        {
            if (!string.IsNullOrEmpty(nuevoNombre) && Validador.ValidarCadena(nuevoNombre, false))
            {
                pasajeroSeleccionado.nombre = nuevoNombre;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Actualiza el segundo nombre de un pasajero seleccionado con el nuevo valor proporcionado.
        /// </summary>
        /// <param name="pasajeroSeleccionado">El pasajero seleccionado que se va a actualizar.</param>
        /// <param name="nuevoSegundoNombre">El nuevo segundo nombre del pasajero.</param>
        /// <returns>Devuelve un valor booleano que indica si se ha actualizado correctamente el segundo nombre del pasajero.</returns>
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

        /// <summary>
        /// Actualiza el apellido de un pasajero seleccionado con el nuevo valor proporcionado.
        /// </summary>
        /// <param name="pasajeroSeleccionado">El pasajero seleccionado que se va a actualizar.</param>
        /// <param name="nuevoApellido">El nuevo apellido del pasajero.</param>
        /// <returns>Devuelve un valor booleano que indica si se ha actualizado correctamente el apellido del pasajero.</returns>
        private bool ActualizarApellido(Pasajero pasajeroSeleccionado, string nuevoApellido)
        {
            if (!string.IsNullOrEmpty(nuevoApellido) && Validador.ValidarCadena(nuevoApellido))
            {
                pasajeroSeleccionado.apellido = nuevoApellido;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Actualiza el segundo apellido de un pasajero seleccionado con el nuevo valor proporcionado.
        /// </summary>
        /// <param name="pasajeroSeleccionado">El pasajero seleccionado que se va a actualizar.</param>
        /// <param name="nuevoSegundoApellido">El nuevo segundo apellido del pasajero.</param>
        /// <returns>Devuelve un valor booleano que indica si se ha actualizado correctamente el segundo apellido del pasajero.</returns>
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

        /// <summary>
        /// Actualiza el DNI de un pasajero seleccionado con el nuevo valor proporcionado.
        /// </summary>
        /// <param name="pasajeroSeleccionado">El pasajero seleccionado que se va a actualizar.</param>
        /// <param name="nuevoDni">El nuevo DNI del pasajero.</param>
        /// <returns>Devuelve un valor booleano que indica si se ha actualizado correctamente el DNI del pasajero.</returns>
        private bool ActualizarDni(Pasajero pasajeroSeleccionado, string nuevoDni)
        {
            if (!string.IsNullOrEmpty(nuevoDni) && int.TryParse(nuevoDni, out int dni) && Validador.ValidarDNI(dni))
            {
                pasajeroSeleccionado.dni = dni;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Actualiza el género de un pasajero seleccionado con el nuevo valor proporcionado.
        /// </summary>
        /// <param name="pasajeroSeleccionado">El pasajero seleccionado que se va a actualizar.</param>
        /// <param name="nuevoGenero">El nuevo género del pasajero.</param>
        /// <returns>Devuelve un valor booleano que indica si se ha actualizado correctamente el género
        private bool ActualizarGenero(Pasajero pasajeroSeleccionado, string nuevoGenero)
        {
            if (!string.IsNullOrEmpty(nuevoGenero))
            {
                pasajeroSeleccionado.Genero = nuevoGenero == "Masculino";
                return true;
            }

            return false;
        }

        /// <summary>
        /// Actualiza las listas de visualización de pasajeros y género en la interfaz.
        /// </summary>
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

        /// <summary>
        /// Limpia los campos de texto de la sección de modificación de pasajero en la interfaz.
        /// </summary>
        private void LimpiarTextBoxes()
        {
            txtNombreDos.Text = "";
            txtSegundoNombreDos.Text = "";
            txtApellidoDos.Text = "";
            txtSegundoApellidoDos.Text = "";
            txtDniDos.Text = "";
            cmbxGeneroDos.Text = "";
        }

        /// <summary>
        /// Maneja el evento de cambio de visibilidad del grupo de modificación de pasajero en la interfaz.
        /// Actualiza las listas de visualización cuando el grupo se vuelve visible.
        /// </summary>
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
