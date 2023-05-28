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
            ConfigurarDgvYgroupBox();            
        }

        #region CONFIGURACION GROUPBOX

        /// <summary>
        /// Evento que se activa cuando se selecciona un elemento en el ComboBox de pasajeros.
        /// Muestra la información del pasajero seleccionado en los campos correspondientes.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void cmbxPasajeros_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Pasajero pasajeroSeleccionado = (Pasajero)cmbxPasajeros.SelectedItem;

            if (pasajeroSeleccionado != null)
            {
                cmbxGeneroDos.Text = pasajeroSeleccionado.Genero ? "Masculino" : "Femenino";
                txtNombreDos.Text = pasajeroSeleccionado.Nombre;
                txtSegundoNombreDos.Text = pasajeroSeleccionado.SegundoNombre;
                txtApellidoDos.Text = pasajeroSeleccionado.Apellido;
                txtSegundoApellidoDos.Text = pasajeroSeleccionado.SegundoApellido;
                txtDniDos.Text = pasajeroSeleccionado.Dni.ToString();
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
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvPasajeros.Visible = false;
            gbxCrearPasajero.Left = (this.ClientSize.Width - gbxCrearPasajero.Width) / 2;
            gbxCrearPasajero.Top = ((this.ClientSize.Height - gbxCrearPasajero.Height) / 2) - 90;
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
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvPasajeros.Visible = false;
            gbxModificarPasajero.Left = (this.ClientSize.Width - gbxModificarPasajero.Width) / 2;
            gbxModificarPasajero.Top = ((this.ClientSize.Height - gbxModificarPasajero.Height) / 2) - 90;
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
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvPasajeros.Visible = false;
            gbxEliminarPasajero.Left = (this.ClientSize.Width - gbxEliminarPasajero.Width) / 2;
            gbxEliminarPasajero.Top = ((this.ClientSize.Height - gbxEliminarPasajero.Height) / 2) - 90;
            gbxEliminarPasajero.Visible = true;
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

                if (!aerolinea.VerificarDniExistente(pasajero.Dni))
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
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvPasajeros.Visible = true;
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
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvPasajeros.Visible = true;
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
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvPasajeros.Visible = true;
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
        private bool ActualizarPasajero(Pasajero pasajeroSeleccionado, string nombre, string segundoNombre, string apellido, string segundoApellido, string dni, string genero)
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
                pasajeroSeleccionado.Nombre = nuevoNombre;
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
                pasajeroSeleccionado.SegundoNombre = null;
                return true;
            }
            else if (Validador.ValidarCadena(nuevoSegundoNombre, false))
            {
                pasajeroSeleccionado.SegundoNombre = nuevoSegundoNombre;
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
                pasajeroSeleccionado.Apellido = nuevoApellido;
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
                pasajeroSeleccionado.SegundoApellido = null;
                return true;
            }
            else if (Validador.ValidarCadena(nuevoSegundoApellido))
            {
                pasajeroSeleccionado.SegundoApellido = nuevoSegundoApellido;
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
            int.TryParse(nuevoDni, out int dni);

            if (!string.IsNullOrEmpty(nuevoDni) && Validador.ValidarDNI(dni) && aerolinea.VerificarDniExistente(dni) == false)
            {
                pasajeroSeleccionado.Dni = dni;
                return true;
            }

            if(aerolinea.VerificarDniExistente(dni))
            {
                MessageBox.Show("El DNI ingresado pertenece a otro pasajero existente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cmbxPasajeros.DataSource = cmbxPasajerosDos.DataSource = cmbxGenero.DataSource = cmbxGeneroDos.DataSource = null;
            cmbxPasajeros.DataSource = cmbxPasajerosDos.DataSource = aerolinea.listaPasajeros;
            cmbxPasajeros.DisplayMember = cmbxPasajerosDos.DisplayMember = "NombreCompletoYdni";
            cmbxPasajeros.Refresh();
            cmbxPasajerosDos.Refresh();

            if (cmbxGenero.Items.Count == 0 && cmbxGeneroDos.Items.Count == 0)
            {
                cmbxGenero.Items.Add("Masculino");
                cmbxGenero.Items.Add("Femenino");
                cmbxGeneroDos.Items.Add("Masculino");
                cmbxGeneroDos.Items.Add("Femenino");
            }
            cmbxGenero.Refresh();
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
        /// Configura los controles de la interfaz de usuario para mostrar la información de los pasajeros de una aerolínea en un DataGridView.
        /// </summary>
        private void ConfigurarDgvYgroupBox()
        {
            gbxCrearPasajero.Visible = false;
            gbxModificarPasajero.Visible = false;
            gbxEliminarPasajero.Visible = false;
            dgvPasajeros.Visible = true;

            dgvPasajeros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPasajeros.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvPasajeros.Columns.Clear(); // Limpiar las columnas existentes
            dgvPasajeros.DataSource = aerolinea.listaPasajeros;

            // Mostrar solo los atributos en el DataGridView
            dgvPasajeros.DataSource = aerolinea.listaPasajeros.Select(pasajero => new
            {
              Nombre = pasajero.NombreCompletoyDni, pasajero.Estado, pasajero.TipoPasajero, pasajero.PesoEquipaje
            }).ToList();

            dgvPasajeros.Refresh();
            // Centrar el DataGridView en la pantalla
            dgvPasajeros.Left = (this.ClientSize.Width - dgvPasajeros.Width) / 2;
            dgvPasajeros.Top = ((this.ClientSize.Height - dgvPasajeros.Height) / 2) + 40;
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

        /// <summary>
        /// Evento de formato de celda del control DataGridView llamado "dgvPasajeros".
        /// Este evento se desencadena cuando una celda del control se está formateando visualmente.
        /// Cambia el color de fondo de todas las celdas a negro y el color de fuente a blanco.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPasajeros_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvPasajeros.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Cambiar el color de fondo
                    cell.Style.BackColor = Color.Black;

                    // Cambiar el color de la fuente
                    cell.Style.ForeColor = Color.White;
                }
            }
        }

        #endregion
    }
}
