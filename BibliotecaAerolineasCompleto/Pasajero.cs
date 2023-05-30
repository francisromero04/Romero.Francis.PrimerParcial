using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BibliotecaAerolineasCompleto
{
    [XmlRoot("Pasajero")]
    /// <summary>
    /// Representa a un pasajero de una aerolínea.
    /// </summary>
    public class Pasajero
    {
        private int dni;
        private string nombre;
        private string apellido;
        private string segundoNombre;       
        private string segundoApellido;
        private bool estado; //true = realizo viajes
        private bool tipoPasajero;
        private bool genero;
        private decimal pesoEquipaje;
        private int cantidadVuelosHistoricos;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Pasajero"/>.
        /// </summary>
        public Pasajero()
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Pasajero"/> con los valores proporcionados.
        /// </summary>
        /// <param name="dni">El número de identificación del pasajero.</param>
        /// <param name="nombre">El nombre del pasajero.</param>
        /// <param name="apellido">El apellido del pasajero.</param>
        /// <param name="genero">El género del pasajero. True representa masculino y False representa femenino.</param>
        /// <param name="tipoPasajero">El tipo de pasajero. True representa premium y False representa regular.</param>
        /// <param name="segundoNombre">El segundo nombre del pasajero.</param>
        /// <param name="segundoApellido">El segundo apellido del pasajero.</param>
        /// <param name="pesoEquipaje">El peso del equipaje del pasajero.</param>
        public Pasajero(int dni, string nombre, string apellido, bool genero, bool tipoPasajero, string segundoNombre, string segundoApellido, decimal pesoEquipaje) : this()
        {
            this.dni = dni;
            this.nombre = nombre;
            this.Apellido = apellido;
            this.segundoNombre = segundoNombre;
            this.segundoApellido = segundoApellido;
            this.genero = genero;
            this.pesoEquipaje = pesoEquipaje;
            this.tipoPasajero = tipoPasajero;
            this.cantidadVuelosHistoricos = 0;
        }

        #region GETTERS Y SETTERS

        [XmlElement("Dni")]
        /// <summary>
        /// Obtiene o establece el número de identificación del pasajero.
        /// </summary>
        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        [XmlElement("Nombre")]
        /// <summary>
        /// Obtiene o establece el nombre del pasajero.
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Obtiene o establece el segundo nombre del pasajero.
        /// </summary>
        [XmlElement("SegundoNombre")]
        public string SegundoNombre
        {
            get { return segundoNombre; } set { segundoNombre = value;}
        }

        [XmlElement("Apellido")]
        /// <summary>
        /// Obtiene o establece el apellido del pasajero.
        /// </summary>
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        } 

        /// <summary>
        /// Obtiene o establece el segundo apellido del pasajero.
        /// </summary>
        [XmlElement("SegundoApellido")]
        public string SegundoApellido
        {
            get { return segundoApellido; }
            set { segundoApellido = value; }
        }

        /// <summary>
        /// Obtiene o establece el estado del pasajero.
        /// </summary>
        [XmlElement("Estado")]
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        /// <summary>
        /// Obtiene o establece el tipo de pasajero del pasajero.
        /// </summary>
        [XmlElement("TipoPasajero")]
        public bool TipoPasajero
        {
            get { return tipoPasajero; }
            set { tipoPasajero = value; }
        }

        /// <summary>
        /// Obtiene o establece el genero del pasajero.
        /// </summary>
        [XmlElement("Genero")]
        public bool Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        /// <summary>
        /// Obtiene o establece el peso equipaje del pasajero.
        /// </summary>
        [XmlElement("PesoEquipaje")]
        public decimal PesoEquipaje
        {
            get { return pesoEquipaje; }
            set { pesoEquipaje = value; }
        }

        /// <summary>
        /// Obtiene o establece la cantidad de vuelos historicos del pasajero.
        /// </summary>
        [XmlElement("CantidadVuelosHistoricos")]
        public int CantidadVuelosHistoricos
        {
            get {return cantidadVuelosHistoricos; }
            set {cantidadVuelosHistoricos = value; }
        }

        #endregion

        #region GENERADORES

        /// <summary>
        /// Obtiene el nombre completo y DNI del pasajero.
        /// </summary>
        /// <returns>El nombre completo y DNI del pasajero.</returns>
        public string NombreCompletoyDni
        {
            get
            {
                string nombreCompleto = nombre;

                if (!string.IsNullOrEmpty(segundoNombre))
                {
                    nombreCompleto += " " + segundoNombre;
                }
                nombreCompleto += " " + apellido;
                if (!string.IsNullOrEmpty(segundoApellido))
                {
                    nombreCompleto += " " + segundoApellido;
                }
                nombreCompleto += " " + dni;

                if (genero == true)
                {
                    nombreCompleto += " (Masculino)";
                }
                else
                {
                    nombreCompleto += " (Femenino)";
                }

                return nombreCompleto;
            }
        }

        public override string ToString()
        {
            return NombreCompletoyDni;
        }

        /// <summary>
        /// Obtiene el nombre completo y DNI del pasajero.
        /// </summary>
        /// <returns>El nombre completo y DNI del pasajero.</returns>
        public string NombreCompletoyDniyViajes
        {
            get
            {
                string nombreCompleto = Nombre;

                if (!string.IsNullOrEmpty(segundoNombre))
                {
                    nombreCompleto += " " + segundoNombre;
                }
                nombreCompleto += " " + Apellido;
                if (!string.IsNullOrEmpty(segundoApellido))
                {
                    nombreCompleto += " " + segundoApellido;
                }
                nombreCompleto += " " + Dni;

                if (Genero == true)
                {
                    nombreCompleto += " (Masculino)";
                }
                else
                {
                    nombreCompleto += " (Femenino)";
                }

                nombreCompleto += " | Vuelos: " + cantidadVuelosHistoricos;

                return nombreCompleto;
            }
        }

        /// <summary>
        /// Determina si el objeto especificado es igual al objeto Pasajero actual.
        /// </summary>
        /// <param name="obj">El objeto a comparar con el objeto Pasajero actual.</param>
        /// <returns>true si el objeto especificado es igual al objeto Pasajero actual; de lo contrario, false.</returns>
        public override bool Equals(object obj)
        {
            // Si el objeto es null, entonces no son iguales
            if (obj == null)
                return false;

            // Si el objeto no es de tipo Pasajero, entonces no son iguales
            if (!(obj is Pasajero))
                return false;

            // Compara el dni para determinar si son iguales
            Pasajero pasajero = (Pasajero)obj;
            return dni == pasajero.dni;
        }

        /// <summary>
        /// Obtiene el código hash para el objeto Pasajero actual.
        /// </summary>
        /// <returns>El código hash para el objeto Pasajero actual.</returns>
        public override int GetHashCode()
        {
            return dni.GetHashCode();
        }

        // Sobrecarga del operador de igualdad (==)
        public static bool operator ==(Pasajero pasajero1, Pasajero pasajero2)
        {
            if (ReferenceEquals(pasajero1, pasajero2))
            {
                return true;
            }

            if (ReferenceEquals(pasajero1, null) || ReferenceEquals(pasajero2, null))
            {
                return false;
            }

            return pasajero1.Nombre == pasajero2.Nombre && pasajero1.Apellido == pasajero2.apellido;
        }

        // Sobrecarga del operador de desigualdad (!=)
        public static bool operator !=(Pasajero pasajero1, Pasajero pasajero2)
        {
            return !(pasajero1 == pasajero2);
        }

        // Conversión implícita de Persona a string
        public static implicit operator string(Pasajero pasajero)
        {
            return pasajero.Nombre;
        }

        // Conversión explícita de string a Persona
        public static explicit operator Pasajero(string nombre)
        {
            return new Pasajero { Nombre = nombre };
        }

        #endregion
    }
}