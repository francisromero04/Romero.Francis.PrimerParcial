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
    public partial class VenderViaje : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        public VenderViaje(Persona usuario, Aerolinea aerolinea)
        {
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            InitializeComponent();
            ActualizarListas();
        }

        #region CONTROL CLICK BOTONES

        private void btnVenderPasaje_Click(object sender, EventArgs e)
        {
            Pasajero pasajeroSeleccionado = new Pasajero();
            Vuelo vueloSeleccionado = new Vuelo(aerolinea);
            decimal costoPasaje;

            if (chbTipoPasajero.Checked == true)
            {
                pasajeroSeleccionado.tipoPasajero = false; //premium
                pasajeroSeleccionado = (Pasajero)cmbxListaPasajeros.SelectedItem;
                costoPasaje = vueloSeleccionado.CostoPremium;
            }
            else
            {
                pasajeroSeleccionado = (Pasajero)cmbxListaPasajeros.SelectedItem;
                pasajeroSeleccionado.tipoPasajero = true; //turista
                costoPasaje = vueloSeleccionado.CostoTurista;
            }

            vueloSeleccionado = (Vuelo)cmbxListaVuelos.SelectedItem; 
                        
            if (vueloSeleccionado != null) // Verificar si el vuelo seleccionado no es nulo
            {                
                lblPrecioPasaje.Text = "US $" + (pasajeroSeleccionado.tipoPasajero == true ? vueloSeleccionado.CostoTurista : vueloSeleccionado.CostoPremium) + 
                                       " PRECIO + IVA " + ((pasajeroSeleccionado.tipoPasajero == true ? vueloSeleccionado.CostoTurista : vueloSeleccionado.CostoPremium))*vueloSeleccionado.IVA;
            }
            else
            {                
                lblPrecioPasaje.Text = "N/A"; // Si el vuelo seleccionado es nulo, asignar un valor predeterminado al Label
            }

            FinalizarVenta(pasajeroSeleccionado, vueloSeleccionado, costoPasaje, aerolinea);
            new Pasaje(pasajeroSeleccionado, vueloSeleccionado, true, costoPasaje); // Crear un nuevo pasaje y agregarlo a las listas correspondientes
        }

        #endregion

        #region ACTUALIZADORES

        private void ActualizarListas()
        {
            var vuelosFuturos = new List<Vuelo>();
            foreach (var vuelo in aerolinea.listaVuelos)
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
            cmbxListaPasajeros.DataSource = aerolinea.listaPasajeros;
            cmbxListaPasajeros.DisplayMember = "nombreCompletoyDni";
            cmbxListaPasajeros.Refresh();
        }

        private void cmbxListaVuelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chbTipoPasajero.Checked == true)
            {
                // Obtener el vuelo seleccionado
                Vuelo vueloSeleccionado = (Vuelo)cmbxListaVuelos.SelectedItem;

                // Actualizar el valor del Label con el costo premium del vuelo seleccionado
                lblPrecioPasaje.Text = vueloSeleccionado.CostoPremium.ToString();
            }
            else
            {
                // Obtener el vuelo seleccionado
                Vuelo vueloSeleccionado = (Vuelo)cmbxListaVuelos.SelectedItem;

                // Actualizar el valor del Label con el costo premium del vuelo seleccionado
                lblPrecioPasaje.Text = vueloSeleccionado.CostoTurista.ToString();
            }
        }

        #endregion

        #region VERIFICADORES

        private void FinalizarVenta(Pasajero pasajeroSeleccionado, Vuelo vueloSeleccionado, decimal costoPasaje, Aerolinea aerolinea)
        {
            if(vueloSeleccionado.ContienePasajero(pasajeroSeleccionado) == false && VerificarDisponibilidadVuelo(vueloSeleccionado) == true &&
               VerificarCapacidadBodega(pasajeroSeleccionado, vueloSeleccionado) == true && VerificarDisponibilidadAsiento(pasajeroSeleccionado, vueloSeleccionado) == true) 
            {
                if((pasajeroSeleccionado.tipoPasajero == false && vueloSeleccionado.AsientosPremiumDisponibles > 0) ||
                (pasajeroSeleccionado.tipoPasajero == true && vueloSeleccionado.AsientosTuristaDisponibles > 0))
                {
                    if (vueloSeleccionado.Pasajeros != null)
                    {
                        vueloSeleccionado.Pasajeros.Add(pasajeroSeleccionado);
                        MostrarMensajeConfirmacion(pasajeroSeleccionado, vueloSeleccionado, costoPasaje);
                    }               

                    vueloSeleccionado.VenderPasaje(pasajeroSeleccionado, true);

                    if (pasajeroSeleccionado.tipoPasajero == false)
                    {
                        aerolinea.dineroTotal += vueloSeleccionado.CostoPremium * vueloSeleccionado.IVA;
               
                    }
                    else
                    {
                        aerolinea.dineroTotal += vueloSeleccionado.CostoTurista * vueloSeleccionado.IVA;
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha podido vender el pasaje correctamente.");
            }
        }

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

        private bool VerificarCapacidadBodega(Pasajero pasajeroSeleccionado, Vuelo vueloSeleccionado)
        {
            bool estaDisponible;
            decimal pesoEquipaje = Convert.ToDecimal(vueloSeleccionado.Avion.CapacidadBodega);

            if (pasajeroSeleccionado.pesoEquipaje > pesoEquipaje)
            {
                MessageBox.Show("El peso del equipaje del pasajero supera la capacidad de la bodega del avión.");
                estaDisponible = false;
            }
            else { estaDisponible = true; }

            return estaDisponible;  
        }

        private bool VerificarDisponibilidadAsiento(Pasajero pasajeroSeleccionado, Vuelo vueloSeleccionado)
        {
            bool estaDisponible; 

            if (pasajeroSeleccionado.tipoPasajero == false && vueloSeleccionado.AsientosPremiumDisponibles == 0)
            {
                MessageBox.Show("Lo sentimos, no quedan más asientos premium disponibles en este vuelo.");
                estaDisponible = false;
            }
            else { estaDisponible = true; }

            if (pasajeroSeleccionado.tipoPasajero == true && vueloSeleccionado.AsientosTuristaDisponibles == 0)
            {
                MessageBox.Show("Lo sentimos, no quedan más asientos turista disponibles en este vuelo.");
                estaDisponible = false;
            }
            else { estaDisponible = true; }

            return estaDisponible;
        }

        private void MostrarMensajeConfirmacion(Pasajero pasajeroSeleccionado, Vuelo vueloSeleccionado, decimal costoPasaje)
        {
            MessageBox.Show($"¡Pasaje vendido! \nNombre del pasajero: {pasajeroSeleccionado.nombre} {pasajeroSeleccionado.apellido} \nCiudad de partida: {vueloSeleccionado.CiudadPartida} " +
                                         $"\nCiudad de destino: {(vueloSeleccionado.vueloNacional == true ? vueloSeleccionado.CiudadDestinoNacional.ToString() : vueloSeleccionado.CiudadDestinoInternacional.ToString())} " +
                                         $"\nFecha de vuelo: {vueloSeleccionado.FechaVuelo.ToString("dd/MM/yyyy")} \nTipo: {(pasajeroSeleccionado.tipoPasajero == true ? "Turista" : "Premium")} " +
                                         $"\nCosto del pasaje: {(pasajeroSeleccionado.tipoPasajero == false ? vueloSeleccionado.CostoPremium : vueloSeleccionado.CostoTurista)}" +
                                         $" \nCosto del pasaje + IVA: {(pasajeroSeleccionado.tipoPasajero == false ? vueloSeleccionado.CostoPremium * vueloSeleccionado.IVA : vueloSeleccionado.CostoTurista * vueloSeleccionado.IVA)}");
        }

        #endregion
    }
}
