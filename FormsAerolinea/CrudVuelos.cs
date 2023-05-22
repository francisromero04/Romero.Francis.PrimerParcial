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
    public partial class CrudViajes : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        public CrudViajes(Persona usuario, Aerolinea aerolinea)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            ActualizarListas();

            gbxCrearViajes.Visible = false;
            gbxModificarViaje.Visible = false;
        }       

        #region CONFIGURACION GROUPBOX

        private void btnOpcionUno_Click(object sender, EventArgs e)
        {
            lstViajes.Visible = btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            gbxCrearViajes.Location = new Point(800, 240);
            gbxCrearViajes.Anchor = AnchorStyles.Top;
            gbxCrearViajes.Visible = true;
        }

         private void btnOpcionDos_Click(object sender, EventArgs e)
         {
            lstViajes.Visible = btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            gbxModificarViaje.Location = new Point(800, 240);
            gbxModificarViaje.Anchor = AnchorStyles.Top;
            gbxModificarViaje.Visible = true;
        }

        private void btnOpcionCuatro_Click(object sender, EventArgs e)
        {
            lstViajes.Visible = true;
        }

        #endregion

        #region ACCIONES CLICK BOTONES

        private void btnCrearVuelo_Click(object sender, EventArgs e)
        {
            // Verificar si la lista de aviones tiene al menos un avión
            if (aerolinea.listaAviones.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un avión antes de crear un vuelo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CamposCompletosValidos(cmbxOrigen.Text, cmbxDestino.Text, txtCostoPremium.Text, txtCostoTurista.Text, txtAsientosTuristas.Text))
            {
                return;
            }

            if (!decimal.TryParse(txtCostoPremium.Text, out decimal costoPremium) ||
                !decimal.TryParse(txtCostoTurista.Text, out decimal costoTurista) ||
                !PrecioValido(costoPremium, costoTurista))
            {
                return;
            }

            // Validar que la cantidad de asientos sea un número válido
            if (!int.TryParse(txtAsientosTuristas.Text, out int asientosTurista) || !AsientosValidos(asientosTurista))
            {
                MessageBox.Show("La cantidad de asientos debe ser un número válido mayor o igual a cero", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (!ValidarFechaSeleccionada(fechaVuelo, false))
            {
                return;
            }

            // Verificar si el avión seleccionado ya ha sido utilizado en otro vuelo
            Avion avionSeleccionado = (Avion)cmbxMatriculaAviones.SelectedItem;
            foreach (Vuelo vuelo in aerolinea.listaVuelos)
            {
                if (vuelo.Avion.Equals(avionSeleccionado) && vuelo.FechaVuelo > fechaVuelo && vuelo.FechaVuelo == fechaVuelo)
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
                    Vuelo vuelo = new Vuelo(aerolinea)
                    {
                        vueloNacional = true,
                        CiudadPartida = ciudadPartida,
                        CiudadDestinoNacional = destinoNacional,
                        CostoPremium = costoPremium,
                        CostoTurista = costoTurista,
                        AsientosPremiumDisponibles = asientosPremium,
                        AsientosTuristaDisponibles = asientosTurista,
                        FechaVuelo = fechaVuelo,
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
                    Vuelo vuelo = new Vuelo(aerolinea)
                    {
                        vueloNacional = false,
                        CiudadPartida = ciudadPartida,
                        CiudadDestinoInternacional = destinoInternacional,
                        CostoPremium = costoPremium,
                        CostoTurista = costoTurista,
                        AsientosPremiumDisponibles = asientosPremium,
                        AsientosTuristaDisponibles = asientosTurista,
                        FechaVuelo = fechaVuelo,
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
        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Vuelo vueloSeleccionado = (Vuelo)cmbxListaVuelos.SelectedItem;
            aerolinea.eliminarVuelo(vueloSeleccionado);

            // Verificar si la lista de aviones tiene al menos un avión
            if (aerolinea.listaAviones.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un avión antes de crear un vuelo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CamposCompletosValidos(cmbxOrigenDos.Text, cmbxDestinoDos.Text, txtCostoPremiumDos.Text, txtCostoTuristaDos.Text, txtAsientosTuristasDos.Text))
            {
                return;
            }

            if (!decimal.TryParse(txtCostoPremiumDos.Text, out decimal costoPremium) ||
                !decimal.TryParse(txtCostoTuristaDos.Text, out decimal costoTurista) ||
                !PrecioValido(costoPremium, costoTurista))
            {
                return;
            }

            // Validar que la cantidad de asientos sea un número válido
            if (!int.TryParse(txtAsientosTuristasDos.Text, out int asientosTurista) || !AsientosValidos(asientosTurista))
            {
                MessageBox.Show("La cantidad de asientos debe ser un número válido mayor o igual a cero", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calcular el 20% de los asientos turistas
            decimal veintePorcientoTuristas = CalcularVeintePorcientoAsientosTuristas(asientosTurista);

            // Asignar el valor del 20% a los asientos premium
            int asientosPremium = (int)veintePorcientoTuristas;

            // Cargar el valor en el TextBox txtAsientosPremium y establecerlo como solo lectura
            txtAsientosPremiumDos.Text = asientosPremium.ToString();
            txtAsientosPremiumDos.ReadOnly = true;

            DateTime fechaVuelo = dtpFechaVueloDos.Value;
            
            if (!ValidarFechaSeleccionada(fechaVuelo, true))
            {
                return;
            }

            // Verificar si el avión seleccionado ya ha sido utilizado en otro vuelo
            Avion avionSeleccionado = (Avion)cmbxMatriculaDos.SelectedItem;
            foreach (Vuelo vuelo in aerolinea.listaVuelos)
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

                    vueloSeleccionado.vueloNacional = true;
                    vueloSeleccionado.CiudadPartida = ciudadPartida;
                    vueloSeleccionado.CiudadDestinoNacional = destinoNacional;
                    vueloSeleccionado.CostoPremium = costoPremium;
                    vueloSeleccionado.CostoTurista = costoTurista;
                    vueloSeleccionado.AsientosPremiumDisponibles = asientosPremium;
                    vueloSeleccionado.AsientosTuristaDisponibles = asientosTurista;
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
                    vueloSeleccionado.vueloNacional = false;
                    vueloSeleccionado.CiudadPartida = ciudadPartida;
                    vueloSeleccionado.CiudadDestinoInternacional = destinoInternacional;
                    vueloSeleccionado.CostoPremium = costoPremium;
                    vueloSeleccionado.CostoTurista = costoTurista;
                    vueloSeleccionado.AsientosPremiumDisponibles = asientosPremium;
                    vueloSeleccionado.AsientosTuristaDisponibles = asientosTurista;
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

        #endregion

        #region VISIBILIDAD BOTONES

        private void btnCerrarUno_Click(object sender, EventArgs e)
        {
            gbxCrearViajes.Visible = false;
            btnOpcionUno.Visible = btnOpcionDos.Visible =  btnOpcionTres.Visible =  btnOpcionCuatro.Visible = true;
        }

        private void btnCerrarDos_Click(object sender, EventArgs e)
        {
            gbxModificarViaje.Visible = false;
            btnOpcionUno.Visible =btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = true;
        }

        #endregion
    
        #region ACTUALIZADORES

        private void ActualizarListas()
        {
            lstViajes.DataSource = null;
            lstViajes.DataSource = aerolinea.listaVuelos;
            lstViajes.DisplayMember = "ObtenerInformacionVuelo";
            lstViajes.Refresh();

            cmbxMatriculaAviones.DataSource = null;
            cmbxMatriculaAviones.DataSource = aerolinea.listaAviones;
            cmbxMatriculaAviones.DisplayMember = "Matricula";
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
            foreach (Vuelo vuelo in aerolinea.listaVuelos)
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

            List<Avion> avionesDisponibles = new List<Avion>();

            foreach (Avion avion in aerolinea.listaAviones)
            {
                if (!avion.OcupadoEnVuelo)
                {
                    avionesDisponibles.Add(avion);
                }
            }

            cmbxMatriculaDos.DataSource = null;
            cmbxMatriculaDos.DataSource = avionesDisponibles;
            cmbxMatriculaDos.DisplayMember = "Matricula";
            cmbxMatriculaDos.Refresh();

            cmbxTipoViajeDos.DataSource = null;
            if (cmbxTipoViajeDos.Items.Count == 0)
            {
                cmbxTipoViajeDos.Items.Add("Nacional");
                cmbxTipoViajeDos.Items.Add("Internacional");
            }
            cmbxTipoViajeDos.Refresh();
        }

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

        public bool ValidarFechaSeleccionada(DateTime fechaSeleccionada, bool esModificar)
        {
            DateTime fechaActual = DateTime.Now.Date;
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

        private bool ValidarCiudadDestino(string ciudadPartida, string ciudadDestino)
        {
            if (ciudadDestino == ciudadPartida)
            {
                MessageBox.Show("La ciudad de destino no puede ser igual a la ciudad de partida.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CamposCompletosValidos(string origen, string destino, string costoPremium, string costoTurista, string asientosTurista)
        {
            if (string.IsNullOrWhiteSpace(origen) ||
                string.IsNullOrWhiteSpace(destino) ||
                string.IsNullOrWhiteSpace(costoPremium) ||
                string.IsNullOrWhiteSpace(costoTurista) ||
                string.IsNullOrWhiteSpace(asientosTurista))
            {
                MessageBox.Show("Debe completar todos los campos, hay campos vacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool PrecioValido(decimal costoPremium, decimal costoTurista)
        {
            if (costoPremium < 0 || costoTurista < 0)
            {
                MessageBox.Show("El precio debe ser un número válido mayor o igual a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private decimal CalcularVeintePorcientoAsientosTuristas(int asientosTurista)
        {
            return asientosTurista * 0.2m;
        }

        private bool AsientosValidos(int asientosTurista)
        {
            if (asientosTurista < 0)
            {
                MessageBox.Show("La cantidad de asientos debe ser un número válido mayor o igual a cero", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

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

        private void cmbxListaVuelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vuelo vueloSeleccionado = (Vuelo)cmbxListaVuelos.SelectedItem;

            if (vueloSeleccionado != null)
            {
                cmbxTipoViajeDos.Text = vueloSeleccionado.vueloNacional ? "Nacional" : "Internacional";
                txtCostoTuristaDos.Text = vueloSeleccionado.CostoTurista.ToString();
                txtCostoPremiumDos.Text = vueloSeleccionado.CostoPremium.ToString();
                cmbxOrigenDos.Text = vueloSeleccionado.CiudadPartida.ToString();
                cmbxDestinoDos.Text = vueloSeleccionado.vueloNacional ? vueloSeleccionado.CiudadDestinoNacional.ToString() : vueloSeleccionado.CiudadDestinoInternacional.ToString();
                dtpFechaVueloDos.Text = vueloSeleccionado.FechaVuelo.ToString();
                txtAsientosTuristasDos.Text = vueloSeleccionado.AsientosTuristaDisponibles.ToString();
                txtAsientosPremiumDos.Text = vueloSeleccionado.AsientosPremiumDisponibles.ToString();
            }
        }
        private void gbxModificarViaje_VisibleChanged(object sender, EventArgs e)
        {
            if (gbxModificarViaje.Visible)
            {
                ActualizarListas();
            }
        }

        #endregion              
    }
}
