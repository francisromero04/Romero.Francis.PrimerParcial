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
    public partial class CroodAeronaves : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        public CroodAeronaves(Persona usuario, Aerolinea aerolinea)
        {
            this.usuario = usuario;
            InitializeComponent();
            lbldentificador.Text = usuario.cargo + " - " + DateTime.Now.ToString();
            this.aerolinea = aerolinea;
            ActualizarListas();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPrincipal formMenuP = new MenuPrincipal(usuario, aerolinea);
            formMenuP.Show();
        }

        private void btnOpcionUno_Click(object sender, EventArgs e)
        {
            Avion avion = new Avion().DevolverAvion();
            aerolinea.agregarAvion(avion);
            ActualizarListas();
        }

        private void cmbxAviones_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el objeto avión seleccionado en el ComboBox
            Avion avionSeleccionado = (Avion)cmbxAviones.SelectedItem;

            // Obtener los valores que deseas mostrar en los TextBoxes y CheckBoxes

            // SE TUVO QUE COLOCAR UN IF != NULL -------------------------------------------------------------------------AVISO!!
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

        private void btnOpcionDos_Click(object sender, EventArgs e)
        {
            // Obtener el objeto avión seleccionado en el ComboBox
            Avion avionSeleccionado = (Avion)cmbxAviones.SelectedItem;

            // Actualizar las propiedades del objeto con los valores de los TextBoxes y CheckBoxes
            if (ActualizarMatricula(avionSeleccionado) && ActualizarCantidadAsientos(avionSeleccionado) && ActualizarCantidadBanos(avionSeleccionado) &&
                ActualizarCapacidadBodega(avionSeleccionado) && ActualizarOfreceComida(avionSeleccionado) && ActualizarServicioInternet(avionSeleccionado))
            {
                ActualizarListas();
                LimpiarTextBoxes();
                MessageBox.Show("Modificacion Exitosa");
            }
        }
       
        private void btnOpcionTres_Click(object sender, EventArgs e)
        {
            string matriculaAEliminar = txtIngresar.Text; // Obtener la matrícula ingresada por el usuario
            Avion avionAEliminar = null; // Buscar el avión con la matrícula ingresada en la lista

            foreach (Avion avion in aerolinea.listaAviones)
            {
                if (avion.Matricula == matriculaAEliminar)
                {
                    avionAEliminar = avion;
                    break;
                }
            }

            // Si se encontró el avión, eliminarlo de la lista
            if (avionAEliminar != null)
            {
                aerolinea.eliminarAvion(avionAEliminar);
                lstAviones.Items.Remove(matriculaAEliminar);
                MessageBox.Show("El avión ha sido eliminado.");
                ActualizarListas();
            }
            else
            {
                MessageBox.Show("No se encontró ningún avión con la matrícula ingresada.");
            }
        }

        #region
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

        private bool ActualizarCapacidadBodega(Avion avion)
        {
            int capacidadBodega;

            if (int.TryParse(txtBodega.Text, out capacidadBodega) && Validador.ValidarNumeroPositivo(capacidadBodega))
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

        private bool ActualizarOfreceComida(Avion avion)
        {
            avion.OfreceComida = chkComida.Checked;
            return true;
        }

        private bool ActualizarServicioInternet(Avion avion)
        {
            avion.ServicioInternet = chkWifi.Checked;
            return true;
        }

        private void LimpiarTextBoxes()
        {
            txtBodega.Text = "";
            txtCantAsientos.Text = "";
            txtCantBaños.Text = "";
            txtIngresar.Text = "";
            txtMatricula.Text = "";
        }

        private void ActualizarListas()
        {
            lstAviones.DataSource = null;
            cmbxAviones.DataSource = null;
            lstAviones.DataSource = aerolinea.listaAviones;
            cmbxAviones.DataSource = aerolinea.listaAviones;
            lstAviones.DisplayMember = "Matricula";
            cmbxAviones.DisplayMember = "Matricula";
            lstAviones.Refresh();
            cmbxAviones.Refresh();
        }

        #endregion
    }
}
