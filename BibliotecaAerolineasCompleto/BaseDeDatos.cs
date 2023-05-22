using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Globalization;

namespace BibliotecaAerolineasCompleto
{
    /// <summary>
    /// Clase que representa una base de datos de usuarios.
    /// </summary>
    public class BaseDeDatos
    {
        /// <summary>
        /// Obtiene o establece el administrador de la base de datos.
        /// </summary>
        public Administrador administrador { get; set; }
        /// <summary>
        /// Obtiene o establece el supervisor de la base de datos.
        /// </summary>
        public Supervisor supervisor { get; set; }
        /// <summary>
        /// Obtiene la lista de vendedores de la base de datos.
        /// </summary>
        public List<Vendedor> vendedores { get; set; }

        /// <summary>
        /// Crea una nueva instancia de la clase BaseDeDatos.
        /// </summary>
        public BaseDeDatos()
        {
            vendedores = new List<Vendedor>(3);
            ExtraerDeArchivoJSON();
        }

        /// <summary>
        /// Busca un usuario en la base de datos por correo y contraseña.
        /// </summary>
        /// <param name="correo">El correo del usuario.</param>
        /// <param name="contraseña">La contraseña del usuario.</param>
        /// <returns>El objeto Persona que representa al usuario encontrado, o null si no se encontró ningún usuario.</returns>
        public Persona BuscarUsuario(string correo, string contraseña)
        {
            foreach (Vendedor vendedor in vendedores)
            {
                if (vendedor.correo == correo && vendedor.contraseña == contraseña)
                {
                    return vendedor;
                }
            }

            if (administrador.correo == correo && administrador.contraseña == contraseña)
            {
                return administrador;
            }

            if (supervisor.correo == correo && supervisor.contraseña == contraseña)
            {
                return supervisor;
            }

            return null;
        }

        /// <summary>
        /// Extrae los datos de la base de datos desde un archivo JSON.
        /// </summary>
        public void ExtraerDeArchivoJSON()
        {
            // Leemos el archivo JSON y lo almacenamos en una cadena de texto
            string json = File.ReadAllText("baseDatosUsuarios.json");

            // Deserializamos el JSON en un objeto anónimo con la misma estructura que utilizamos para serializar
            var datos = JsonConvert.DeserializeAnonymousType(json, new
            {
                administrador = new {Nombre = "", Cargo = "", Correo = "", Contraseña = "" },
                supervisor = new { Nombre = "", Cargo = "", Correo = "", Contraseña = "" },
                vendedores = new[] { new { Nombre = "", Cargo = "", Correo = "", Contraseña = "" } }
            });

            // Creamos los objetos Administrador, Supervisor y Vendedores a partir de los datos deserializados
            administrador = new Administrador(datos.administrador.Nombre,datos.administrador.Cargo,datos.administrador.Correo, datos.administrador.Contraseña);
            supervisor = new Supervisor(datos.supervisor.Nombre,datos.supervisor.Cargo, datos.supervisor.Correo, datos.supervisor.Contraseña);
            vendedores = datos.vendedores.Select(v => new Vendedor(v.Nombre,v.Cargo, v.Correo, v.Contraseña)).ToList();
        }

        /// <summary>
        /// Devuelve la información de un usuario basado en su correo y contraseña.
        /// </summary>
        /// <param name="correo">El correo del usuario.</param>
        /// <param name="contraseña">La contraseña del usuario.</param>
        /// <returns>Una cadena de texto con la información del usuario si existe, o un mensaje indicando que el usuario no existe.</returns>
        public string DevolverUsuario(string correo, string contraseña)
        {
            Persona usuario = BuscarUsuario(correo, contraseña);
            if (usuario == null)
            {
                return "El usuario no existe.";
            }

            // Construir la cadena de información del usuario
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Información del usuario:");
            sb.AppendLine($"Nombre completo: {usuario.nombre}");
            sb.AppendLine($"Correo electrónico: {usuario.correo}");
            sb.AppendLine($"Contraseña: {usuario.correo}");
            if (usuario is Vendedor vendedor)
            {
                sb.AppendLine($"Tipo de usuario: Vendedor");
            }
            else if (usuario is Administrador)
            {
                sb.AppendLine($"Tipo de usuario: Administrador");
            }
            else if (usuario is Supervisor)
            {
                sb.AppendLine($"Tipo de usuario: Supervisor");
            }

            return sb.ToString();
        }
    }
}
