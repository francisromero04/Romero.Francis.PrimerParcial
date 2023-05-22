using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAerolineasCompleto
{
    /// <summary>
    /// Representa un avión en el sistema de aerolíneas.
    /// </summary>
    public class Avion
    {
        /// <summary>
        /// Obtiene o establece la matrícula del avión.
        /// </summary>
        public string Matricula { get; set; }
        /// <summary>
        /// Obtiene o establece la cantidad de asientos del avión.
        /// </summary>
        public int CantidadAsientos { get; set; }
        /// <summary>
        /// Obtiene o establece la cantidad de baños del avión.
        /// </summary>
        public int CantidadBanos { get; set; }
        /// <summary>
        /// Obtiene o establece un valor que indica si el avión cuenta con servicio de internet.
        /// </summary>
        public bool ServicioInternet { get; set; }
        /// <summary>
        /// Obtiene o establece un valor que indica si el avión ofrece servicio de comida.
        /// </summary>
        public bool OfreceComida { get; set; }
        /// <summary>
        /// Obtiene o establece la capacidad de la bodega del avión en kilogramos.
        /// </summary>
        public decimal CapacidadBodega { get; set; }
        /// <summary>
        /// Obtiene o establece un valor que indica si el avión está ocupado en un vuelo.
        /// </summary>
        public bool OcupadoEnVuelo { get; set; }
        /// <summary>
        /// Obtiene o establece el número de horas de vuelo históricas del avión.
        /// </summary>
        public int horasVueloHistoricas { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Avion"/>.
        /// </summary>
        public Avion()
        {
            //CONSTRUCTOR VACIO
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Avion"/> con los valores proporcionados.
        /// </summary>
        /// <param name="matricula">La matrícula del avión.</param>
        /// <param name="cantidadAsientos">La cantidad de asientos del avión.</param>
        /// <param name="cantidadBanos">La cantidad de baños del avión.</param>
        /// <param name="servicioInternet">Indica si el avión cuenta con servicio de internet.</param>
        /// <param name="ofreceComida">Indica si el avión ofrece servicio de comida.</param>
        /// <param name="capacidadBodega">La capacidad de la bodega del avión en kilogramos.</param>
        /// <param name="horas">El número de horas de vuelo históricas del avión.</param>
        public Avion(string matricula, int cantidadAsientos, int cantidadBanos, bool servicioInternet, bool ofreceComida, decimal capacidadBodega, int horas)
        {
            Matricula = matricula;
            CantidadAsientos = cantidadAsientos;
            CantidadBanos = cantidadBanos;
            ServicioInternet = servicioInternet;
            OfreceComida = ofreceComida;
            CapacidadBodega = capacidadBodega;
            horasVueloHistoricas = horas;
        }

        /// <summary>
        /// Genera un avión aleatorio con valores aleatorios para cada propiedad.
        /// </summary>
        /// <returns>Una instancia de la clase <see cref="Avion"/> con valores aleatorios.</returns>
        public Avion GenerarAvionAleatorio() //ELIMINAR
        {
            Random rnd = new Random(DateTime.Now.Millisecond); //lee los milisegundos de la pc y en base a eso genera el random
            const string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string matricula = new string(
                Enumerable.Range(1, 8)
                    .Select(x => x <= 4 ? letras[rnd.Next(letras.Length)] : Char.Parse(rnd.Next(10).ToString()))
                    .ToArray()
            );
            int cantidadAsientos = rnd.Next(50, 300);
            int cantidadBanos = rnd.Next(1, 5);
            bool servicioInternet = rnd.Next(2) == 1;
            bool ofreceComida = rnd.Next(2) == 1;
            decimal capacidadBodega = rnd.Next(1000, 10000);
            OcupadoEnVuelo = false;
            horasVueloHistoricas = 0;
            return new Avion(matricula, cantidadAsientos, cantidadBanos, servicioInternet, ofreceComida, capacidadBodega, horasVueloHistoricas);
        }

        /// <summary>
        /// Obtiene el estado actual del avión en formato de cadena.
        /// </summary>
        /// <value>Una cadena que describe el estado actual del avión.</value>
        public string ObtenerEstadoAvion
        {
            get
            {
                string ocupado = OcupadoEnVuelo ? "ocupado" : "disponible";
                return $"Avión con matrícula {Matricula}, estado: {ocupado}, asientos: {CantidadAsientos}";
            }
        }

        /// <summary>
        /// Determina si el objeto actual es igual a otro objeto.
        /// </summary>
        /// <param name="obj">El objeto a comparar.</param>
        /// <returns><c>true</c> si el objeto actual es igual al objeto especificado; de lo contrario, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            // Si el objeto es null, entonces no son iguales
            if (obj == null)
                return false;

            // Si el objeto no es de tipo Avion, entonces no son iguales
            if (!(obj is Avion))
                return false;

            // Compara la matrícula para determinar si son iguales
            Avion avion = (Avion)obj;
            return Matricula.Equals(avion.Matricula);
        }

        /// <summary>
        /// Devuelve el código hash del objeto actual.
        /// </summary>
        /// <returns>El código hash del objeto actual.</returns>
        public override int GetHashCode()
        {
            return Matricula.GetHashCode();
        }

        
    }
}
