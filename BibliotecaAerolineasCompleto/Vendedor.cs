using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAerolineasCompleto
{
    /// <summary>
    /// Clase que representa a un vendedor en el sistema de una aerolínea.
    /// Hereda de la clase Persona.
    /// </summary>
    public class Vendedor :Persona
    {
        /// <summary>
        /// Crea una nueva instancia de la clase Vendedor con el nombre, cargo, correo y contraseña especificados.
        /// </summary>
        /// <param name="nombre">El nombre del vendedor.</param>
        /// <param name="cargo">El cargo del vendedor.</param>
        /// <param name="correo">El correo del vendedor.</param>
        /// <param name="contraseña">La contraseña del vendedor.</param>
        public Vendedor(string nombre, string cargo, string correo, string contraseña) : base(nombre, cargo, correo, contraseña)
        {
            // Constructor vacío
        }

        /// <summary>
        /// Devuelve una representación en forma de cadena de texto del vendedor.
        /// </summary>
        /// <returns>La representación del vendedor en forma de cadena de texto.</returns>
        public override string ToString()
        {
            return $"Nombre: {nombre}, Cargo: {cargo}, Correo: {correo}";
        }
    }
}
