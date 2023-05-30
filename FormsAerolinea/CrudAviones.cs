using BibliotecaAerolineasCompleto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FormsAerolinea
{
    /// <summary>
    /// Formulario para realizar operaciones de CRUD (Crear, Leer, Actualizar, Eliminar) en aviones.
    /// </summary>
    public partial class CrudAviones : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        /// <summary>
        /// Inicializa una nueva instancia de la clase CrudAviones.
        /// </summary>
        /// <param name="usuario">El objeto Persona que representa al usuario actual.</param>
        /// <param name="aerolinea">El objeto Aerolinea con el que se trabajará.</param>
        public CrudAviones(Persona usuario, Aerolinea aerolinea)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            ActualizarListas();
            EstablecerLocacion();
            ConfigurarDgvYgroupBox();
        }

        #region CONFIGURACION GROUPBOX

        /// <summary>
        /// Evento que se activa cuando se selecciona un elemento en el ComboBox de aviones.
        /// Actualiza los valores de los controles de texto y casillas de verificación en función del avión seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void cmbxAviones_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el objeto avión seleccionado en el ComboBox
            Avion avionSeleccionado = (Avion)cmbxAviones.SelectedItem;

            // Obtener los valores que deseas mostrar en los TextBoxes y CheckBoxes
            if (avionSeleccionado != null)
            {
                txtMatricula.Text = avionSeleccionado.Matricula;
                txtCantAsientos.Text = avionSeleccionado.CantidadAsientos.ToString();
                txtCantBaños.Text = avionSeleccionado.CantidadBanos.ToString();
                txtBodega.Text = avionSeleccionado.CapacidadBodega.ToString();
                chkComida.Checked = avionSeleccionado.OfreceComida;
                chkWifi.Checked = avionSeleccionado.ServicioInternet;
            }
        }

        /// <summary>
        /// Evento que se activa al hacer clic en el botón "Opción Uno".
        /// Oculta los botones de opción y muestra el grupo de controles para crear un avión.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnOpcionUno_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvAviones.Visible = false;
            gbxCrearAvion.Left = (this.ClientSize.Width - gbxCrearAvion.Width) / 2;
            gbxCrearAvion.Top = ((this.ClientSize.Height - gbxCrearAvion.Height) / 2) - 90;
            gbxCrearAvion.Visible = true;
        }

        /// <summary>
        /// Evento que se activa al hacer clic en el botón "Opción Dos".
        /// Oculta los botones de opción y muestra el grupo de controles para modificar un avión.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnOpcionDos_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvAviones.Visible = false;
            gbxModificarAeronave.Left = (this.ClientSize.Width - gbxModificarAeronave.Width) / 2;
            gbxModificarAeronave.Top = ((this.ClientSize.Height - gbxModificarAeronave.Height) / 2) - 90;
            gbxModificarAeronave.Visible = true;
        }

        /// <summary>
        /// Evento que se activa al hacer clic en el botón "Opción Tres".
        /// Oculta los botones de opción y muestra el grupo de controles para eliminar un avión.
        /// </summary>
        /// <param name="sender">El objeto que genera el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnOpcionTres_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvAviones.Visible = false;
            gbxEliminarAeronave.Left = (this.ClientSize.Width - gbxEliminarAeronave.Width) / 2;
            gbxEliminarAeronave.Top = ((this.ClientSize.Height - gbxEliminarAeronave.Height) / 2) - 90;
            gbxEliminarAeronave.Visible = true;
        }

        #endregion

        #region ACCIONES CLICK BOTONES

        /// <summary>
        /// Maneja el evento de click en el botón "Crear Avión".
        /// Crea un nuevo objeto Avion con los valores ingresados en los TextBox del formulario y lo agrega a la lista de Aviones de la aerolínea.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnCrearAvion_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los TextBox del formulario
            string matricula = txtMatriculaDos.Text;
            int cantAsientos, cantBanos, capacidadBodega;

            if (!int.TryParse(txtCantAsientosDos.Text, out cantAsientos))
            {
                MessageBox.Show("La cantidad de asientos ingresada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtCantBañosDos.Text, out cantBanos))
            {
                MessageBox.Show("La cantidad de baños ingresada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtBodegaDos.Text, out capacidadBodega))
            {
                MessageBox.Show("La capacidad de bodega ingresada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool servicioInternet = chbWifi.Checked;
            bool ofreceComida = chbComida.Checked;

            // Validar la matrícula
            if (!Validador.ValidarMatricula(matricula))
            {
                MessageBox.Show("La matrícula ingresada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (aerolinea.VerificarMatriculaExistente(matricula) == true)
            {
                MessageBox.Show("La matrícula ingresada ya pertenece a un avion existente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar los números ingresados
            if (!Validador.ValidarNumeroPositivo(cantAsientos) || !Validador.ValidarNumeroPositivo(cantBanos) || !Validador.ValidarNumeroPositivo(capacidadBodega))
            {
                MessageBox.Show("Los números ingresados deben ser positivos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un nuevo objeto Avion utilizando el constructor
            Avion nuevoAvion = new Avion(matricula, cantAsientos, cantBanos, servicioInternet, ofreceComida, capacidadBodega, 0, false);
            // Agregar el nuevo Avion a la lista de Avion de la aerolínea
            aerolinea.agregarAvion(nuevoAvion);
            // Mostrar un mensaje de éxito
            MessageBox.Show("El avión ha sido dado de alta correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActualizarListas();
        }
        
        /// <summary>
        /// Maneja el evento de click en el botón "Modificar".
        /// Actualiza los valores del Avión seleccionado en el ComboBox utilizando los datos ingresados en los controles del formulario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Obtener el objeto avión seleccionado en el ComboBox
            Avion avionSeleccionado = cmbxAviones.SelectedItem as Avion;

            // Actualizar los valores del avión seleccionado
            bool datosValidos = ActualizarMatricula(avionSeleccionado)
                              & ActualizarCantidadAsientos(avionSeleccionado)
                              & ActualizarCantidadBanos(avionSeleccionado)
                              & ActualizarCapacidadBodega(avionSeleccionado)
                              & ActualizarOfreceComida(avionSeleccionado)
                              & ActualizarServicioInternet(avionSeleccionado);

            // Si todos los datos son válidos, actualizar el objeto avión seleccionado
            if (datosValidos)
            {
                ActualizarListas();
                LimpiarTextBoxes();
                MessageBox.Show("Modificación exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Maneja el evento de click en el botón "Eliminar".
        /// Elimina el Avión seleccionado en el ComboBox de la lista de avines.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtener la matrícula seleccionada en el ComboBox y limpiar espacios en blanco
            string matriculaAEliminar = cmbxAvionesDos.Text;
            // Buscar el avión a eliminar por su matrícula
            Avion avionAEliminar = null;

            foreach (Avion avion in aerolinea.ListaAviones)
            {
                if (avion.Matricula == matriculaAEliminar)
                {
                    avionAEliminar = avion;
                    break;
                }
            }

            // Si no se encuentra el avión, mostrar mensaje de error y salir del método
            if (avionAEliminar == null)
            {
                MessageBox.Show("No se encontró ningún avión con la matrícula seleccionada.");
                return;
            }

            // Eliminar el avión de la lista y actualizar el ComboBox
            aerolinea.eliminarAvion(avionAEliminar);
            cmbxAvionesDos.Items.Remove(matriculaAEliminar);
            MessageBox.Show("El avión ha sido eliminado.");
            ActualizarListas();
        }

        #endregion

        #region VISIBILIDAD BOTONES

        /// <summary>
        /// Maneja el evento de clic del botón "btnCerrarUno".
        /// Oculta el grupo de controles "gbxCrearAvion" y muestra los botones "btnOpcionUno", "btnOpcionDos", "btnOpcionTres" y el control "dgvAviones".
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento EventArgs.</param>
        private void btnCerrarUno_Click(object sender, EventArgs e)
        {
            gbxCrearAvion.Visible = false;
            ConfigurarDgvYgroupBox();
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvAviones.Visible = true;
        }

        /// <summary>
        /// Maneja el evento de clic del botón "btnCerrarDos".
        /// Oculta el grupo de controles "gbxModificarAeronave" y muestra los botones "btnOpcionUno", "btnOpcionDos", "btnOpcionTres" y el control "dgvAviones".
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento EventArgs.</param>
        private void btnCerrarDos_Click(object sender, EventArgs e)
        {
            gbxModificarAeronave.Visible = false;
            ConfigurarDgvYgroupBox();
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvAviones.Visible = true;
        }

        /// <summary>
        /// Maneja el evento de clic del botón "btnCerrarTres".
        /// Oculta el grupo de controles "gbxEliminarAeronave" y muestra los botones "btnOpcionUno", "btnOpcionDos", "btnOpcionTres" y el control "dgvAviones".
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento EventArgs.</param>
        private void btnCerrarTres_Click(object sender, EventArgs e)
        {
            gbxEliminarAeronave.Visible = false;
            ConfigurarDgvYgroupBox();
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvAviones.Visible = true;
        }

        #endregion

        #region ACTUALIZADORES

        /// <summary>
        /// Actualiza la matrícula de un avión.
        /// </summary>
        /// <param name="avion">El objeto Avion que se actualizará.</param>
        /// <returns>Devuelve true si la matrícula se actualizó correctamente, de lo contrario devuelve false.</returns>
        private bool ActualizarMatricula(Avion avion)
        {
            if (Validador.ValidarMatricula(txtMatricula.Text))
            {
                avion.Matricula = txtMatricula.Text;
                return true;
            }
            else
            {
                MessageBox.Show("Error al introducir la matricula.");
                return false;
            }
        }

        /// <summary>
        /// Actualiza la cantidad de asientos de un avión.
        /// </summary>
        /// <param name="avion">El objeto Avion que se actualizará.</param>
        /// <returns>Devuelve true si la cantidad de asientos se actualizó correctamente, de lo contrario devuelve false.</returns>
        private bool ActualizarCantidadAsientos(Avion avion)
        {
            int cantidadAsientos;

            if (int.TryParse(txtCantAsientos.Text, out cantidadAsientos) && Validador.ValidarNumeroPositivo(cantidadAsientos))
            {
                avion.CantidadAsientos = cantidadAsientos;
                return true;
            }
            else
            {
                MessageBox.Show("Error al introducir la cantidad de asientos.");
                return false;
            }
        }

        /// <summary>
        /// Actualiza la cantidad de baños de un avión.
        /// </summary>
        /// <param name="avion">El objeto Avion que se actualizará.</param>
        /// <returns>Devuelve true si la cantidad de baños se actualizó correctamente, de lo contrario devuelve false.</returns>
        private bool ActualizarCantidadBanos(Avion avion)
        {
            int cantidadBanos;

            if (int.TryParse(txtCantBaños.Text, out cantidadBanos) && Validador.ValidarNumeroPositivo(cantidadBanos))
            {
                avion.CantidadBanos = cantidadBanos;
                return true;
            }
            else
            {
                MessageBox.Show("Error al introducir la cantidad de baños.");
                return false;
            }
        }

        /// <summary>
        /// Actualiza la capacidad de la bodega de un avión.
        /// </summary>
        /// <param name="avion">El objeto Avion que se actualizará.</param>
        /// <returns>Devuelve true si la capacidad de la bodega se actualizó correctamente, de lo contrario devuelve false.</returns>
        private bool ActualizarCapacidadBodega(Avion avion)
        {
            decimal capacidadBodega;


            if (decimal.TryParse(txtBodega.Text, out capacidadBodega) && Validador.ValidarNumeroPositivo((int)capacidadBodega))
            {
                avion.CapacidadBodega = capacidadBodega;
                return true;
            }
            else if (capacidadBodega == avion.CapacidadBodega)
            {
                avion.CapacidadBodega = capacidadBodega;
                return true;
            }
            else
            {
                MessageBox.Show("Error al introducir la capacidad de la bodega.");
                return false;
            }
        }

        /// <summary>
        /// Actualiza el estado de ofrecer comida de un avión.
        /// </summary>
        /// <param name="avion">El objeto Avion que se actualizará.</param>
        /// <returns>Devuelve true si ofrece comida.</returns>
        private bool ActualizarOfreceComida(Avion avion)
        {
            avion.OfreceComida = chkComida.Checked;
            return true;
        }

        /// <summary>
        /// Actualiza el estado del servicio de internet de un avión.
        /// </summary>
        /// <param name="avion">El objeto Avion que se actualizará.</param>
        /// <returns>Devuelve true.</returns>
        private bool ActualizarServicioInternet(Avion avion)
        {
            avion.ServicioInternet = chkWifi.Checked;
            return true;
        }

        /// <summary>
        /// Limpia los TextBoxes estableciendo su texto como vacío.
        /// </summary>
        private void LimpiarTextBoxes()
        {
            txtMatricula.Text = "";
            txtBodega.Text = "";
            txtCantAsientos.Text = "";
            txtCantBaños.Text = "";
        }

        /// <summary>
        /// Actualiza las listas de aeronaves y ComboBoxes.
        /// </summary>
        private void ActualizarListas()
        {
            cmbxAviones.DataSource = null;
            List<Avion> avionesDisponibles = new List<Avion>();

            foreach (Avion avion in aerolinea.ListaAviones)
            {
                if (!avion.OcupadoEnVuelo)
                {
                    avionesDisponibles.Add(avion);
                }
            }

            cmbxAviones.DataSource = avionesDisponibles;
            cmbxAviones.DisplayMember = nameof(Avion.ToString);

            cmbxAvionesDos.DataSource = null;
            cmbxAvionesDos.DataSource = avionesDisponibles;
            cmbxAvionesDos.DisplayMember = nameof(Avion.ToString);

            chkComida.Checked = false;
            chkWifi.Checked = false;

            cmbxAviones.Refresh();
            cmbxAvionesDos.Refresh();
        }

        /// <summary>
        /// Configura la locacion del DataGridView.
        /// </summary>
        private void EstablecerLocacion()
        {
            // Centrar el DataGridView en la pantalla
            dgvAviones.Left = (this.ClientSize.Width - dgvAviones.Width) / 2;
            dgvAviones.Top = ((this.ClientSize.Height - dgvAviones.Height) / 2) + 40;
        }

        /// <summary>
        /// Configura los controles de la interfaz de usuario para mostrar la información de los aviones de una aerolínea en un DataGridView.
        /// </summary>
        private void ConfigurarDgvYgroupBox()
        {
            dgvAviones.Visible = true;

            dgvAviones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAviones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvAviones.Columns.Clear(); // Limpiar las columnas existentes
            dgvAviones.DataSource = aerolinea.ListaAviones;

            // Mostrar solo los atributos en el DataGridView
            dgvAviones.DataSource = aerolinea.ListaAviones.Select(avion => new
            {
                avion.Matricula,
                avion.CantidadAsientos,
                avion.CantidadBanos,
                avion.ServicioInternet,
                avion.OfreceComida,
                avion.CapacidadBodega,
                avion.OcupadoEnVuelo,
                avion.HorasVueloHistoricas,
            }).ToList();

            dgvAviones.Refresh();           
        }

        /// <summary>
        /// Evento de formato de celda del control DataGridView llamado "dgvAviones".
        /// Este evento se desencadena cuando una celda del control se está formateando visualmente.
        /// Cambia el color de fondo de todas las celdas a negro y el color de fuente a blanco.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAviones_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgvAviones.Rows)
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
