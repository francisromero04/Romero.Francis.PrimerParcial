using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaAerolineasCompleto
{
    /// <summary>
    /// Representa a un pasajero de una aerolínea.
    /// </summary>
    public class Pasajero
    {        
        private int dni;
        public string nombre;
        public string apellido;

        /// <summary>
        /// Obtiene o establece el segundo nombre del pasajero.
        /// </summary>
        public string segundoNombre { get; set; }
        /// <summary>
        /// Obtiene o establece el segundo apellido del pasajero.
        /// </summary>
        public string segundoApellido { get; set; }
        /// <summary>
        /// Obtiene o establece el estado del pasajero.
        /// </summary>
        public int estado { get; set; }
        /// <summary>
        /// Obtiene o establece el tipo de pasajero.
        /// </summary>
        public bool tipoPasajero { get; set; }
        /// <summary>
        /// Obtiene o establece el género del pasajero.
        /// </summary>
        public bool Genero { get; set; }
        /// <summary>
        /// Obtiene o establece el peso del equipaje del pasajero.
        /// </summary>
        public decimal pesoEquipaje { get; set; }
        /// <summary>
        /// Obtiene o establece la cantidad de vuelos realizados  pasajero.
        /// </summary>
        public int cantidadVuelosHistoricos { get; set; }

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
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            this.segundoNombre = segundoNombre;
            this.segundoApellido = segundoApellido;
            this.Genero = genero;
            this.pesoEquipaje = pesoEquipaje;
            this.tipoPasajero = tipoPasajero;
            this.cantidadVuelosHistoricos = 0;
        }

        #region GETTERS Y SETTERS

        /// <summary>
        /// Obtiene o establece el número de identificación del pasajero.
        /// </summary>
        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        /// <summary>
        /// Obtiene o establece el nombre del pasajero.
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Obtiene o establece el apellido del pasajero.
        /// </summary>
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
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

                if(Genero == true)
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

        //ELIMINAR
        private string ObtenerNombreAleatorio(Random random, bool genero)
        {
            if (genero)
            {
                // Generar un nombre de hombre aleatorio
                return ((NombresDeHombre)random.Next(Enum.GetNames(typeof(NombresDeHombre)).Length)).ToString();
            }
            else
            {
                // Generar un nombre de mujer aleatorio
                return ((NombresDeMujer)random.Next(Enum.GetNames(typeof(NombresDeMujer)).Length)).ToString();
            }
        }
               
        private string ObtenerApellidoAleatorio(Random random)
        {
            return ((Apellidos)random.Next(Enum.GetNames(typeof(Apellidos)).Length)).ToString();
        }

        private bool EsMismoGenero(string primerNombre, string segundoNombre, bool genero)
        {
            if (genero)
            {
                return Enum.IsDefined(typeof(NombresDeHombre), segundoNombre);
            }
            else
            {
                return Enum.IsDefined(typeof(NombresDeMujer), segundoNombre);
            }
        }

        public Pasajero GenerarPasajeroAleatorio(Random random)
        {
            int dni = random.Next(9000000, 50000000); // Generar DNI aleatorio en el rango especificado            
            bool genero = random.Next(2) == 0 ? true : false; // Generar el género aleatoriamente
            string nombre = ObtenerNombreAleatorio(random, genero); // Obtener un nombre aleatorio
            string apellido = ObtenerApellidoAleatorio(random);// Obtener un apellido aleatorio
            estado = 0; // ESTADO INICIAL (no realizo ningun viaje anteriormente ni esta en un viaje en curso)
            decimal pesoEquipaje = (decimal)(random.Next(500, 2300)) / 100.0M;
            System.Threading.Thread.Sleep(1);
            //MODIFICAR PARA QUE HAYA MENOS PROBABILIDAD DE PREMIUM
            //    bool tipoPasajero = random.Next(2) == 0 ? true : false; // Generar el tipo de pasajero con una probabilidad del 50% 

            bool tipoPasajero = random.Next(10) == 0 ? false : true; // Generar el tipo de pasajero con una probabilidad del 10%

            // Determinar si el pasajero tendrá segundo nombre o no (50% de probabilidades)
            string segundoNombre = "";
            if (random.Next(2) == 0)
            {
                segundoNombre = ObtenerNombreAleatorio(random, genero);
            }

            // Determinar si el pasajero tendrá segundo apellido o no (50% de probabilidades)
            string segundoApellido = "";
            if (random.Next(2) == 0)
            {
                segundoApellido = ObtenerApellidoAleatorio(random);
            }

            // Si el pasajero tiene segundo nombre, asegurarse de que sea del mismo género que el primer nombre
            if (segundoNombre != "" && !EsMismoGenero(nombre, segundoNombre, genero))
            {
                segundoNombre = ObtenerNombreAleatorio(random, genero);
            }

            return new Pasajero(dni, nombre, apellido, genero, tipoPasajero, segundoNombre, segundoApellido, pesoEquipaje); // Crear un nuevo objeto Pasajero con los datos aleatorios
        }

        #endregion
    }
}