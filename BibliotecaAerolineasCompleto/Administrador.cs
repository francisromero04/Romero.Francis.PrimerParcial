using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAerolineasCompleto
{
    /// <summary>
    /// Representa un administrador en el sistema de aerolíneas.
    /// </summary>
    public class Administrador:Persona
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Administrador"/>.
        /// </summary>
        /// <param name="nombre">El nombre del administrador.</param>
        /// <param name="cargo">El rol o puesto del administrador.</param>
        /// <param name="correo">La dirección de correo electrónico del administrador.</param>
        /// <param name="contraseña">La contraseña del administrador.</param>
        public Administrador(string nombre, string cargo, string correo, string contraseña) : base(nombre, cargo, correo, contraseña)
        {
            // Constructor vacío
        }

        /// <summary>
        /// Devuelve una representación de cadena del objeto <see cref="Administrador"/>.
        /// </summary>
        /// <returns>Una representación de cadena del objeto.</returns>
        public override string ToString()
        {
            return $"Nombre: {nombre}, Cargo: {cargo}, Correo: {correo}";
        }
    }
}
