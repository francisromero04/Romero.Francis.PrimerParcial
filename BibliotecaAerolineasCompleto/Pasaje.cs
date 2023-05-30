using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAerolineasCompleto
{
    /// <summary>
    /// Representa un pasaje de avión.
    /// </summary>
    public class Pasaje
    {
        private Pasajero pasajero;
        private Vuelo vuelo;
        private bool tipoAsiento;
        private decimal costo;

        #region GETTERS Y SETTERS

        /// <summary>
        /// Obtiene o establece el pasajero asociado al pasaje.
        /// </summary>
        public Pasajero Pasajero
        {
            get {return pasajero; }
            set {pasajero = value; }
        }

        /// <summary>
        /// Obtiene o establece el vuelo asociado al pasaje.
        /// </summary>
        public Vuelo Vuelo 
        {
            get { return vuelo; }
            set {vuelo = value; }
        }

        /// <summary>
        /// Obtiene o establece el tipo de asiento del pasaje.
        /// </summary>
        /// <remarks>
        /// El valor <c>false</c> representa un asiento premium, mientras que el valor <c>true</c> representa un asiento regular.
        /// </remarks>
        ///  false = premium
        public bool TipoAsiento
        {
            get { return tipoAsiento; }
            set {tipoAsiento = value; }
        } 

        /// <summary>
        /// Obtiene o establece el costo del pasaje.
        /// </summary>
        public decimal Costo 
        {
            get {return costo; }
            set {costo = value; } 
        }

        #endregion

        /// <summary>
        /// Crea una nueva instancia de la clase Pasaje.
        /// </summary>
        /// <param name="pasajero">El pasajero asociado al pasaje.</param>
        /// <param name="vuelo">El vuelo asociado al pasaje.</param>
        /// <param name="tipoAsiento">El tipo de asiento del pasaje.</param>
        /// <param name="costo">El costo del pasaje.</param>
        public Pasaje(Pasajero pasajero, Vuelo vuelo, bool tipoAsiento, decimal costo)
        {
            this.pasajero = pasajero;
            this.vuelo = vuelo;
            this.tipoAsiento = tipoAsiento;
            this.costo = costo;
        }
    }
}
