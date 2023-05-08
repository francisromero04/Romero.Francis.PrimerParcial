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

        private void CroodViajes_Load(object sender, EventArgs e)
        {
            cmbxOrigenDos.Items.Add("BuenosAires");
            cmbxOrigenDos.SelectedItem = "BuenosAires";            
            cmbxDestinoDos.DataSource = Enum.GetValues(typeof(DestinosNacionales));
           // cmbxDestinoDos.DataSource = Enum.GetValues(typeof(DestinosInternacionales));
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPrincipal formMenuP = new MenuPrincipal(usuario, aerolinea);
            formMenuP.Show();
        }

        private void btnOpcionUno_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = btnRegresar.Visible = false;
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
            Vuelo vuelo = new Vuelo().CrearVueloAleatorio(aerolinea.listaAviones);
            aerolinea.agregarVuelo(vuelo);
            ActualizarListas();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            // Validar que los campos estén completos
            if (string.IsNullOrWhiteSpace(cmbxOrigenDos.Text) ||
                string.IsNullOrWhiteSpace(cmbxDestinoDos.Text) ||
                string.IsNullOrWhiteSpace(txtCostoPremiumDos.Text) ||
                string.IsNullOrWhiteSpace(txtCostoTuristaDos.Text) ||
                string.IsNullOrWhiteSpace(txtAsientosPremiumDos.Text) ||
                string.IsNullOrWhiteSpace(txtAsientosTuristaDos.Text))
            {
                MessageBox.Show("Debe completar todos los campos", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que los precios sean números válidos
            if (!decimal.TryParse(txtCostoPremiumDos.Text, out decimal costoPremium) || costoPremium < 0 ||
                !decimal.TryParse(txtCostoTuristaDos.Text, out decimal costoTurista) || costoTurista < 0)
            {
                MessageBox.Show("El precio debe ser un número válido mayor o igual a cero", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que la cantidad de asientos sea un número válido
            if (!int.TryParse(txtAsientosPremiumDos.Text, out int asientosPremium) || asientosPremium < 0 ||
                !int.TryParse(txtAsientosTuristaDos.Text, out int asientosTurista) || asientosTurista < 0)
            {
                MessageBox.Show("La cantidad de asientos debe ser un número válido mayor o igual a cero", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener los valores de los campos del formulario
            string ciudadPartida = cmbxOrigenDos.Text;
            string ciudadDestino = cmbxDestinoDos.Text;
            DateTime fechaVuelo = dtpFechaVueloDos.Value;

            // Crear una instancia de Vuelo con los valores obtenidos
            Vuelo vuelo = new Vuelo
            {
                CiudadPartida = ciudadPartida,
                CiudadDestinoNacional = new DestinosNacionales(),
                CiudadDestinoInternacional = new DestinosInternacionales(),
                CostoPremium = costoPremium,
                CostoTurista = costoTurista,
                AsientosPremiumDisponibles = asientosPremium,
                AsientosTuristaDisponibles = asientosTurista,
                FechaVuelo = fechaVuelo
            };

            aerolinea.agregarVuelo(vuelo);

            // Limpiar los campos del formulario
            cmbxOrigenDos.Text = "";
            cmbxDestinoDos.Text = "";
            txtCostoPremiumDos.Text = "";
            txtCostoTuristaDos.Text = "";
            txtAsientosPremiumDos.Text = "";
            txtAsientosTuristaDos.Text = "";
            dtpFechaVueloDos.Value = DateTime.Now;
        }

        #endregion

        #region VISIBILIDAD BOTONES

        private void btnCerrarUno_Click(object sender, EventArgs e)
        {
            gbxCrearViaje.Visible = false;
            btnOpcionUno.Visible = true;
            btnOpcionDos.Visible = true;
            btnOpcionTres.Visible = true;
            btnOpcionCuatro.Visible = true;
            btnRegresar.Visible = true;
        }

        private void btnCerrarDos_Click(object sender, EventArgs e)
        {
            gbxModificarViaje.Visible = false;
            btnOpcionUno.Visible = true;
            btnOpcionDos.Visible = true;
            btnOpcionTres.Visible = true;
            btnOpcionCuatro.Visible = true;
            btnRegresar.Visible = true;
        }

        private void btnCerrarCuatro_Click(object sender, EventArgs e)
        {
            gbxCrearViajeAleatorio.Visible = false;
            btnOpcionUno.Visible = true;
            btnOpcionDos.Visible = true;
            btnOpcionTres.Visible = true;
            btnOpcionCuatro.Visible = true;
            btnRegresar.Visible = true;
        }

        #endregion
    
        #region ACTUALIZADORES

        private void ActualizarListas()
        {
            lstViajes.DataSource = null;
            lstViajes.DataSource = aerolinea.listaVuelos;
            lstViajes.DisplayMember = "ObtenerInformacionVuelo";
            lstViajes.Refresh();
        }

        #endregion
   
    }
}
