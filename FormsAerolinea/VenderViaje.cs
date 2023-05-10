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
            lbldentificador.Text = usuario.cargo + " - " + DateTime.Now.ToString();

            cmbxListaVuelos.DataSource = null;
            cmbxListaVuelos.DataSource = aerolinea.listaVuelos;
            cmbxListaVuelos.DisplayMember = "ObtenerInformacionVuelo";
            cmbxListaVuelos.Refresh();

            cmbxListaPasajeros.DataSource = null;
            cmbxListaPasajeros.DataSource = aerolinea.listaPasajeros;
            cmbxListaPasajeros.DisplayMember = "nombreCompletoyDni";
            cmbxListaPasajeros.Refresh();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPrincipal formMenuP = new MenuPrincipal(usuario, aerolinea);
            formMenuP.Show();
        }

        private void btnVenderPasaje_Click(object sender, EventArgs e)
        {
            Pasajero pasajeroSeleccionado = new Pasajero();
            Vuelo vueloSeleccionado = new Vuelo(aerolinea);
            decimal costoPasaje;

            if (chbTipoPasajero.Checked == true)
            {
                pasajeroSeleccionado = (Pasajero)cmbxListaPasajeros.SelectedItem;
                pasajeroSeleccionado.tipoPasajero = true;
                vueloSeleccionado = (Vuelo)cmbxListaVuelos.SelectedItem;
                costoPasaje = vueloSeleccionado.CostoPremium;

                // Verificar si el vuelo seleccionado no es nulo
                if (vueloSeleccionado != null)
                {
                    // Actualizar el valor del Label con el costo premium del vuelo seleccionado
                    lblPrecioPasaje.Text = "$" + vueloSeleccionado.CostoPremium.ToString();
                }
                else
                {
                    // Si el vuelo seleccionado es nulo, asignar un valor predeterminado al Label
                    lblPrecioPasaje.Text = "N/A";
                }

                // Obtener el vuelo seleccionado y el pasajero ingresado
                vueloSeleccionado = (Vuelo)cmbxListaVuelos.SelectedItem;

                // Verificar si el avión tiene capacidad disponible para el pasajero
                if (pasajeroSeleccionado.tipoPasajero == true && vueloSeleccionado.AsientosPremiumDisponibles == 0)
                {
                    MessageBox.Show("Lo sentimos, no quedan más asientos premium disponibles en este vuelo.");
                    return;
                }
                else if (pasajeroSeleccionado.tipoPasajero == false && vueloSeleccionado.AsientosTuristaDisponibles == 0)
                {
                    MessageBox.Show("Lo sentimos, no quedan más asientos turista disponibles en este vuelo.");
                    return;
                }

                // Verificar si la capacidad de la bodega del avión es suficiente
                decimal pesoEquipaje = Convert.ToDecimal(vueloSeleccionado.Avion.CapacidadBodega);

                if (pasajeroSeleccionado.pesoEquipaje > pesoEquipaje)
                {
                    MessageBox.Show("El peso del equipaje del pasjero supera la capacidad de la bodega del avión.");
                    return;
                }

                // Verificar si el vuelo está disponible para la fecha actual
                if (vueloSeleccionado.FechaVuelo.Date < DateTime.Today)
                {
                    MessageBox.Show("El vuelo seleccionado no está disponible para la fecha actual.");
                    return;
                }

                // Crear un nuevo pasaje y agregarlo a las listas correspondientes
                new Pasaje(pasajeroSeleccionado, vueloSeleccionado, true, costoPasaje);
                vueloSeleccionado.Pasajeros.Add(pasajeroSeleccionado);
                vueloSeleccionado.VenderPasaje(pasajeroSeleccionado, true);
                aerolinea.listaPasajeros.Add(pasajeroSeleccionado);

                // Actualizar la cantidad de asientos disponibles y el dinero total de la aerolínea
                if (pasajeroSeleccionado.tipoPasajero == true)
                {
                    vueloSeleccionado.AsientosPremiumDisponibles--;
                    aerolinea.dineroTotal += vueloSeleccionado.CostoPremium;
                }
                else
                {
                    vueloSeleccionado.AsientosTuristaDisponibles--;
                    aerolinea.dineroTotal += vueloSeleccionado.CostoTurista;
                }

                // Mostrar un mensaje de confirmación al usuario
                MessageBox.Show($"¡Pasaje vendido! \nNombre del pasajero: {pasajeroSeleccionado.nombre} {pasajeroSeleccionado.apellido} \nCiudad de partida: {vueloSeleccionado.CiudadPartida} \nCiudad de destino: {(vueloSeleccionado.vueloNacional == false ? vueloSeleccionado.CiudadDestinoNacional.ToString() : vueloSeleccionado.CiudadDestinoInternacional.ToString())} \nFecha de vuelo: {vueloSeleccionado.FechaVuelo.ToString("dd/MM/yyyy")} \nTipo: {pasajeroSeleccionado.tipoPasajero} \nCosto del pasaje: {(pasajeroSeleccionado.tipoPasajero == true ? vueloSeleccionado.CostoPremium : vueloSeleccionado.CostoTurista)}");
            }
            //else{agregar porcion de codigo la cual realice lo mismo pero con el precio turista}
        }

        private void chbDestino_CheckedChanged(object sender, EventArgs e)
        {

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

        private void btnCerrarCuatro_Click(object sender, EventArgs e)
        {
                
        }
    }
}
