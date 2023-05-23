using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAerolineasCompleto
{
    /// <summary>
    /// Clase abstracta que representa a una persona.
    /// </summary>
    public abstract class Persona
    {
        /// <summary>
        /// Obtiene o establece el cargo de la persona.
        /// </summary>
        public string cargo { get; set; }
        /// <summary>
        /// Obtiene o establece el correo de la persona.
        /// </summary>
        public string correo { get; set; }
        /// <summary>
        /// Obtiene o establece la contraseña de la persona.
        /// </summary>
        public string contraseña { get; set; }
        /// <summary>
        /// Obtiene o establece el nombre de la persona.
        /// </summary>
        public string nombre { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Persona con el nombre, cargo, correo y contraseña especificados.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="cargo">Cargo de la persona.</param>
        /// <param name="correo">Correo de la persona.</param>
        /// <param name="contraseña">Contraseña de la persona.</param>
        public Persona(string nombre, string cargo, string correo, string contraseña)
        {
            this.nombre = nombre;
            this.cargo = cargo;
            this.correo = correo;
            this.contraseña = contraseña;
        }

        /// <summary>
        /// Devuelve una cadena que representa la instancia actual de la clase Persona.
        /// </summary>
        /// <returns>Cadena que representa la instancia actual de la clase Persona.</returns>
        public abstract override string ToString();
    }
}
