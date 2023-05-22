using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAerolineasCompleto
{

    /// <summary>
    /// Clase que representa a un supervisor.
    /// </summary>
    public class Supervisor:Persona
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Supervisor con el nombre, cargo, correo y contraseña especificados.
        /// </summary>
        /// <param name="nombre">Nombre del supervisor.</param>
        /// <param name="cargo">Cargo del supervisor.</param>
        /// <param name="correo">Correo del supervisor.</param>
        /// <param name="contraseña">Contraseña del supervisor.</param>
        public Supervisor(string nombre, string cargo, string correo, string contraseña) : base(nombre, cargo, correo, contraseña)
        {
            // Constructor vacío
        }

        /// <summary>
        /// Devuelve una cadena que representa la instancia actual de la clase Supervisor.
        /// </summary>
        /// <returns>Cadena que representa la instancia actual de la clase Supervisor.</returns>
        public override string ToString()
        {
            return $"Nombre: {nombre}, Cargo: {cargo}, Correo: {correo}";
        }
    }
}
