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
    /// Formulario utilizado para vender un viaje de la aerolínea.
    /// </summary>
    public partial class VenderViaje : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        /// <summary>
        /// Inicializa una nueva instancia de la clase VenderViaje.
        /// </summary>
        /// <param name="usuario">La persona que está utilizando el formulario.</param>
        /// <param name="aerolinea">La aerolínea asociada al viaje.</param>
        public VenderViaje(Persona usuario, Aerolinea aerolinea)
        {
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            InitializeComponent();
            ActualizarListas();
        }

        #region CONTROL CLICK BOTONES

        /// <summary>
        /// Maneja el evento clic del botón "Vender Pasaje" para vender un pasaje.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void btnVenderPasaje_Click(object sender, EventArgs e)
        {
            Pasajero pasajeroSeleccionado = (Pasajero)cmbxListaPasajeros.SelectedItem;
            Vuelo vueloSeleccionado = (Vuelo)cmbxListaVuelos.SelectedItem;
            decimal costoPasaje;

            if (chbTipoPasajero.Checked == true) {
                pasajeroSeleccionado.TipoPasajero = false;
                costoPasaje = vueloSeleccionado.CostoPremium;
            }
            else {
                pasajeroSeleccionado.TipoPasajero = true;
                costoPasaje = vueloSeleccionado.CostoTurista;
            }

            if(pasajeroSeleccionado.TipoPasajero == false)
            {
                decimal pesoEquipajeP = ValidarPesoEquipajePremium(txtPesoEquipajePuno);
                decimal pesoEquipajePdos = ValidarPesoEquipajePremium(txtPesoEquipajePdos);

                if (pesoEquipajeP != 0 && pesoEquipajePdos != 0)
                {
                    decimal pesoTotal = pesoEquipajeP + pesoEquipajePdos;
                    pasajeroSeleccionado.PesoEquipaje = pesoTotal;
                    FinalizarVenta(pasajeroSeleccionado, vueloSeleccionado, costoPasaje, aerolinea);
                    new Pasaje(pasajeroSeleccionado, vueloSeleccionado, true, costoPasaje); // Crear un nuevo pasaje y agregarlo a las listas correspondientes
                }
            }
            else
            {
                decimal pesoEquipajeT = ValidarPesoEquipajeTurista(); 

                if(pesoEquipajeT != 0)
                {                
                    pasajeroSeleccionado.PesoEquipaje = pesoEquipajeT;                
                    FinalizarVenta(pasajeroSeleccionado, vueloSeleccionado, costoPasaje, aerolinea);
                    new Pasaje(pasajeroSeleccionado, vueloSeleccionado, true, costoPasaje); // Crear un nuevo pasaje y agregarlo a las listas correspondientes
                }
            }
        }

        #endregion

        #region ACTUALIZADORES

        /// <summary>
        /// Actualiza los ComboBox de vuelos y pasajeros en el formulario.
        /// </summary>
        private void ActualizarListas()
        {
            var vuelosFuturos = new List<Vuelo>();
            foreach (var vuelo in aerolinea.ListaVuelos)
            {
                if (vuelo.FechaVuelo > DateTime.Now)
                {
                    vuelosFuturos.Add(vuelo);
                }
            }

            cmbxListaVuelos.DataSource = null;
            cmbxListaVuelos.DataSource = vuelosFuturos;
            cmbxListaVuelos.DisplayMember = "ObtenerInformacionVuelo";
            cmbxListaVuelos.Refresh();

            cmbxListaPasajeros.DataSource = null;
            cmbxListaPasajeros.DataSource = aerolinea.ListaPasajeros;
            cmbxListaPasajeros.DisplayMember = "nombreCompletoyDni";
            cmbxListaPasajeros.Refresh();

            if(chbTipoPasajero.Checked == true)
            {
                lblIngresar.Visible = txtPesoEquipajeTurista.Visible = false;
                lblIngresarDos.Location = new Point(455, 495);
                txtPesoEquipajePuno.Location = new Point(620, 495);
                lblIngresarTres.Location = new Point(770, 495);
                txtPesoEquipajePdos.Location = new Point(835, 495);
                lblIngresarDos.Visible = lblIngresarTres.Visible = txtPesoEquipajePuno.Visible = txtPesoEquipajePdos.Visible = true;
            }
            else
            {
                lblIngresarDos.Visible = lblIngresarTres.Visible = txtPesoEquipajePuno.Visible = txtPesoEquipajePdos.Visible = false;
                lblIngresar.Location = new Point(360, 485);
                txtPesoEquipajeTurista.Location = new Point(525, 485);
                lblIngresar.Visible = txtPesoEquipajeTurista.Visible = true;
            }
        }

        /// <summary>
        /// Maneja el evento de cambio de selección del combo box "cmbxListaVuelos".
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Los argumentos del evento.</param>
        private void cmbxListaVuelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vuelo vueloSeleccionado = (Vuelo)cmbxListaVuelos.SelectedItem; 
            
            if (chbTipoPasajero.Checked == true)
            {
                //lblPrecioPasaje.Text = vueloSeleccionado.CostoPremium.ToString();
                lblPrecioPasaje.Text = $"{vueloSeleccionado.CostoPremium} | Costo del Pasaje + IVA = " + vueloSeleccionado.CostoPremium * vueloSeleccionado.IVA;
            }
            else
            {
               // lblPrecioPasaje.Text = vueloSeleccionado.CostoTurista.ToString();
                lblPrecioPasaje.Text = $"{vueloSeleccionado.CostoTurista} | Costo del Pasaje + IVA = " + vueloSeleccionado.CostoTurista * vueloSeleccionado.IVA;
            }
        }
        
        /// <summary>
        /// Maneja el cambio de selección del check box "chbTipoPasajero".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbTipoPasajero_CheckedChanged(object sender, EventArgs e)
        {
            Vuelo vueloSeleccionado = (Vuelo)cmbxListaVuelos.SelectedItem;
            Pasajero pasajeroSeleccionado = (Pasajero)cmbxListaPasajeros.SelectedItem;

            if (chbTipoPasajero.Checked == true) {
                lblPrecioPasaje.Text = $"{vueloSeleccionado.CostoPremium} | Costo del Pasaje + IVA = " + vueloSeleccionado.CostoPremium * vueloSeleccionado.IVA;
                txtPesoEquipajeTurista.Visible = lblIngresar.Visible = false;
                lblIngresarDos.Visible = lblIngresarTres.Visible = txtPesoEquipajePuno.Visible = txtPesoEquipajePdos.Visible = true;
            }
            else { 
                lblPrecioPasaje.Text = $"{vueloSeleccionado.CostoTurista} | Costo del Pasaje + IVA = " + vueloSeleccionado.CostoTurista * vueloSeleccionado.IVA;
                lblIngresarDos.Visible = lblIngresarTres.Visible = txtPesoEquipajePuno.Visible = txtPesoEquipajePdos.Visible = false;
                txtPesoEquipajeTurista.Visible = lblIngresar.Visible = true;
            }
        }

        /// <summary>
        /// Valida el peso del equipaje ingresado por un turista.
        /// </summary>
        /// <returns>El peso del equipaje si es válido, de lo contrario retorna 0.</returns>
        private decimal ValidarPesoEquipajeTurista()
        {
            string pesoEquipajeTexto = txtPesoEquipajeTurista.Text;
            decimal pesoEquipaje;

            if (decimal.TryParse(pesoEquipajeTexto, out pesoEquipaje) && pesoEquipaje > 0)
            {
                if (pesoEquipaje > 21)
                {
                    MessageBox.Show("La valija pesa más de 21 kilos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                else
                {
                    return pesoEquipaje;
                }
            }
            else
            {
                MessageBox.Show("El peso del equipaje ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Valida el peso del equipaje ingresado para un turista premium.
        /// </summary>
        /// <param name="txtPesoEquipaje">El control TextBox que contiene el peso del equipaje.</param>
        /// <returns>El peso del equipaje si es válido, de lo contrario retorna 0.</returns>
        private decimal ValidarPesoEquipajePremium(TextBox txtPesoEquipaje)
        {
            string pesoEquipajeTexto = txtPesoEquipaje.Text;
            decimal pesoEquipaje;

            if (decimal.TryParse(pesoEquipajeTexto, out pesoEquipaje) && pesoEquipaje > 0)
            {
                if (pesoEquipaje > 25)
                {
                    MessageBox.Show("La(s) valija(s) pesa(n) más de 25 kilos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                else
                {
                    return pesoEquipaje;
                }
            }
            else
            {
                MessageBox.Show("El peso del equipaje ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        #endregion

        #region VERIFICADORES

        /// <summary>
        /// Finaliza la venta de un pasaje para el pasajero y vuelo seleccionados.
        /// </summary>
        /// <param name="pasajeroSeleccionado">El pasajero seleccionado para la venta del pasaje.</param>
        /// <param name="vueloSeleccionado">El vuelo seleccionado para la venta del pasaje.</param>
        /// <param name="costoPasaje">El costo del pasaje.</param>
        /// <param name="aerolinea">La aerolínea asociada al vuelo.</param>
        private void FinalizarVenta(Pasajero pasajeroSeleccionado, Vuelo vueloSeleccionado, decimal costoPasaje, Aerolinea aerolinea)
        {
            if(vueloSeleccionado.ContienePasajero(pasajeroSeleccionado) == false && VerificarDisponibilidadVuelo(vueloSeleccionado) == true &&
               VerificarCapacidadBodega(pasajeroSeleccionado, vueloSeleccionado) == true && VerificarDisponibilidadAsiento(pasajeroSeleccionado, vueloSeleccionado) == true) 
            {
                if((pasajeroSeleccionado.TipoPasajero == false && vueloSeleccionado.AsientosPremiumDisponibles > 0) ||
                (pasajeroSeleccionado.TipoPasajero == true && vueloSeleccionado.AsientosTuristaDisponibles > 0))
                {
                    if (vueloSeleccionado.Pasajeros != null)
                    {
                        pasajeroSeleccionado.CantidadVuelosHistoricos++;
                        vueloSeleccionado.Pasajeros.Add(pasajeroSeleccionado); //hacer capa
                        MostrarMensajeConfirmacion(pasajeroSeleccionado, vueloSeleccionado, costoPasaje);
                    }               

                    vueloSeleccionado.VenderPasaje(pasajeroSeleccionado, pasajeroSeleccionado.TipoPasajero);

                    if (pasajeroSeleccionado.TipoPasajero == false)
                    {
                        if(vueloSeleccionado.VueloNacional == true)
                        {
                            aerolinea.DineroTotalNacional += vueloSeleccionado.CostoPremium * vueloSeleccionado.IVA;
                            aerolinea.gananciaNacional[vueloSeleccionado.CiudadDestinoNacional] += vueloSeleccionado.CostoPremium * vueloSeleccionado.IVA;
                        }
                        else
                        {
                            aerolinea.DineroTotalInternacional += vueloSeleccionado.CostoPremium * vueloSeleccionado.IVA;
                            aerolinea.gananciaInternacional[vueloSeleccionado.CiudadDestinoInternacional] += vueloSeleccionado.CostoPremium * vueloSeleccionado.IVA;
                        }

                    }
                    else
                    {
                        if (vueloSeleccionado.VueloNacional == true)
                        {
                            aerolinea.DineroTotalNacional += vueloSeleccionado.CostoTurista * vueloSeleccionado.IVA;
                            aerolinea.gananciaNacional[vueloSeleccionado.CiudadDestinoNacional] += vueloSeleccionado.CostoTurista * vueloSeleccionado.IVA;
                        }
                        else
                        {
                            aerolinea.DineroTotalInternacional += vueloSeleccionado.CostoTurista * vueloSeleccionado.IVA;
                            aerolinea.gananciaInternacional[vueloSeleccionado.CiudadDestinoInternacional] += vueloSeleccionado.CostoTurista * vueloSeleccionado.IVA;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Verifica la disponibilidad del vuelo seleccionado.
        /// </summary>
        /// <param name="vueloSeleccionado">El vuelo seleccionado.</param>
        /// <returns>True si el vuelo está disponible; False de lo contrario.</returns>
        private bool VerificarDisponibilidadVuelo(Vuelo vueloSeleccionado)
        {
            bool estaDisponible;

            if (vueloSeleccionado.FechaVuelo.Date < DateTime.Today)
            {
                MessageBox.Show("El vuelo seleccionado no está disponible para la fecha actual.");
                estaDisponible = false;
            }
            else { estaDisponible = true; }

            return estaDisponible;
        }

        /// <summary>
        /// Verifica la capacidad de la bodega del avión para el equipaje del pasajero.
        /// </summary>
        /// <param name="pasajeroSeleccionado">El pasajero seleccionado.</param>
        /// <param name="vueloSeleccionado">El vuelo seleccionado.</param>
        /// <returns>True si la capacidad de la bodega es suficiente; False de lo contrario.</returns>
        private bool VerificarCapacidadBodega(Pasajero pasajeroSeleccionado, Vuelo vueloSeleccionado)
        {
            bool estaDisponible;
            decimal pesoEquipaje = Convert.ToDecimal(vueloSeleccionado.Avion.CapacidadBodega);

            if (pasajeroSeleccionado.PesoEquipaje > pesoEquipaje)
            {
                MessageBox.Show("El peso del equipaje del pasajero supera la capacidad de la bodega del avión.");
                estaDisponible = false;
            }
            else { estaDisponible = true; }

            return estaDisponible;  
        }

        /// <summary>
        /// Verifica la disponibilidad de asientos según el tipo de pasajero en el vuelo seleccionado.
        /// </summary>
        /// <param name="pasajeroSeleccionado">El pasajero seleccionado.</param>
        /// <param name="vueloSeleccionado">El vuelo seleccionado.</param>
        /// <returns>True si hay asientos disponibles; False de lo contrario.</returns>
        private bool VerificarDisponibilidadAsiento(Pasajero pasajeroSeleccionado, Vuelo vueloSeleccionado)
        {
            bool estaDisponible; 

            if (pasajeroSeleccionado.TipoPasajero == false && vueloSeleccionado.AsientosPremiumDisponibles == 0)
            {
                MessageBox.Show("Lo sentimos, no quedan más asientos premium disponibles en este vuelo.");
                estaDisponible = false;
            }
            else { estaDisponible = true; }

            if (pasajeroSeleccionado.TipoPasajero == true && vueloSeleccionado.AsientosTuristaDisponibles == 0)
            {
                MessageBox.Show("Lo sentimos, no quedan más asientos turista disponibles en este vuelo.");
                estaDisponible = false;
            }
            else { estaDisponible = true; }

            return estaDisponible;
        }

        /// <summary>
        /// Muestra un mensaje de confirmación de la venta del pasaje.
        /// </summary>
        /// <param name="pasajeroSeleccionado">El pasajero seleccionado.</param>
        /// <param name="vueloSeleccionado">El vuelo seleccionado.</param>
        /// <param name="costoPasaje">El costo del pasaje.</param>
        private void MostrarMensajeConfirmacion(Pasajero pasajeroSeleccionado, Vuelo vueloSeleccionado, decimal costoPasaje)
        {
            MessageBox.Show($"¡Pasaje vendido! \nNombre del pasajero: {pasajeroSeleccionado.Nombre} {pasajeroSeleccionado.Apellido} \nCiudad de partida: {vueloSeleccionado.CiudadPartida} " +
                                         $"\nCiudad de destino: {(vueloSeleccionado.VueloNacional == true ? vueloSeleccionado.CiudadDestinoNacional.ToString() : vueloSeleccionado.CiudadDestinoInternacional.ToString())} " +
                                         $"\nFecha de vuelo: {vueloSeleccionado.FechaVuelo.ToString("dd/MM/yyyy")} \nTipo: {(pasajeroSeleccionado.TipoPasajero ? "Turista" : "Premium")} " +
                                         $"\nCosto del pasaje: {(pasajeroSeleccionado.TipoPasajero == false ? vueloSeleccionado.CostoPremium : vueloSeleccionado.CostoTurista)}" +
                                         $" \nCosto del pasaje + IVA: {(pasajeroSeleccionado.TipoPasajero == false ? vueloSeleccionado.CostoPremium * vueloSeleccionado.IVA : vueloSeleccionado.CostoTurista * vueloSeleccionado.IVA)}");
        }

        #endregion
    }
}
