using BibliotecaAerolineasCompleto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsAerolinea
{
    /// <summary>
    /// Formulario para realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) de viajes.
    /// </summary>
    public partial class CrudViajes : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        /// <summary>
        /// Inicializa una nueva instancia de la clase CrudViajes.
        /// </summary>
        /// <param name="usuario">El objeto Persona que representa al usuario actual.</param>
        /// <param name="aerolinea">El objeto Aerolinea que representa la aerolínea asociada.</param>
        public CrudViajes(Persona usuario, Aerolinea aerolinea)
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
        /// Maneja el evento click del botón btnOpcionUno.
        /// Muestra el grupo de controles gbxCrearViajes y oculta otros elementos de la interfaz de usuario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnOpcionUno_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvVuelos.Visible = false;
            gbxCrearViajes.Left = (this.ClientSize.Width - gbxCrearViajes.Width) / 2;
            gbxCrearViajes.Top = ((this.ClientSize.Height - gbxCrearViajes.Height) / 2) - 120;
            gbxCrearViajes.Visible = true;
        }

        /// <summary>
        /// Maneja el evento click del botón btnOpcionDos.
        /// Muestra el grupo de controles gbxModificarViaje y oculta otros elementos de la interfaz de usuario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnOpcionDos_Click(object sender, EventArgs e)
         {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvVuelos.Visible = false;
            gbxModificarViaje.Left = (this.ClientSize.Width - gbxModificarViaje.Width) / 2;
            gbxModificarViaje.Top = ((this.ClientSize.Height - gbxModificarViaje.Height) / 2) - 90;
            gbxModificarViaje.Visible = true;
        }

        /// <summary>
        /// Maneja el evento click del botón btnOpcionTres.
        /// Muestra el grupo de controles gbxEliminarViaje y oculta otros elementos de la interfaz de usuario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnOpcionTres_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvVuelos.Visible = false;
            gbxEliminarViaje.Left = (this.ClientSize.Width - gbxEliminarViaje.Width) / 2;
            gbxEliminarViaje.Top = ((this.ClientSize.Height - gbxEliminarViaje.Height) / 2) - 90;
            gbxEliminarViaje.Visible = true;
        }

        #endregion

        #region ACCIONES CLICK BOTONES

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Crear Vuelo".
        /// Crea un nuevo vuelo con los datos ingresados y lo agrega a la aerolínea.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnCrearVuelo_Click(object sender, EventArgs e)
        {
            // Verificar si la lista de aviones tiene al menos un avión
            if (aerolinea.ListaAviones.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un avión antes de crear un vuelo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CamposCompletosValidos(cmbxOrigen.Text, cmbxDestino.Text, txtCostoTurista.Text))
            {
                return;
            }

            if (!decimal.TryParse(txtCostoTurista.Text, out decimal costoTurista) ||
                !PrecioValido(costoTurista))
            {
                return;
            }

            decimal porcentajeCostoPremium = CalcularPorcentajeCostoTurista(costoTurista);
            decimal costoPremium = costoTurista * porcentajeCostoPremium;
            txtCostoPremium.Text = costoPremium.ToString();
            txtCostoPremium.ReadOnly = true;

            Avion avionSeleccionado = (Avion)cmbxMatriculaAviones.SelectedItem;
            int limiteAsientos = avionSeleccionado.CantidadAsientos;

            // Validar que la cantidad de asientos sea un número válido
            if (!int.TryParse(txtAsientosTuristas.Text, out int asientosTurista) || !AsientosValidos(asientosTurista, limiteAsientos))
            {
                return;
            }

            // Calcular el 20% de los asientos turistas
            decimal veintePorcientoTuristas = CalcularVeintePorcientoAsientosTuristas(asientosTurista);
            // Asignar el valor del 20% a los asientos premium
            int asientosPremium = (int)veintePorcientoTuristas;
            // Cargar el valor en el TextBox txtAsientosPremium y establecerlo como solo lectura
            txtAsientosPremium.Text = asientosPremium.ToString();
            txtAsientosPremium.ReadOnly = true;

            DateTime fechaVuelo = dtpFechaVuelo.Value;
            DateTime soloFecha = fechaVuelo.Date;

            if (!ValidarFechaSeleccionada(fechaVuelo, false))
            {
                return;
            }

            // Verificar si el avión seleccionado ya ha sido utilizado en otro vuelo
            foreach (Vuelo vuelo in aerolinea.ListaVuelos)
            {
                if (vuelo.Avion.Equals(avionSeleccionado) && vuelo.FechaVuelo > soloFecha && vuelo.FechaVuelo == soloFecha)
                {
                    MessageBox.Show("El avión seleccionado ya ha sido utilizado en otro vuelo. Por favor, seleccione otro avión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }   
                else
                {
                    continue;
                }
            }

            // Obtener los valores de los campos del formulario
            string ciudadPartida = cmbxOrigen.Text;
            string ciudadDestino = cmbxDestino.Text;

            if (!ValidarCiudadDestino(ciudadPartida, ciudadDestino))
            {
                return;
            }

            // Buscar el valor del enumerado correspondiente a la ciudad destino
            if (cmbxTipoViaje.Text == "Nacional")
            {
                DestinosNacionales destinoNacional;
                if (Enum.TryParse(ciudadDestino, out destinoNacional))
                {
                    // Crear una instancia de Vuelo con los valores obtenidos
                    Vuelo vuelo = new Vuelo()
                    {
                        VueloNacional = true,
                        CiudadPartida = ciudadPartida,
                        CiudadDestinoNacional = destinoNacional,
                        CostoPremium = costoPremium,
                        CostoTurista = costoTurista,
                        AsientosTuristaDisponibles = asientosTurista,
                        AsientosPremiumDisponibles = asientosPremium,
                        FechaVuelo = soloFecha,
                        Avion = avionSeleccionado, // usar el avión seleccionado en el combo box
                        //PONER EL AVION EN OCUPADO
                    };
                    avionSeleccionado.OcupadoEnVuelo = true;
                    aerolinea.agregarVuelo(vuelo);
                    MessageBox.Show("El vuelo ha sido dado de alta.", "¡Felicitaciones!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if(cmbxTipoViaje.Text == "Internacional")
            {
                DestinosInternacionales destinoInternacional;
                if (Enum.TryParse(ciudadDestino, out destinoInternacional))
                {
                    // Crear una instancia de Vuelo con los valores obtenidos
                    Vuelo vuelo = new Vuelo()
                    {
                        VueloNacional = false,
                        CiudadPartida = ciudadPartida,
                        CiudadDestinoInternacional = destinoInternacional,
                        CostoPremium = costoPremium,
                        CostoTurista = costoTurista,
                        AsientosPremiumDisponibles = asientosPremium,
                        AsientosTuristaDisponibles = asientosTurista,
                        FechaVuelo = soloFecha,
                        Avion = avionSeleccionado // usar el avión seleccionado en el combo box
                    };
                    avionSeleccionado.OcupadoEnVuelo = true;
                    aerolinea.agregarVuelo(vuelo);
                    MessageBox.Show("El vuelo ha sido dado de alta.", "¡Felicitaciones!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            ActualizarListas();
            limpiarElementos();
        }

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Modificar".
        /// Actualiza la información del vuelo seleccionado con los nuevos datos ingresados.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Vuelo vueloSeleccionado = (Vuelo)cmbxListaVuelos.SelectedItem;
            aerolinea.eliminarVuelo(vueloSeleccionado);

            // Verificar si la lista de aviones tiene al menos un avión
            if (aerolinea.ListaAviones.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un avión antes de crear un vuelo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CamposCompletosValidos(cmbxOrigenDos.Text, cmbxDestinoDos.Text, txtCostoTuristaDos.Text))
            {
                return;
            }

            if (!decimal.TryParse(txtCostoTuristaDos.Text, out decimal costoTurista) ||
                !PrecioValido(costoTurista))
            {
                return;
            }

            decimal porcentajeCostoPremium = CalcularPorcentajeCostoTurista(costoTurista);
            decimal costoPremium = costoTurista * porcentajeCostoPremium;
            txtCostoPremiumDos.Text = "35% Costo Turista: " + costoPremium.ToString();
            txtCostoPremiumDos.ReadOnly = true;

            DateTime fechaVuelo = dtpFechaVueloDos.Value;
            
            if (!ValidarFechaSeleccionada(fechaVuelo, true))
            {
                return;
            }

            // Verificar si el avión seleccionado ya ha sido utilizado en otro vuelo
            Avion avionSeleccionado = (Avion)cmbxMatriculaDos.SelectedItem;
            foreach (Vuelo vuelo in aerolinea.ListaVuelos)
            {
                if (vuelo.Avion.Equals(avionSeleccionado))
                {
                    if (vuelo.Avion.OcupadoEnVuelo == true)
                    {
                        MessageBox.Show("El avión seleccionado ya ha sido utilizado en otro vuelo. Por favor, seleccione otro avión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    continue;
                }
            }

            // Obtener los valores de los campos del formulario
            string ciudadPartida = cmbxOrigenDos.Text;
            string ciudadDestino = cmbxDestinoDos.Text;

            if (!ValidarCiudadDestino(ciudadPartida, ciudadDestino))
            {
                return;
            }

            // Buscar el valor del enumerado correspondiente a la ciudad destino
            if (cmbxTipoViajeDos.Text == "Nacional")
            {
                DestinosNacionales destinoNacional;
                if (Enum.TryParse(ciudadDestino, out destinoNacional))
                {
                    // Crear una instancia de Vuelo con los valores obtenidos

                    vueloSeleccionado.VueloNacional = true;
                    vueloSeleccionado.CiudadPartida = ciudadPartida;
                    vueloSeleccionado.CiudadDestinoNacional = destinoNacional;
                    vueloSeleccionado.CostoPremium = costoPremium;
                    vueloSeleccionado.CostoTurista = costoTurista;
                    vueloSeleccionado.FechaVuelo = fechaVuelo;
                    vueloSeleccionado.Avion = avionSeleccionado;                  
                    avionSeleccionado.OcupadoEnVuelo = true;
                    aerolinea.agregarVuelo(vueloSeleccionado);
                    MessageBox.Show("El vuelo ha sido modificado.", "¡Felicitaciones!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (cmbxTipoViajeDos.Text == "Internacional")
            {
                DestinosInternacionales destinoInternacional;
                if (Enum.TryParse(ciudadDestino, out destinoInternacional))
                {
                    vueloSeleccionado.VueloNacional = false;
                    vueloSeleccionado.CiudadPartida = ciudadPartida;
                    vueloSeleccionado.CiudadDestinoInternacional = destinoInternacional;
                    vueloSeleccionado.CostoPremium = costoPremium;
                    vueloSeleccionado.CostoTurista = costoTurista;
                    vueloSeleccionado.FechaVuelo = fechaVuelo;
                    vueloSeleccionado.Avion = avionSeleccionado;                                      
                    avionSeleccionado.OcupadoEnVuelo = true;
                    aerolinea.agregarVuelo(vueloSeleccionado);
                    MessageBox.Show("El vuelo ha sido modificado.", "¡Felicitaciones!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            ActualizarListas();
            limpiarElementos();
        }
        
        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Eliminar".
        /// Elimina la información del vuelo seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string viajeAEliminar = cmbxViajes.Text; // Obtener el viaje de la combobox
            Vuelo vueloEliminar = null; //buscar el vuelo seleccionado en la cmbx

            foreach (Vuelo v in aerolinea.ListaVuelos)
            {
                if (v.ToString() == viajeAEliminar)
                {
                    vueloEliminar = v;
                    break;
                }
            }

            // Si se encontró el avión, eliminarlo de la lista
            if (vueloEliminar != null)
            {
                aerolinea.eliminarVuelo(vueloEliminar);
                cmbxViajes.Items.Remove(viajeAEliminar);
                MessageBox.Show("El viaje ha sido eliminado.", "¡Felicitaciones!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarListas();
            }
            else
            {
                MessageBox.Show("No se encontró ningún viaje similar al seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion

        #region VISIBILIDAD BOTONES

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Cerrar" en la sección de creación de vuelo.
        /// Oculta el grupo de creación de vuelo y muestra nuevamente las opciones disponibles.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnCerrarUno_Click(object sender, EventArgs e)
        {
            gbxCrearViajes.Visible = false;
            ConfigurarDgvYgroupBox();
            btnOpcionUno.Visible = btnOpcionDos.Visible =  btnOpcionTres.Visible = dgvVuelos.Visible = true;
        }

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Cerrar" en la sección de modificación de vuelo.
        /// Oculta el grupo de modificación de vuelo y muestra nuevamente las opciones disponibles.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnCerrarDos_Click(object sender, EventArgs e)
        {
            gbxModificarViaje.Visible = false;
            ConfigurarDgvYgroupBox();
            btnOpcionUno.Visible =btnOpcionDos.Visible = btnOpcionTres.Visible = dgvVuelos.Visible = true;
        }

        /// <summary>
        /// Evento que se activa cuando se hace clic en el botón "Cerrar" en la sección de eliminar de vuelo.
        /// Oculta el grupo de modificación de vuelo y muestra nuevamente las opciones disponibles.
        /// </summary>
        /// <param name="sender">El objeto que desencadena el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnCerrarTres_Click(object sender, EventArgs e)
        {
            gbxEliminarViaje.Visible = false;
            ConfigurarDgvYgroupBox();
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = dgvVuelos.Visible = true;
        }

        #endregion

        #region ACTUALIZADORES

        /// <summary>
        /// Actualiza las listas de visualización en la interfaz.
        /// </summary>
        private void ActualizarListas()
        {
            cmbxMatriculaAviones.DataSource = null;
            List<Avion> avionesDisponibles = new List<Avion>();

            foreach (Avion avion in aerolinea.ListaAviones)
            {
                if (!avion.OcupadoEnVuelo)
                {
                    avionesDisponibles.Add(avion);
                }
            }

            cmbxMatriculaAviones.DataSource = avionesDisponibles;
            cmbxMatriculaAviones.DisplayMember = nameof(Avion.ToString);
            cmbxMatriculaAviones.Refresh();

            cmbxTipoViaje.DataSource = null;
            if (cmbxTipoViaje.Items.Count == 0)
            {
                cmbxTipoViaje.Items.Add("Nacional");
                cmbxTipoViaje.Items.Add("Internacional");
            }
            cmbxTipoViaje.Refresh();

            // Obtén la fecha y hora actual
            DateTime fechaActual = DateTime.Now;

            // Crea una nueva lista para almacenar los vuelos futuros
            List<Vuelo> vuelosFuturos = new List<Vuelo>();

            // Itera sobre la lista de vuelos y agrega solo los vuelos futuros a la nueva lista
            foreach (Vuelo vuelo in aerolinea.ListaVuelos)
            {
                if (vuelo.FechaVuelo > fechaActual)
                {
                    vuelosFuturos.Add(vuelo);
                }
            }

            // Establece la lista filtrada como origen de datos para el ComboBox
            cmbxListaVuelos.DataSource = null;
            cmbxListaVuelos.DataSource = vuelosFuturos;
            cmbxListaVuelos.DisplayMember = "ObtenerInformacionVuelo";
            cmbxListaVuelos.Refresh();

            cmbxViajes.DataSource = null;
            cmbxViajes.DataSource = vuelosFuturos;
            cmbxViajes.DisplayMember = "ObtenerInformacionVuelo";
            cmbxViajes.Refresh();

            cmbxMatriculaDos.DataSource = null;
            cmbxMatriculaDos.DataSource = avionesDisponibles;
            cmbxMatriculaDos.DisplayMember = nameof(Avion.ToString);
            cmbxMatriculaDos.Refresh();

            cmbxTipoViajeDos.DataSource = null;
            if (cmbxTipoViajeDos.Items.Count == 0)
            {
                cmbxTipoViajeDos.Items.Add("Nacional");
                cmbxTipoViajeDos.Items.Add("Internacional");
            }
            cmbxTipoViajeDos.Refresh();
        }

        /// <summary>
        /// Limpia los campos de texto en la interfaz.
        /// </summary>
        private void limpiarElementos()
        {
            // Limpiar los campos del formulario
            cmbxOrigen.Text = "";
            cmbxDestino.Text = "";
            txtCostoPremium.Text = "";
            txtCostoTurista.Text = "";
            txtAsientosPremium.Text = "";
            txtAsientosTuristas.Text = "";
            dtpFechaVuelo.Value = DateTime.Now;
        }

        /// <summary>
        /// Valida si la fecha seleccionada es válida según ciertas reglas.
        /// </summary>
        /// <param name="fechaSeleccionada">La fecha que se desea validar.</param>
        /// <param name="esModificar">Indica si se está realizando una operación de modificación.</param>
        /// <returns>True si la fecha es válida; False en caso contrario.</returns>
        private bool ValidarFechaSeleccionada(DateTime fechaSeleccionada, bool esModificar)
        {
            DateTime fechaActual = DateTime.Today;
            DateTime fechaLimite = fechaActual.AddDays(30).Date;
            DateTime fechaMaxima = fechaActual.AddYears(1).Date;

            if(esModificar)
            {
                if (fechaSeleccionada < fechaActual || fechaSeleccionada > fechaMaxima)
                {
                    MessageBox.Show("La fecha seleccionada es incorrecta (no se permite una fecha en el pasado, el rango valido es a partir desde dentro de 30 dias hasta dentro del año siguiente).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else if (fechaSeleccionada > fechaMaxima || fechaSeleccionada < fechaLimite)
            {
                MessageBox.Show("La fecha seleccionada es incorrecta (no se permite una fecha en el pasado, el rango valido es a partir desde dentro de 30 dias hasta dentro del año siguiente).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida si la ciudad de destino es diferente a la ciudad de partida.
        /// </summary>
        /// <param name="ciudadPartida">La ciudad de partida.</param>
        /// <param name="ciudadDestino">La ciudad de destino.</param>
        /// <returns>True si la ciudad de destino es válida; False en caso contrario.</returns>
        private bool ValidarCiudadDestino(string ciudadPartida, string ciudadDestino)
        {
            if (ciudadDestino == ciudadPartida)
            {
                MessageBox.Show("La ciudad de destino no puede ser igual a la ciudad de partida.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida si todos los campos requeridos están completos y no están vacíos.
        /// </summary>
        /// <param name="origen">El origen del vuelo.</param>
        /// <param name="destino">El destino del vuelo.</param>
        /// <param name="costoPremium">El costo del boleto premium.</param>
        /// <param name="costoTurista">El costo del boleto de clase turista.</param>
        /// <param name="asientosTurista">El número de asientos disponibles en clase turista.</param>
        /// <returns>True si todos los campos están completos y válidos; False en caso contrario.</returns>
        private bool CamposCompletosValidos(string origen, string destino, string costoTurista)
        {
            if (string.IsNullOrWhiteSpace(origen) ||
                string.IsNullOrWhiteSpace(destino) ||
                string.IsNullOrWhiteSpace(costoTurista))
            {
                MessageBox.Show("Debe completar todos los campos, hay campos vacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Valida si el precio de los boletos premium y turista es válido.
        /// </summary>
        /// <param name="costoPremium">El costo del boleto premium.</param>
        /// <param name="costoTurista">El costo del boleto de clase turista.</param>
        /// <returns>True si el precio es válido; False en caso contrario.</returns>
        private bool PrecioValido(decimal costoTurista)
        {
            if (costoTurista < 0)
            {
                MessageBox.Show("El precio debe ser un número válido mayor o igual a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Calcula el veinte por ciento de la cantidad de asientos en clase turista.
        /// </summary>
        /// <param name="asientosTurista">El número de asientos disponibles en clase turista.</param>
        /// <returns>El veinte por ciento de los asientos en clase turista.</returns>
        private decimal CalcularVeintePorcientoAsientosTuristas(int asientosTurista)
        {
            return asientosTurista * 0.2m;
        }

        /// <summary>
        /// Calcula el treinta y cinco por ciento del costo en clase turista.
        /// </summary>
        /// <param name="costoTurista">El costo de la clase turista.</param>
        /// <returns>El treinta y cinco por ciento de la clase turista.</returns>
        private decimal CalcularPorcentajeCostoTurista(decimal costoTurista)
        {
            return costoTurista * 0.35m;
        }

        /// <summary>
        /// Valida si la cantidad de asientos en clase turista es válida.
        /// </summary>
        /// <param name="asientosTurista">El número de asientos disponibles en clase turista.</param>
        /// <returns>True si la cantidad de asientos es válida; False en caso contrario.</returns>
        private bool AsientosValidos(int asientosTurista, int limiteAsientos)
        {
            if (asientosTurista < 0)
            {
                MessageBox.Show("La cantidad de asientos debe ser un número válido mayor a cero.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int limiteTurista = (int)(limiteAsientos * 0.8); // 80% del límite total de asientos

            if (asientosTurista > limiteTurista)
            {
                MessageBox.Show($"La cantidad de asientos supera al límite de asientos del avión ({limiteTurista})", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Maneja el evento de cambio de selección en el ComboBox cmbxTipoViaje.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void cmbxTipoViaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxTipoViaje.Text == "Nacional")
            {
                // Obtener valores del enumerador DestinosNacionales
                var destinosNacionales = Enum.GetValues(typeof(DestinosNacionales));

                // Crear dos copias independientes del arreglo de destinos nacionales
                var origen = destinosNacionales.Cast<DestinosNacionales>().ToArray();
                var destino = destinosNacionales.Cast<DestinosNacionales>().ToArray();

                // Asignar valores como origen de datos a los ComboBox
                cmbxOrigen.DataSource = origen;
                cmbxDestino.DataSource = destino;
            }
            else if (cmbxTipoViaje.Text == "Internacional")
            {
                // Obtener el valor correspondiente a BuenosAires en el enum DestinosNacionales
                DestinosNacionales buenosAires = DestinosNacionales.BuenosAires;
                // Mostrar solo Buenos Aires en cmbxOrigenSolo
                cmbxOrigen.DataSource = new[] { buenosAires };
                // Obtener valores del enumerador DestinosInternacionales
                var destinosInternacionales = Enum.GetValues(typeof(DestinosInternacionales));
                // Asignar valores como origen de datos a cmbxDestinoDos
                cmbxDestino.DataSource = destinosInternacionales;
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de selección en el ComboBox cmbxTipoViajeDos.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void cmbxTipoViajeDos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxTipoViajeDos.Text == "Nacional")
            {
                // Obtener valores del enumerador DestinosNacionales
                var destinosNacionales = Enum.GetValues(typeof(DestinosNacionales));

                // Crear dos copias independientes del arreglo de destinos nacionales
                var origen = destinosNacionales.Cast<DestinosNacionales>().ToArray();
                var destino = destinosNacionales.Cast<DestinosNacionales>().ToArray();

                // Asignar valores como origen de datos a los ComboBox
                cmbxOrigenDos.DataSource = origen;
                cmbxDestinoDos.DataSource = destino;
            }
            else if (cmbxTipoViajeDos.Text == "Internacional")
            {
                // Obtener el valor correspondiente a BuenosAires en el enum DestinosNacionales
                DestinosNacionales buenosAires = DestinosNacionales.BuenosAires;
                // Mostrar solo Buenos Aires en cmbxOrigenSolo
                cmbxOrigenDos.DataSource = new[] { buenosAires };
                // Obtener valores del enumerador DestinosInternacionales
                var destinosInternacionales = Enum.GetValues(typeof(DestinosInternacionales));
                // Asignar valores como origen de datos a cmbxDestinoDos
                cmbxDestinoDos.DataSource = destinosInternacionales;
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de selección en el ComboBox cmbxListaVuelos.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void cmbxListaVuelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vuelo vueloSeleccionado = (Vuelo)cmbxListaVuelos.SelectedItem;

            if (vueloSeleccionado != null)
            {
                cmbxTipoViajeDos.Text = vueloSeleccionado.VueloNacional ? "Nacional" : "Internacional";
                txtCostoTuristaDos.Text = vueloSeleccionado.CostoTurista.ToString();
                txtCostoPremiumDos.Text = vueloSeleccionado.CostoPremium.ToString();
                cmbxOrigenDos.Text = vueloSeleccionado.CiudadPartida.ToString();
                cmbxDestinoDos.Text = vueloSeleccionado.VueloNacional ? vueloSeleccionado.CiudadDestinoNacional.ToString() : vueloSeleccionado.CiudadDestinoInternacional.ToString();
                dtpFechaVueloDos.Text = vueloSeleccionado.FechaVuelo.ToString();
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de visibilidad del GroupBox gbxModificarViaje.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void gbxModificarViaje_VisibleChanged(object sender, EventArgs e)
        {
            if (gbxModificarViaje.Visible)
            {
                ActualizarListas();
            }
        }

        /// <summary>
        /// Configura la locacion del DataGridView.
        /// </summary>
        private void EstablecerLocacion()
        {
            // Centrar el DataGridView en la pantalla
            dgvVuelos.Left = (this.ClientSize.Width - dgvVuelos.Width) / 2;
            dgvVuelos.Top = ((this.ClientSize.Height - dgvVuelos.Height) / 2) + 40;
        }

        /// <summary>
        /// Configura los controles de la interfaz de usuario para mostrar la información de los vuelos  de una aerolínea en un DataGridView.
        /// </summary>
        private void ConfigurarDgvYgroupBox()
        {           
            dgvVuelos.Visible = true;

            dgvVuelos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVuelos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvVuelos.Columns.Clear(); // Limpiar las columnas existentes
            dgvVuelos.DataSource = aerolinea.ListaVuelos;           
  
            // Mostrar solo los atributos en el DataGridView
            dgvVuelos.DataSource = aerolinea.ListaVuelos.Select(vuelo => new
            { 
                Origen = vuelo.CiudadPartida,
                Destino = vuelo.VueloNacional ?
                    $"{vuelo.CiudadDestinoNacional}" :
                    $"{vuelo.CiudadDestinoInternacional}",
                Pasajeros = vuelo.CantidadPasajeros,
                AsientosTuristas = vuelo.AsientosTuristaDisponibles,
                AsientosPremium = vuelo.AsientosPremiumDisponibles,
                vuelo.CostoTurista,
                vuelo.CostoPremium,
                vuelo.VueloPasado,
                Fecha = vuelo.FechaVuelo,
            }).ToList();

            dgvVuelos.Columns["AsientosTuristas"].HeaderText = "Asientos Turistas Disp.";
            dgvVuelos.Columns["AsientosPremium"].HeaderText = "Asientos Premium Disp.";

            dgvVuelos.Refresh();           
        }

        /// <summary>
        /// Evento de formato de celda del control DataGridView llamado "dgvPasajeros".
        /// Este evento se desencadena cuando una celda del control se está formateando visualmente.
        /// Cambia el color de fondo de todas las celdas a negro y el color de fuente a blanco.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvVuelos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {            
            foreach (DataGridViewRow row in dgvVuelos.Rows)
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
