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
    public partial class CrudAviones : Form
    {
        private Persona usuario;
        private Aerolinea aerolinea;

        public CrudAviones(Persona usuario, Aerolinea aerolinea)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.aerolinea = aerolinea;
            ActualizarListas();

            gbxModificarAeronave.Visible = false;
            gbxEliminarAeronave.Visible = false;
            gbxCrearAvion.Visible = false;
        }

        #region CONFIGURACION GROUPBOX

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

        private void btnOpcionUno_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            gbxCrearAvion.Location = new Point(780, 310);
            gbxCrearAvion.Visible = true;
        }

        private void btnOpcionDos_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            gbxModificarAeronave.Location = new Point(780, 310);
            gbxModificarAeronave.Visible = true;
        }
       
        private void btnOpcionTres_Click(object sender, EventArgs e)
        {
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = false;
            gbxEliminarAeronave.Location = new Point(780, 310);
            gbxEliminarAeronave.Visible = true;
        }

        #endregion

        #region ACCIONES CLICK BOTONES

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

            // Validar los números ingresados
            if (!Validador.ValidarNumeroPositivo(cantAsientos) || !Validador.ValidarNumeroPositivo(cantBanos) || !Validador.ValidarNumeroPositivo(capacidadBodega))
            {
                MessageBox.Show("Los números ingresados deben ser positivos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un nuevo objeto Avion utilizando el constructor
            Avion nuevoAvion = new Avion(matricula, cantAsientos, cantBanos, servicioInternet, ofreceComida, capacidadBodega);
            // Agregar el nuevo Avion a la lista de Avion de la aerolínea
            aerolinea.agregarAvion(nuevoAvion);
            // Mostrar un mensaje de éxito
            MessageBox.Show("El avión ha sido dado de alta correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActualizarListas();
        }

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtener la matrícula seleccionada en el ComboBox y limpiar espacios en blanco
            string matriculaAEliminar = cmbxAvionesDos.Text;
            // Buscar el avión a eliminar por su matrícula
            Avion avionAEliminar = null;

            foreach (Avion avion in aerolinea.listaAviones)
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

        private void btnCerrarUno_Click(object sender, EventArgs e)
        {
            gbxCrearAvion.Visible = false;
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = true;
        }

        private void btnCerrarDos_Click(object sender, EventArgs e)
        {
            gbxModificarAeronave.Visible = false;
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = true;
        }

        private void btnCerrarTres_Click(object sender, EventArgs e)
        {
            gbxEliminarAeronave.Visible = false;
            btnOpcionUno.Visible = btnOpcionDos.Visible = btnOpcionTres.Visible = btnOpcionCuatro.Visible = true;
        }

        #endregion

        #region ACTUALIZADORES

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
            txtMatricula.Text = "";
            txtBodega.Text = "";
            txtCantAsientos.Text = "";
            txtCantBaños.Text = "";
        }

        private void ActualizarListas()
        {
            lstAeronaves.DataSource = null;
            cmbxAviones.DataSource = null;
            cmbxAvionesDos.DataSource = null;

            lstAeronaves.DataSource = aerolinea.listaAviones;
            cmbxAviones.DataSource = aerolinea.listaAviones;
            cmbxAvionesDos.DataSource = aerolinea.listaAviones;

            lstAeronaves.DisplayMember = "ObtenerEstadoAvion";
            cmbxAviones.DisplayMember = "ObtenerEstadoAvion";
            cmbxAvionesDos.DisplayMember = "Matricula";

            chkComida.Checked = false;
            chkWifi.Checked = false;

            lstAeronaves.Refresh();
            cmbxAviones.Refresh();
            cmbxAvionesDos.Refresh();
        }

        #endregion

    }
}
