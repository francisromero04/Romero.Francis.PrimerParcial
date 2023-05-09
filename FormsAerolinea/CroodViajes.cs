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
    public partial class CroodViajes : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        public CroodViajes(Persona usuario, Aerolinea aerolinea)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            lbldentificador.Text = usuario.cargo + " - " + DateTime.Now.ToString();
            ActualizarListas();

            gbxCrearViaje.Visible = false;
            gbxModificarViaje.Visible = false;
        }       

        #region CONFIGURACION GROUPBOX

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPrincipal formMenuP = new MenuPrincipal(usuario, aerolinea);
            formMenuP.Show();
        }

        private void btnOpcionUno_Click(object sender, EventArgs e)
        {
            lblTituloMenu.Visible = btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = btnRegresar.Visible = false;
            int posX = (Width - gbxCrearViajeAleatorio.Width) / 2;
            int posY = (Height - gbxCrearViajeAleatorio.Height) / 2;
            gbxCrearViajeAleatorio.Location = new Point(posX, posY);
            gbxCrearViajeAleatorio.Visible = true;
        }     

        private void btnOpcionCuatro_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = btnRegresar.Visible = false;
            int posX = (Width - gbxCrearViaje.Width) / 2;
            int posY = (Height - gbxCrearViaje.Height) / 2;
            gbxCrearViaje.Location = new Point(posX, posY);
            gbxCrearViaje.Visible = true;
        }

        #endregion

        #region ACCIONES CLICK BOTONES

        private void btnCrearViajeAleatorio_Click(object sender, EventArgs e)
        {
            try
            {
                Vuelo vuelo = new Vuelo(aerolinea).CrearVueloAleatorio(aerolinea);
                if (vuelo != null)
                {
                    aerolinea.agregarVuelo(vuelo);
                    ActualizarListas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // Verificar si la lista de aviones tiene al menos un avión
            if (aerolinea.listaAviones.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un avión antes de crear un vuelo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CamposCompletosValidos(cmbxOrigenDos.Text, cmbxDestinoDos.Text, txtCostoPremiumDos.Text, txtCostoTuristaDos.Text, txtAsientosPremiumDos.Text, txtAsientosTuristaDos.Text))
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
            if (!int.TryParse(txtAsientosPremiumDos.Text, out int asientosPremium) || asientosPremium < 0 ||
                !int.TryParse(txtAsientosTuristaDos.Text, out int asientosTurista) || asientosTurista < 0)
            {
                MessageBox.Show("La cantidad de asientos debe ser un número válido mayor o igual a cero", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si el avión seleccionado ya ha sido utilizado en otro vuelo
            Avion avionSeleccionado = (Avion)cmbxMatriculaAvion.SelectedItem;
            foreach (Vuelo vuelo in aerolinea.listaVuelos)
            {
                if (vuelo.Avion == avionSeleccionado)
                {
                    MessageBox.Show("El avión seleccionado ya ha sido utilizado en otro vuelo. Por favor, seleccione otro avión.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Obtener los valores de los campos del formulario
            string ciudadPartida = cmbxOrigenDos.Text;
            string ciudadDestino = cmbxDestinoDos.Text;
            DateTime fechaVuelo = dtpFechaVueloDos.Value;

            // Buscar el valor del enumerado correspondiente a la ciudad destino
            if (chbVerificarVueloNacional.Checked)
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
            else
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

        #endregion

        #region VISIBILIDAD BOTONES

        private void btnCerrarUno_Click(object sender, EventArgs e)
        {
            gbxCrearViaje.Visible = false;
            btnOpcionUno.Visible = btnOpcionDos.Visible =  btnOpcionTres.Visible =  btnOpcionCuatro.Visible =  btnRegresar.Visible = true;
        }

        private void btnCerrarDos_Click(object sender, EventArgs e)
        {
            gbxModificarViaje.Visible = false;
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = btnRegresar.Visible = true;
        }

        private void btnCerrarCuatro_Click(object sender, EventArgs e)
        {
            gbxCrearViajeAleatorio.Visible = false;
            lblTituloMenu.Visible = btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = btnRegresar.Visible = true;
        }

        #endregion
    
        #region ACTUALIZADORES

        private void ActualizarListas()
        {
            lstViajes.DataSource = null;
            lstViajes.DataSource = aerolinea.listaVuelos;
            lstViajes.DisplayMember = "ObtenerInformacionVuelo";
            lstViajes.Refresh();

            cmbxMatriculaAvion.DataSource = null;
            cmbxMatriculaAvion.DataSource = aerolinea.listaAviones;
            cmbxMatriculaAvion.DisplayMember = "Matricula";
            cmbxMatriculaAvion.Refresh();
        }

        private void limpiarElementos()
        {
            // Limpiar los campos del formulario
            cmbxOrigenDos.Text = "";
            cmbxDestinoDos.Text = "";
            txtCostoPremiumDos.Text = "";
            txtCostoTuristaDos.Text = "";
            txtAsientosPremiumDos.Text = "";
            txtAsientosTuristaDos.Text = "";
            dtpFechaVueloDos.Value = DateTime.Now;
        }

        private bool CamposCompletosValidos(string origen, string destino, string costoPremium, string costoTurista, string asientosPremium, string asientosTurista)
        {
            if (string.IsNullOrWhiteSpace(origen) ||
                string.IsNullOrWhiteSpace(destino) ||
                string.IsNullOrWhiteSpace(costoPremium) ||
                string.IsNullOrWhiteSpace(costoTurista) ||
                string.IsNullOrWhiteSpace(asientosPremium) ||
                string.IsNullOrWhiteSpace(asientosTurista))
            {
                MessageBox.Show("Debe completar todos los campos", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool PrecioValido(decimal costoPremium, decimal costoTurista)
        {
            if (costoPremium < 0 || costoTurista < 0)
            {
                MessageBox.Show("El precio debe ser un número válido mayor o igual a cero", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool AsientosValidos(int asientosPremium, int asientosTurista)
        {
            if (asientosPremium < 0 || asientosTurista < 0)
            {
                MessageBox.Show("La cantidad de asientos debe ser un número válido mayor o igual a cero", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void chbVerificarVueloNacional_CheckedChanged(object sender, EventArgs e)
        {
            if (chbVerificarVueloNacional.Checked)
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
            else
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

        #endregion
    }
}
